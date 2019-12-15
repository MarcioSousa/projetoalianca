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
    public partial class frm_CadastroLogin : Form
    {
        public frm_CadastroLogin()
        {
            InitializeComponent();
            dgvLogin.AutoGenerateColumns = false;
        }

        private void abrirCampos()
        {
            txtAcesso.Enabled = true;
            txtLogin.Enabled = true;
            txtConfSenha.Enabled = true;
            txtSenha.Enabled = true;

            btnCancelar.Enabled = true;
            btnConfirmar.Enabled = true;

            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            dgvLogin.Enabled = false;

            txtLogin.Focus();

        }
        private void fecharCampos()
        {
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
            txtConfSenha.Enabled = false;
            txtAcesso.Enabled = false;

            btnCancelar.Enabled = false;
            btnConfirmar.Enabled = false;

            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;

            dgvLogin.Enabled = true;
        }
        private void limpaCampos()
        {
            lblCodigo.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtConfSenha.Text = "";
            txtAcesso.Text = "";
        }
        private void carregaTodoCadastro()
        {
            try
            {
                cls_AcessoNegocio acessoNegocio = new cls_AcessoNegocio();
                cls_AcessoColecao acessoColecao = new cls_AcessoColecao();

                acessoColecao = acessoNegocio.TodoRegistro();

                dgvLogin.DataSource = null;
                dgvLogin.DataSource = acessoColecao;

                dgvLogin.Refresh();
                dgvLogin.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NAÕ FOI POSSÍVEL CARREGAR O FORMULÁRIO.\nTENTE NOVAMENTE! Aviso: " + ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frm_CadastroLogin_Load(object sender, EventArgs e)
        {
            fecharCampos();
            carregaTodoCadastro();
        }
        private void dgvLogin_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                if (dgvLogin.Rows.Count != 0)
                {
                    lblCodigo.Text = dgvLogin.Rows[dgvLogin.CurrentRow.Index].Cells[0].Value.ToString();
                    txtLogin.Text = dgvLogin.Rows[dgvLogin.CurrentRow.Index].Cells[1].Value.ToString();
                    txtSenha.Text = dgvLogin.Rows[dgvLogin.CurrentRow.Index].Cells[2].Value.ToString();
                    txtConfSenha.Text = txtSenha.Text;
                    txtAcesso.Text = dgvLogin.Rows[dgvLogin.CurrentRow.Index].Cells[3].Value.ToString();
                }
                else
                {
                    limpaCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NÃO FOI POSSÍVEL CARREGAR SEU FORMULÁRIO, TENTE NOVAMENTE.Aviso: " + ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLogin.Rows.Count != 0)
            {
                abrirCampos();
            } else
            {
                MessageBox.Show("NÃO HÁ NENHUM LOGIN CADASTRADO.\nCADASTRE UMA LOGIN EM SEU SISTEMA CLICANDO NO BOTÃO 'NOVO'!", "EDIÇÃO DE LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvLogin.Rows.Count != 0)
            {
                if (MessageBox.Show("DESEJA DELETAR O LOGIN SELECIONADO?\nCÓDIGO Nº " + lblCodigo.Text, "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cls_Acesso acesso = new cls_Acesso();
                    cls_AcessoNegocio acessoNegocio = new cls_AcessoNegocio();

                    acesso.codigo = Convert.ToInt32(lblCodigo.Text);

                    acessoNegocio.Excluir(acesso);

                    MessageBox.Show("EXCLUÍDO COM SUCESSO!", "EXCLUSÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    carregaTodoCadastro();
                }
            }
            else
            {
                MessageBox.Show("NÃO HÁ NENHUMA LOGIN CADASTRADO.\nCADASTRE UM LOGIN EM SEU SISTEMA CLICANDO NO BOTÃO 'NOVO'!", "EXCLUSÃO DE LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            abrirCampos();
            limpaCampos();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtSenha.Text == txtConfSenha.Text)
                {
                    if (txtAcesso.Text == "abcde12345")
                    {
                        cls_AcessoNegocio acessoNegocio = new cls_AcessoNegocio();
                        cls_Acesso acesso = new cls_Acesso();

                        acesso.nome = txtLogin.Text;
                        acesso.senha = txtSenha.Text;
                        acesso.acesso = txtAcesso.Text;

                        if (lblCodigo.Text == "")
                        {
                            acessoNegocio.Inserir(acesso);

                            MessageBox.Show("LOGIN CADASTRADO COM SUCESSO", "ACESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            acesso.codigo = Convert.ToInt32(lblCodigo.Text);
                            acessoNegocio.Alterar(acesso);
                            MessageBox.Show("ALTERAÇÃO FEITA COM SUCESSO!", "ACESSO.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        carregaTodoCadastro();
                        fecharCampos();
                    } else
                    {
                        MessageBox.Show("DÍGITO DO ACESSO NÃO CONFERE.\nDIGITE NOVAMENTE OU ENTRE EM CONTATO COM O DESENVOLVEDOR DESSE SISTEMA.", "ACESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAcesso.Text = "";
                        txtAcesso.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("SENHA NÃO CONFIRMADA, DIGITE NOVAMENTE A MESMA SENHA NOS DOIS CAMPOS", "SENHA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSenha.Text = "";
                    txtConfSenha.Text = "";
                    txtSenha.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("NÃO FOI POSSÍVEL INSERIR UM NOVO LOGIN NO SISTEMA.\nTENTE NOVAMENTE OU FALE COM O DESENVOLVEDOR DESSE SISTEMA.", "INSERÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            fecharCampos();
            carregaTodoCadastro();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}