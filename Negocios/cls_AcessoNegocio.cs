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
    public class cls_AcessoNegocio
    {
        cls_AcessoBancoDados acessoBandoDados = new cls_AcessoBancoDados();

        public string Inserir(cls_Acesso acesso)
        {
            try
            {
                acessoBandoDados.LimparParametros();
                acessoBandoDados.AdicionarParametros("@Acao", 0);
                acessoBandoDados.AdicionarParametros("@nome", acesso.nome);
                acessoBandoDados.AdicionarParametros("@senha", acesso.senha);
                acessoBandoDados.AdicionarParametros("@acesso", acesso.acesso);
                return acessoBandoDados.ExecutarManipulacao(CommandType.StoredProcedure, "usp_LoginCRUD").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Alterar(cls_Acesso acesso)
        {
            try
            {
                acessoBandoDados.LimparParametros();
                acessoBandoDados.AdicionarParametros("@Acao", 1);
                acessoBandoDados.AdicionarParametros("@codigo", acesso.codigo);
                acessoBandoDados.AdicionarParametros("@nome", acesso.nome);
                acessoBandoDados.AdicionarParametros("@senha", acesso.senha);
                acessoBandoDados.AdicionarParametros("@acesso", acesso.acesso);
                return acessoBandoDados.ExecutarManipulacao(CommandType.StoredProcedure, "usp_LoginCRUD").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Excluir(cls_Acesso acesso)
        {
            try
            {
                acessoBandoDados.LimparParametros();
                acessoBandoDados.AdicionarParametros("@Acao", 2);
                acessoBandoDados.AdicionarParametros("@codigo", acesso.codigo);
                return acessoBandoDados.ExecutarManipulacao(CommandType.StoredProcedure, "usp_LoginCRUD").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public cls_AcessoColecao TodoRegistro()
        {
            try
            {
                cls_Acesso acesso = new cls_Acesso();
                cls_AcessoColecao acessoColecao = new cls_AcessoColecao();

                acessoBandoDados.LimparParametros();
                acessoBandoDados.AdicionarParametros("@Acao", 3);

                DataTable dataTableAcesso = acessoBandoDados.ExecutarConsulta(CommandType.StoredProcedure, "usp_LoginCRUD");

                foreach (DataRow linha in dataTableAcesso.Rows)
                {
                    cls_Acesso acesso2 = new cls_Acesso();

                    acesso2.codigo = Convert.ToInt32(linha["codigo"]);
                    acesso2.nome = linha["nome"].ToString();
                    acesso2.senha = linha["senha"].ToString();
                    acesso2.acesso = linha["acesso"].ToString();

                    acessoColecao.Add(acesso2);
                }
                return acessoColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("NÃO FOI POSSÍVEL CARREGAR OS DADOS DE ACESSO.\nDETALHES: " + ex.Message);
            }
        }
        public cls_AcessoColecao ConsultarPorCodigo(int cod)
        {
            try
            {
                cls_Acesso acesso = new cls_Acesso();
                cls_AcessoColecao acessoColecao = new cls_AcessoColecao();

                acessoBandoDados.LimparParametros();
                acessoBandoDados.AdicionarParametros("@Acao", 4);
                acessoBandoDados.AdicionarParametros("", cod);

                DataTable dataTableAcesso = acessoBandoDados.ExecutarConsulta(CommandType.StoredProcedure, "usp_LoginCRUD");

                foreach (DataRow linha in dataTableAcesso.Rows)
                {
                    cls_Acesso acesso2 = new cls_Acesso();
                    acesso2.codigo = Convert.ToInt32(linha["codigo"]);
                    acesso2.nome = linha["nome"].ToString();
                    acesso2.senha = linha["senha"].ToString();
                    acesso2.acesso = linha["acesso"].ToString();

                    acessoColecao.Add(acesso2);
                }
                return acessoColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("NÃO FOI POSSÍVEL CARREGAR OS DADOS DE LOGIN.\nDETALHES: " + ex.Message);
            }
        }
        public cls_AcessoColecao ConsultarPorNome(string nome)
        {
            try
            {
                cls_Acesso acesso = new cls_Acesso();
                cls_AcessoColecao acessoColecao = new cls_AcessoColecao();

                acessoBandoDados.LimparParametros();
                acessoBandoDados.AdicionarParametros("@Acao", 5);
                acessoBandoDados.AdicionarParametros("@pesquisa", nome);

                DataTable dataTableAcesso = acessoBandoDados.ExecutarConsulta(CommandType.StoredProcedure, "usp_LoginCRUD");

                foreach (DataRow linha in dataTableAcesso.Rows)
                {
                    cls_Acesso acesso2 = new cls_Acesso();
                    acesso2.nome = linha["nome"].ToString();
                    acesso2.senha = linha["senha"].ToString();

                    acessoColecao.Add(acesso2);
                    break;
                }
                return acessoColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("NÃO FOI POSSÍVEL CARREGAR OS DADOS DE LOGIN.\nDETALHES: " + ex.Message);
            }
        }
    }

}