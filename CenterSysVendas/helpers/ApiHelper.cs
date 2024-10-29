using System;
using System.IO;
using System.Net;
using System.Text;
using Google.Protobuf.WellKnownTypes;
using System.Text.Json;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.IO;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;
using RestSharp;

namespace helpers
{
    public class ApiHelper
    {

        private readonly string _iniFilePath;
        private string _token;
        private DateTime _tokenExpiration;

        private readonly string _galaxId;
        private readonly string _galaxHash;
        private readonly string _galaxIdPartner;
        private readonly string _galaxHashPartner;

        public ApiHelper(string iniFilePath)
        {
            _iniFilePath = iniFilePath;
            var parser = new FileIniDataParser();
            IniData data;

            try
            {
                data = parser.ReadFile(_iniFilePath);
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException("Erro ao ler o arquivo de configuração INI.", ex);
            }

            _galaxId = data["Authentication"]["GalaxId"];
            _galaxHash = data["Authentication"]["GalaxHash"];
            _galaxIdPartner = data["Partner"]["GalaxIdPartner"];
            _galaxHashPartner = data["Partner"]["GalaxHashPartner"];
            _token = data["Authentication"]["Token"];

            if (!DateTime.TryParse(data["Authentication"]["TokenExpiration"], out _tokenExpiration))
            {
                _tokenExpiration = DateTime.MinValue;
            }

            if (string.IsNullOrEmpty(_token) || DateTime.Now >= _tokenExpiration)
            {
                Task.Run(() => AuthenticateAsync()).Wait();
            }
            
        }

        public static bool CriarAssinatura(int ClienteId, decimal ValorTotal, string DescricaoProduto)
        {
            return true;            
        }

        public async Task  AuthenticateAsync()
        {
            string basicAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_galaxId}:{_galaxHash}"));

            var client = new RestClient("https://api.sandbox.cel.cash/v2/token");
            var request = new RestRequest("/", RestSharp.Method.Post);

            request.AddHeader("Authorization", "Basic " + basicAuth);
            request.AddHeader("Content-Type", "application/json");

            string body = @"{ ""grant_type"": ""authorization_code"", ""scope"": ""subscriptions.write"" }";
            request.AddStringBody(body, ContentType.Json);

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                try
                {
                    var responseData = JsonDocument.Parse(response.Content);
                    _token = responseData.RootElement.GetProperty("access_token").GetString();
                    _tokenExpiration = DateTime.Now.AddSeconds(responseData.RootElement.GetProperty("expires_in").GetInt32());

                    var parser = new FileIniDataParser();
                    IniData data = parser.ReadFile(_iniFilePath);
                    data["Authentication"]["Token"] = _token;
                    data["Authentication"]["TokenExpiration"] = _tokenExpiration.ToString("o");
                    parser.WriteFile(_iniFilePath, data);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao processar a resposta da autenticação.", ex);
                }
            }
            else
            {
                throw new Exception($"Falha na autenticação: {response.ErrorMessage} - {response.Content}");
            }
        }

        public async Task<string> CreateSubscriptionAsync(Subscription subscription)
        {
            if (DateTime.Now >= _tokenExpiration)
            {
                await AuthenticateAsync();
            }

            var client = new RestClient("https://api.sandbox.cel.cash/v2/subscriptions");
            var request = new RestRequest("/", RestSharp.Method.Post);
            request.AddHeader("Authorization", "Bearer " + _token);
            request.AddHeader("Content-Type", "application/json");


            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };

            
           string bodyJson = System.Text.Json.JsonSerializer.Serialize(subscription, options);
            

            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "json.txt");
            await File.WriteAllTextAsync(jsonFilePath, bodyJson);

            Console.WriteLine($"JSON salvo em: {jsonFilePath}");

            request.AddStringBody(bodyJson, ContentType.Json);

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return $"Assinatura criada com sucesso! Resposta: {response.Content}";
            }
            else
            {
                return $"Erro ao criar assinatura: {response.ErrorMessage} - {response.Content}";
            }
        }
    }


    public class Subscription
    {
        public string MyId { get; set; }
        public int Value { get; set; }
        public string Payday { get; set; }
        public bool PayedOutsideGalaxPay { get; set; }
        public string AdditionalInfo { get; set; }
        public Customer Customer { get; set; }
        public PaymentMethodCreditCard PaymentMethodCreditCard { get; set; }
        public InvoiceConfig InvoiceConfig { get; set; }
    }

    public class Customer
    {
        public string MyId { get; set; }
        public int GalaxPayId { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string[] Emails { get; set; }
        public string[] Phones { get; set; }
        public bool InvoiceHoldIss { get; set; }
        public string MunicipalDocument { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public ExtraField[] ExtraFields { get; set; }
    }

    public class Address
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class ExtraField
    {
        public string TagName { get; set; }
        public string TagValue { get; set; }
    }

    public class PaymentMethodCreditCard
    {
        public Card Card { get; set; }
        public Antifraud Antifraud { get; set; }
        public string CardOperatorId { get; set; }
        public bool PreAuthorize { get; set; }
    }

    public class Card
    {
        public string MyId { get; set; }
        public int GalaxPayId { get; set; }
        public string Number { get; set; }
        public string Holder { get; set; }
        public string ExpiresAt { get; set; }
        public string Cvv { get; set; }
    }

    public class Antifraud
    {
        public string Ip { get; set; }
        public string SessionId { get; set; }
    }

    public class InvoiceConfig
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public string CreateOn { get; set; }
        public int QtdDaysBeforePayDay { get; set; }
        public int QtdDaysAfterPay { get; set; }
    }

}
