using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Windows.Forms;
using Negocios;
using DTO;

namespace View
{
    public partial class frm_Pessoa : Form
    {
        public frm_Pessoa()
        {
            InitializeComponent();
            dgvPessoas.AutoGenerateColumns = false;
        }
        private void abrirCampos()
        {
            dtpDataCadastro.Enabled = true;
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            cbxUf.Enabled = true;
            mtxCep.Enabled = true;
            txtRg.Enabled = true;
            txtEstadoCivil.Enabled = true;
            mtxCpf.Enabled = true;
            dtpDataNascimento.Enabled = true;
            txtNacionalidade.Enabled = true;
            txtNaturalidade.Enabled = true;
            cbxGenero.Enabled = true;
            nudFilho.Enabled = true;
            txtConjugue.Enabled = true;
            txtOrigem.Enabled = true;
            txtDestino.Enabled = true;
            mtbCelular.Enabled = true;
            mtbTelefone.Enabled = true;
            txtObservacoes.Enabled = true;
            txtObservacoes.ReadOnly = false;
            rbtNao.Enabled = true;
            rbtSim.Enabled = true;
            rbtNao.Checked = true;

            btnCancelar.Enabled = true;
            btnConfirmar.Enabled = true;

            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            dgvPessoas.Enabled = false;
            txtPesquisar.Enabled = false;

            txtNome.Focus();
        }
        private void fecharCampos()
        {
            dtpDataCadastro.Enabled = false;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            cbxUf.Enabled = false;
            mtxCep.Enabled = false;
            txtRg.Enabled = false;
            txtEstadoCivil.Enabled = false;
            mtxCpf.Enabled = false;
            dtpDataNascimento.Enabled = false;
            txtNacionalidade.Enabled = false;
            txtNaturalidade.Enabled = false;
            cbxGenero.Enabled = false;
            nudFilho.Enabled = false;
            txtConjugue.Enabled = false;
            txtOrigem.Enabled = false;
            txtDestino.Enabled = false;
            mtbCelular.Enabled = false;
            mtbTelefone.Enabled = false;
            txtObservacoes.ReadOnly = true;
            rbtNao.Enabled = false;
            rbtSim.Enabled = false;
            rbtNao.Checked = false;

            btnCancelar.Enabled = false;
            btnConfirmar.Enabled = false;

            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            dgvPessoas.Enabled = true;
            txtPesquisar.Enabled = true;
        }
        private void limpaCampos()
        {
            dtpDataCadastro.Text = "";
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cbxUf.Text = "";
            mtxCep.Text = "";
            txtRg.Text = "";
            txtEstadoCivil.Text = "";
            mtxCpf.Text = "";
            dtpDataNascimento.Value = DateTime.Today;
            txtNacionalidade.Text = "";
            txtNaturalidade.Text = "";
            cbxGenero.Text = "";
            nudFilho.TextAlign = 0;
            txtConjugue.Text = "";
            txtOrigem.Text = "";
            txtDestino.Text = "";
            mtbCelular.Text = "";
            mtbTelefone.Text = "";
            txtObservacoes.Text = "";
        }
        private void carregaTodoCadastro()
        {
            cls_PessoaNegocio pessoaNegocio = new cls_PessoaNegocio();
            cls_PessoaColecao pessoaColecao = new cls_PessoaColecao();

            pessoaColecao = pessoaNegocio.TodoRegistro();

            dgvPessoas.DataSource = null;
            dgvPessoas.DataSource = pessoaColecao;

            dgvPessoas.Refresh();
            dgvPessoas.Update();
        }
        private void pesquisaCadastroNome()
        {
            cls_PessoaNegocio pessoaNegocio = new cls_PessoaNegocio();
            cls_PessoaColecao pessoaColecao = new cls_PessoaColecao();

            pessoaColecao = pessoaNegocio.ConsultarPorNome(txtPesquisar.Text);

            dgvPessoas.DataSource = null;
            dgvPessoas.DataSource = pessoaColecao;

            dgvPessoas.Refresh();
            dgvPessoas.Update();
        }

        private void frm_Pessoa_Load(object sender, EventArgs e)
        {
            fecharCampos();
            carregaTodoCadastro();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (txtPesquisar.Text != "")
            {
                pesquisaCadastroNome();
            }
            else
            {
                carregaTodoCadastro();
            }
        }
        private void dgvPessoas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cls_PessoaColecao pessoaColecao = new cls_PessoaColecao();
                cls_PessoaNegocio pessoaNegocio = new cls_PessoaNegocio();

                pessoaColecao = pessoaNegocio.ConsultarPorCodigo(Convert.ToInt32(dgvPessoas.Rows[dgvPessoas.CurrentRow.Index].Cells[0].Value));

                if (pessoaColecao.Count != 0)
                {
                    txtCodigo.Text = pessoaColecao[0].codigo.ToString();
                    txtNome.Text = pessoaColecao[0].nome.ToString();
                    txtEndereco.Text = pessoaColecao[0].endereco.ToString();
                    txtNumero.Text = pessoaColecao[0].numero.ToString();
                    txtBairro.Text = pessoaColecao[0].bairro.ToString();
                    txtCidade.Text = pessoaColecao[0].cidade.ToString();
                    cbxUf.Text = pessoaColecao[0].uf.ToString();
                    mtxCep.Text = pessoaColecao[0].cep.ToString();
                    txtRg.Text = pessoaColecao[0].rg.ToString();
                    txtEstadoCivil.Text = pessoaColecao[0].estadocivil.ToString();
                    mtxCpf.Text = pessoaColecao[0].cpf.ToString();
                    dtpDataNascimento.Text = pessoaColecao[0].datanascimento.ToString();
                    txtNacionalidade.Text = pessoaColecao[0].nacionalidade.ToString();
                    txtNaturalidade.Text = pessoaColecao[0].naturalidade.ToString();
                    cbxGenero.Text = pessoaColecao[0].genero.ToString();
                    nudFilho.Text = pessoaColecao[0].filhos.ToString();
                    txtConjugue.Text = pessoaColecao[0].conjugue.ToString();
                    txtOrigem.Text = pessoaColecao[0].origem.ToString();
                    txtDestino.Text = pessoaColecao[0].destino.ToString();
                    mtbCelular.Text = pessoaColecao[0].celular.ToString();
                    mtbTelefone.Text = pessoaColecao[0].telefone.ToString();
                    txtObservacoes.Text = pessoaColecao[0].observ.ToString();

                    if (pessoaColecao[0].antecedentes == true)
                    {
                        rbtSim.Checked = true;
                    }
                    else
                    {
                        rbtNao.Checked = false;
                    }
                }
                else
                {
                    limpaCampos();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("NÃO FOI POSSÍVEL CARREGAR SEU FORMULÁRIO, TENTE NOVAMENTE.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPessoas.Rows.Count != 0)
            {
                abrirCampos();
            }
            else
            {
                MessageBox.Show("NÃO HÁ NENHUMA PESSOA CADASTRADO.\nCADASTRE UMA PESSOA EM SEU SISTEMA CLICANDO NO BOTÃO 'NOVO'!", "EDIÇÃO DE PESSOA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvPessoas.Rows.Count != 0)
            {
                if (MessageBox.Show("DESEJA DELETAR O CADASTRO SELECIONADO?\nCÓDIGO Nº " + txtCodigo.Text, "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cls_Pessoa pessoa = new cls_Pessoa();
                    cls_PessoaNegocio pessoaNegocio = new cls_PessoaNegocio();

                    pessoa.codigo = Convert.ToInt32(txtCodigo.Text);

                    pessoaNegocio.Excluir(pessoa);

                    MessageBox.Show("EXCLUÍDO COM SUCESSO!", "EXCLUSÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carregaTodoCadastro();
                }
            }
            else
            {
                MessageBox.Show("NÃO HÁ NENHUMA PESSOA CADASTRADO.\nCADASTRE UMA PESSOA EM SEU SISTEMA CLICANDO NO BOTÃO 'NOVO'!", "EXCLUSÃO DE PESSOA", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cls_PessoaNegocio pessoaNegocio = new cls_PessoaNegocio();
                cls_Pessoa pessoa = new cls_Pessoa();

                pessoa.nome = txtNome.Text;
                pessoa.endereco = txtEndereco.Text;
                pessoa.numero = txtNumero.Text;
                pessoa.bairro = txtBairro.Text;
                pessoa.cidade = txtCidade.Text;
                pessoa.uf = cbxUf.Text;
                if (mtxCep.Text.Replace("-", "").Trim() == "")
                {
                    pessoa.cep = 0;
                }
                else
                {
                    pessoa.cep = Convert.ToInt32(mtxCep.Text.Replace("-", ""));
                }
                pessoa.rg = txtRg.Text;
                pessoa.cpf = mtxCpf.Text.ToString();
                pessoa.telefone = mtbTelefone.Text;
                pessoa.celular = mtbCelular.Text;
                pessoa.datanascimento = Convert.ToDateTime(dtpDataNascimento.Text);
                pessoa.estadocivil = txtEstadoCivil.Text;
                pessoa.filhos = Convert.ToInt32(nudFilho.Value);
                pessoa.conjugue = txtConjugue.Text;
                pessoa.origem = txtOrigem.Text;
                pessoa.destino = txtDestino.Text;
                pessoa.genero = cbxGenero.Text;
                pessoa.naturalidade = txtNaturalidade.Text;
                pessoa.nacionalidade = txtNacionalidade.Text;
                pessoa.datacadastro = Convert.ToDateTime(dtpDataCadastro.Text);
                pessoa.observ = txtObservacoes.Text;
                if (rbtSim.Checked)
                {
                    pessoa.antecedentes = true;
                }
                else
                {
                    pessoa.antecedentes = false;
                }
                if (txtCodigo.Text == "")
                {
                    MessageBox.Show("O CÓDIGO DA PESSOA É: " + pessoaNegocio.Inserir(pessoa), "CÓDIGO DA PESSOA.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    pessoa.codigo = Convert.ToInt32(txtCodigo.Text);
                    MessageBox.Show("ALTERAÇÃO FEITA COM SUCESSO!\nCÓDIGO: " + pessoaNegocio.Alterar(pessoa), "CÓDIGO DA PESSOA.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                carregaTodoCadastro();
                fecharCampos();
            }
            catch (Exception)
            {
                MessageBox.Show("NÃO FOI POSSÍVEL INSERIR UM NOVA PESSOA NO SISTEMA.\nTENTE NOVAMENTE OU FALE COM O DESENVOLVEDOR DESSE SISTEMA.", "INSERÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            fecharCampos();
            carregaTodoCadastro();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvPessoas.Rows.Count != 0)
            {
                frm_Impressao impressao = new frm_Impressao(dtpDataCadastro.Text.ToString(), txtCodigo.Text, txtNome.Text);
                impressao.ShowDialog();
            }
            else
            {
                MessageBox.Show("CADASTRE A PRIMEIRA PESSOA NO SISTEMA!", "IMPRESSÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
