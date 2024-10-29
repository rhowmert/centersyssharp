using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using controllers;

namespace CenterSysVendas.forms
{
    public partial class FRM_Login : Form
    {
        public FRM_Login()
        {
            InitializeComponent();
        }

        private void FRM_Login_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            if(EDT_Login.Text =="" || EDT_Senha.Text =="")
            {
                MessageBox.Show("Erro ao executar o acesso, verifique suas credenciais!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                


            
            UsuarioController usr = new UsuarioController();
            
            if(usr.login(EDT_Login.Text,EDT_Senha.Text))
            {
                helpers.Globais.UsuarioId = usr.PegaIdPeloLogin(EDT_Login.Text);
                               
                FRM_Principal frmPrincipal = new FRM_Principal();
                frmPrincipal.Show();
                this.Hide(); 
                frmPrincipal.FormClosed += (s, args) => this.Close();

            }
            else
            {
                MessageBox.Show("Erro ao executar o acesso, verifique suas credenciais!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void BTN_Sair_Click(object sender, EventArgs e)
        {
           
            DialogResult result = MessageBox.Show(
                  "Deseja realmente sair?",
                  "Confirmação",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
              );
            if ( result == DialogResult.Yes ) 
                this.Close();            
                            
        }
    }
}
