using CenterSysVendas.forms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CenterSysVendas
{
    public partial class FRM_Principal : Form
    {
        public FRM_Principal()
        {
            InitializeComponent();
            this.MdiChildActivate += FRM_Principal_MdiChildActivate;
        }

        private void AbrirFormulario<T>() where T : Form, new()
        {
            Form FormAberto = this.MdiChildren.FirstOrDefault(f => f is T);
            if (FormAberto != null)
            {
                FormAberto.Activate();
                return;
            }

            T NovoFormulario = new T();
            NovoFormulario.MdiParent = this;
            NovoFormulario.Show();

        }



        private void FRM_Principal_MdiChildActivate(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FRM_Usuarios>();
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FRM_Cidades>();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FRM_Clientes>();
        }

        private void formasDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FRM_FormaPagamento>();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FRM_Produtos>();
        }

        private void pDVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FRM_PDV>();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show(
                  "Deseja realmente sair?",
                  "Confirmação",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
              );
            if (result == DialogResult.Yes)
            {
                helpers.Globais.UsuarioId = 0;

                FRM_Login frmLogin = new FRM_Login();
                frmLogin.Show();
                this.Hide();
                frmLogin.FormClosed += (s, args) => this.Close();
            }
        }

        private void listagemDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FRM_ListaVendas>();
        }
    }
}
