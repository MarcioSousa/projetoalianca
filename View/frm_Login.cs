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

namespace View
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NESSA JANELA:\n\n1) DIGITE O NOME DE ACESSO.\n2) DIGITE A SENHA DE ACESSO.\n3) CLIQUE NO BOTÃO INICIAR PARA CONECTAR NO SISTEMA.\n--------------------------------------------------------------------------------\nCLIQUE NO BOTÃO 'SAIR/FECHAR' PARA ENCERRAR O SISTEMA", "AJUDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "ADMIN" && txtSenha.Text == "admin")
            {
                this.Visible = false;
                frm_Principal principal = new frm_Principal(true);
                principal.ShowDialog();
                return;
            }

            cls_Acesso acesso = new cls_Acesso();
            cls_AcessoNegocio acessoNegocio = new cls_AcessoNegocio();
            cls_AcessoColecao acessoColecao = new cls_AcessoColecao();
            cls_AcessoColecao acessoColecao2 = new cls_AcessoColecao();

            acessoColecao = acessoNegocio.TodoRegistro();
            acessoColecao2 = acessoNegocio.ConsultarPorNome(txtNome.Text.Trim());

            if (acessoColecao.Count != 0)
            {
                if (acessoColecao2.Count != 0)
                {
                    if (acessoColecao2[0].senha.Trim() == txtSenha.Text.Trim())
                    {
                        this.Visible = false;
                        frm_Principal principal = new frm_Principal(false);
                        principal.ShowDialog();
                        
                        return;
                    }
                    else
                    {
                        MessageBox.Show("SENHA NÃO CONFERE.\nDIGITE O NOME E A SENHA PARA CONECTAR AO SISTEMA.", "SENHA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNome.Text = "";
                        txtSenha.Text = "";
                        txtNome.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("NÃO FOI ENCONTRADO NENHUM ACESSO COM ESSE NOME.\nTENTE NOVAMENTE.", "NOME DE ACESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.Text = "";
                    txtSenha.Text = "";
                    txtNome.Focus();
                }
            }
            else
            {
                MessageBox.Show("NENHUM REGISTRO ENCONTRADO.\nCONECTE AO SISTEMA COMO ADMINISTRADOR PARA PODER FAZER SEU PRIMEIRO CADASTRO.", "SEM ACESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}