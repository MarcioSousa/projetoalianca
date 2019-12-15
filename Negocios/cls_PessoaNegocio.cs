using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace Negocios
{
    public class cls_PessoaNegocio
    {
        cls_AcessoBancoDados acessoBancoDados = new cls_AcessoBancoDados();

        public string Inserir(cls_Pessoa pessoa)
        {
            try
            {
                acessoBancoDados.LimparParametros();
                acessoBancoDados.AdicionarParametros("@Acao", 0);
                acessoBancoDados.AdicionarParametros("@Nome", pessoa.nome);
                acessoBancoDados.AdicionarParametros("@Endereco", pessoa.endereco);
                acessoBancoDados.AdicionarParametros("@Numero", pessoa.numero);
                acessoBancoDados.AdicionarParametros("@Bairro", pessoa.bairro);
                acessoBancoDados.AdicionarParametros("@Cidade", pessoa.cidade);
                acessoBancoDados.AdicionarParametros("@Uf", pessoa.uf);
                acessoBancoDados.AdicionarParametros("@Cep", pessoa.cep);
                acessoBancoDados.AdicionarParametros("@Rg", pessoa.rg);
                acessoBancoDados.AdicionarParametros("@Cpf", pessoa.cpf);
                acessoBancoDados.AdicionarParametros("@Telefone", pessoa.telefone);
                acessoBancoDados.AdicionarParametros("@Celular", pessoa.celular);
                acessoBancoDados.AdicionarParametros("@DataNascimento", pessoa.datanascimento);
                acessoBancoDados.AdicionarParametros("@EstadoCivil", pessoa.estadocivil);
                acessoBancoDados.AdicionarParametros("@Filhos", pessoa.filhos);
                acessoBancoDados.AdicionarParametros("@Conjugue", pessoa.conjugue);
                acessoBancoDados.AdicionarParametros("@Origem", pessoa.origem);
                acessoBancoDados.AdicionarParametros("@Destino", pessoa.destino);
                acessoBancoDados.AdicionarParametros("@Genero", pessoa.genero);
                acessoBancoDados.AdicionarParametros("@Naturalidade", pessoa.naturalidade);
                acessoBancoDados.AdicionarParametros("@Nacionalidade", pessoa.nacionalidade);
                acessoBancoDados.AdicionarParametros("@Antecedentes", pessoa.antecedentes);
                acessoBancoDados.AdicionarParametros("@DataCadastro", pessoa.datacadastro);
                acessoBancoDados.AdicionarParametros("@Observ", pessoa.observ);

                return acessoBancoDados.ExecutarManipulacao(CommandType.StoredProcedure, "usp_PessoaCRUD").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Alterar(cls_Pessoa pessoa)
        {
            try
            {
                acessoBancoDados.LimparParametros();
                acessoBancoDados.AdicionarParametros("@Acao", 1);
                acessoBancoDados.AdicionarParametros("@Codigo", pessoa.codigo);
                acessoBancoDados.AdicionarParametros("@Nome", pessoa.nome);
                acessoBancoDados.AdicionarParametros("@Endereco", pessoa.endereco);
                acessoBancoDados.AdicionarParametros("@Numero", pessoa.numero);
                acessoBancoDados.AdicionarParametros("@Bairro", pessoa.bairro);
                acessoBancoDados.AdicionarParametros("@Cidade", pessoa.cidade);
                acessoBancoDados.AdicionarParametros("@Uf", pessoa.uf);
                acessoBancoDados.AdicionarParametros("@Cep", pessoa.cep);
                acessoBancoDados.AdicionarParametros("@Rg", pessoa.rg);
                acessoBancoDados.AdicionarParametros("@Cpf", pessoa.cpf);
                acessoBancoDados.AdicionarParametros("@Telefone", pessoa.telefone);
                acessoBancoDados.AdicionarParametros("@Celular", pessoa.celular);
                acessoBancoDados.AdicionarParametros("@DataNascimento", pessoa.datanascimento);
                acessoBancoDados.AdicionarParametros("@EstadoCivil", pessoa.estadocivil);
                acessoBancoDados.AdicionarParametros("@Filhos", pessoa.filhos);
                acessoBancoDados.AdicionarParametros("@Conjugue", pessoa.conjugue);
                acessoBancoDados.AdicionarParametros("@Origem", pessoa.origem);
                acessoBancoDados.AdicionarParametros("@Destino", pessoa.destino);
                acessoBancoDados.AdicionarParametros("@Genero", pessoa.genero);
                acessoBancoDados.AdicionarParametros("@Naturalidade", pessoa.naturalidade);
                acessoBancoDados.AdicionarParametros("@Nacionalidade", pessoa.nacionalidade);
                acessoBancoDados.AdicionarParametros("@Antecedentes", pessoa.antecedentes);
                acessoBancoDados.AdicionarParametros("@DataCadastro", pessoa.datacadastro);
                acessoBancoDados.AdicionarParametros("@Observ", pessoa.observ);
                return acessoBancoDados.ExecutarManipulacao(CommandType.StoredProcedure, "usp_PessoaCRUD").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Excluir(cls_Pessoa pessoa)
        {
            try
            {
                acessoBancoDados.LimparParametros();
                acessoBancoDados.AdicionarParametros("@Acao", 2);
                acessoBancoDados.AdicionarParametros("@Codigo", pessoa.codigo);
                return acessoBancoDados.ExecutarManipulacao(CommandType.StoredProcedure, "usp_PessoaCRUD").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public cls_PessoaColecao TodoRegistro()
        {
            try
            {
                cls_Pessoa pessoa = new cls_Pessoa();
                cls_PessoaColecao pessoaColecao = new cls_PessoaColecao();

                acessoBancoDados.LimparParametros();
                acessoBancoDados.AdicionarParametros("@Acao", 3);

                DataTable dataTablePessoa = acessoBancoDados.ExecutarConsulta(CommandType.StoredProcedure, "usp_PessoaCRUD");

                foreach (DataRow linha in dataTablePessoa.Rows)
                {
                    cls_Pessoa pessoa1 = new cls_Pessoa();

                    pessoa1.codigo = Convert.ToInt32(linha["codigo"]);
                    pessoa1.nome = linha["nome"].ToString();
                    pessoa1.endereco = linha["endereco"].ToString();
                    pessoa1.numero = linha["numero"].ToString();
                    pessoa1.bairro = linha["bairro"].ToString();
                    pessoa1.cidade = linha["cidade"].ToString();
                    pessoa1.uf = linha["uf"].ToString();
                    pessoa1.cep = Convert.ToInt32(linha["cep"]);
                    pessoa1.rg = linha["rg"].ToString();
                    pessoa1.cpf = linha["cpf"].ToString();
                    pessoa1.telefone  = linha["telefone"].ToString();
                    pessoa1.celular = linha["celular"].ToString();
                    pessoa1.datanascimento = Convert.ToDateTime(linha["datanascimento"]);
                    pessoa1.estadocivil = linha["estadocivil"].ToString();
                    pessoa1.filhos = Convert.ToInt32(linha["filhos"]);
                    pessoa1.conjugue = linha["conjugue"].ToString();
                    pessoa1.origem = linha["origem"].ToString();
                    pessoa1.destino = linha["destino"].ToString();
                    pessoa1.genero = Convert.ToString(linha["genero"]);
                    pessoa1.naturalidade = linha["naturalidade"].ToString();
                    pessoa1.nacionalidade = linha["nacionalidade"].ToString();
                    pessoa1.antecedentes = Convert.ToBoolean(linha["antecedentes"]);
                    pessoa1.datacadastro = Convert.ToDateTime(linha["datacadastro"]);
                    pessoa1.observ = linha["observ"].ToString();

                    pessoaColecao.Add(pessoa1);
                }
                return pessoaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("NÃO FOI POSSÍVEL CARREGAR OS DADOS DE ACESSO.\nDETALHES: " + ex.Message);
            }
        }
        public cls_PessoaColecao ConsultarPorCodigo(int cod)
        {
            try
            {
                cls_Pessoa pessoa = new cls_Pessoa();
                cls_PessoaColecao pessoaColecao = new cls_PessoaColecao();

                acessoBancoDados.LimparParametros();
                acessoBancoDados.AdicionarParametros("@Acao", 4);
                acessoBancoDados.AdicionarParametros("@Codigo", cod);

                DataTable dataTablePessoa = acessoBancoDados.ExecutarConsulta(CommandType.StoredProcedure, "usp_PessoaCRUD");

                foreach (DataRow linha in dataTablePessoa.Rows)
                {
                    cls_Pessoa pessoa1 = new cls_Pessoa();

                    pessoa1.codigo = Convert.ToInt32(linha["codigo"]);
                    pessoa1.nome = linha["nome"].ToString();
                    pessoa1.endereco = linha["endereco"].ToString();
                    pessoa1.numero = linha["numero"].ToString();
                    pessoa1.bairro = linha["bairro"].ToString();
                    pessoa1.cidade = linha["cidade"].ToString();
                    pessoa1.uf = linha["uf"].ToString();
                    pessoa1.cep = Convert.ToInt32(linha["cep"]);
                    pessoa1.rg = linha["rg"].ToString();
                    pessoa1.cpf = linha["cpf"].ToString();
                    pessoa1.telefone = linha["telefone"].ToString();
                    pessoa1.celular = linha["celular"].ToString();
                    pessoa1.datanascimento = Convert.ToDateTime(linha["datanascimento"]);
                    pessoa1.estadocivil = linha["estadocivil"].ToString();
                    pessoa1.filhos = Convert.ToInt32(linha["filhos"]);
                    pessoa1.conjugue = linha["conjugue"].ToString();
                    pessoa1.origem = linha["origem"].ToString();
                    pessoa1.destino = linha["destino"].ToString();
                    pessoa1.genero = Convert.ToString(linha["genero"]);
                    pessoa1.naturalidade = linha["naturalidade"].ToString();
                    pessoa1.nacionalidade = linha["nacionalidade"].ToString();
                    pessoa1.antecedentes = Convert.ToBoolean(linha["antecedentes"]);
                    pessoa1.datacadastro = Convert.ToDateTime(linha["datacadastro"]);
                    pessoa1.observ = linha["observ"].ToString();

                    pessoaColecao.Add(pessoa1);
                    break;
                }
                return pessoaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("NÃO FOI POSSÍVEL CARREGAR OS DADOS DE LOGIN.\nDETALHES: " + ex.Message);
            }
        }
        public cls_PessoaColecao ConsultarPorNome(string nome)
        {
            try
            {
                cls_PessoaColecao pessoaColecao = new cls_PessoaColecao();

                acessoBancoDados.LimparParametros();
                acessoBancoDados.AdicionarParametros("@Acao", 5);
                acessoBancoDados.AdicionarParametros("@Pesquisa", nome);

                DataTable dataTablePessoa = acessoBancoDados.ExecutarConsulta(CommandType.StoredProcedure, "usp_PessoaCRUD");

                foreach (DataRow linha in dataTablePessoa.Rows)
                {
                    cls_Pessoa pessoa1 = new cls_Pessoa();

                    pessoa1.codigo = Convert.ToInt32(linha["codigo"]);
                    pessoa1.nome = linha["nome"].ToString();
                    pessoa1.endereco = linha["endereco"].ToString();
                    pessoa1.numero = linha["numero"].ToString();
                    pessoa1.bairro = linha["bairro"].ToString();
                    pessoa1.cidade = linha["cidade"].ToString();
                    pessoa1.uf = linha["uf"].ToString();
                    pessoa1.cep = Convert.ToInt32(linha["cep"]);
                    pessoa1.rg = linha["rg"].ToString();
                    pessoa1.cpf = linha["cpf"].ToString();
                    pessoa1.telefone = linha["telefone"].ToString();
                    pessoa1.celular = linha["celular"].ToString();
                    pessoa1.datanascimento = Convert.ToDateTime(linha["datanascimento"]);
                    pessoa1.estadocivil = linha["estadocivil"].ToString();
                    pessoa1.filhos = Convert.ToInt32(linha["filhos"]);
                    pessoa1.conjugue = linha["conjugue"].ToString();
                    pessoa1.origem = linha["origem"].ToString();
                    pessoa1.destino = linha["destino"].ToString();
                    pessoa1.genero = Convert.ToString(linha["genero"]);
                    pessoa1.naturalidade = linha["naturalidade"].ToString();
                    pessoa1.nacionalidade = linha["nacionalidade"].ToString();
                    pessoa1.antecedentes = Convert.ToBoolean(linha["antecedentes"]);
                    pessoa1.datacadastro = Convert.ToDateTime(linha["datacadastro"]);
                    pessoa1.observ = linha["observ"].ToString();

                    pessoaColecao.Add(pessoa1);
                }
                return pessoaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("NÃO FOI POSSÍVEL CARREGAR OS DADOS DAS PESSOAS.\nDETALHES: " + ex.Message);
            }
        }

    }
}
