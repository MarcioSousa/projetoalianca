using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Negocios;
using System.IO;

namespace View
{
    public partial class frm_Principal : Form
    {
        public frm_Principal(bool adm)
        {
            InitializeComponent();

            if (adm == true)
            {
                inicialToolStripMenuItem.Visible = false;
                btnPessoa.Visible = false;
            }
            else
            {
                btnLogin.Visible = false;
                loginToolStripMenuItem.Visible = false;
            }
        }

        private void frm_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar o Sistema?", "Encerramento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnPessoa_Click(object sender, EventArgs e)
        {
            frm_Pessoa pessoa = new frm_Pessoa();
            pessoa.ShowDialog();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            frm_CadastroLogin login = new frm_CadastroLogin();
            login.ShowDialog();
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CadastroLogin login = new frm_CadastroLogin();
            login.ShowDialog();
        }
        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar o Sistema?", "Encerramento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(caminho + "\\Alianca.mdf"))
            {
                File.Delete(caminho + "\\Alianca.mdf");
            }

            File.Copy("Alianca.mdf", caminho + "\\Alianca.mdf");

            MessageBox.Show("FOI CRIADO UM BACKUP DOS DADOS CADASTRADOS NO SISTEMA.\nO NOME DO ARQUIVO É 'Alianca'\n E ESTÁ EM 'Meus Documentos'.\nSALVE ESSE ARQUIVO NUM LUGAR SEGURO.", "BACKUP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}