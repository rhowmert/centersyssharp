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
    public partial class FRM_ListaVendas : Form
    {
        public FRM_ListaVendas()
        {
            InitializeComponent();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BTN_Sair_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Deseja realmente sair?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void FRM_ListaVendas_Load(object sender, EventArgs e)
        {
            VendaController vendas = new VendaController();
            dataGridView1.DataSource = vendas.ObterVendas();
        }
    }
}
