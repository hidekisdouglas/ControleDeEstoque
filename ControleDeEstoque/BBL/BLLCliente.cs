using DAL;
using Ferramentas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCliente
    {
        private DALConexao conexao;

        public BLLCliente(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloCliente modelo)
        {
            if (modelo.CliNome.Trim().Length == 0)
            {
                throw new Exception("O nome do cliente é obrigatório");
            }
            if (modelo.CliCpfCnpj.Trim().Length == 0)
            {
                throw new Exception("O cpf/cnpj do cliente é obrigatório");
            }
            if (modelo.CliTipo == "Física")
                {
                    if (Validacao.IsCpf(modelo.CliCpfCnpj) == false)
                    {
                        throw new Exception("CPF Inválido");
                    }
                }
            else
                {
                    if (Validacao.IsCnpj(modelo.CliCpfCnpj) == false)
                    {
                        throw new Exception("CNPJ Inválido");
                    }
                }
            if (modelo.CliRgIe.Trim().Length == 0)
            {
                throw new Exception("O rg/insc.est. do cliente é obrigatório");
            }
            if (modelo.CliFone.Trim().Length == 0)
            {
                throw new Exception("O telefone do cliente é obrigatório");
            }
            modelo.CliNome = modelo.CliNome.ToUpper();
            modelo.CliEndereco = modelo.CliEndereco.ToUpper();
            modelo.CliBairro = modelo.CliBairro.ToUpper();
            modelo.CliCidade = modelo.CliCidade.ToUpper();
            modelo.CliEstado = modelo.CliEstado.ToUpper();
            DALCliente DALobj = new DALCliente(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloCliente modelo)
        {
            if (modelo.CliNome.Trim().Length == 0)
            {
                throw new Exception("O nome do cliente é obrigatório");
            }
            if (modelo.CliCpfCnpj.Trim().Length == 0)
            {
                throw new Exception("O cpf/cnpj do cliente é obrigatório");
            }
            if (modelo.CliRgIe.Trim().Length == 0)
            {
                throw new Exception("O rg/insc.est. do cliente é obrigatório");
            }
            if (modelo.CliFone.Trim().Length == 0)
            {
                throw new Exception("O telefone do cliente é obrigatório");
            }
            
            modelo.CliNome = modelo.CliNome.ToUpper();
            modelo.CliEndereco = modelo.CliEndereco.ToUpper();
            modelo.CliBairro = modelo.CliBairro.ToUpper();
            modelo.CliCidade = modelo.CliCidade.ToUpper();
            modelo.CliEstado = modelo.CliEstado.ToUpper();
            DALCliente DALobj = new DALCliente(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALCliente DALobj = new DALCliente(conexao);
            DALobj.Excluir(codigo);
        }
        public DataTable LocalizarNome(String valor)
        {
            DALCliente DALobj = new DALCliente(conexao);
            return DALobj.LocalizarNome(valor);
        }
        public DataTable LocalizarCpfcnpj(String valor)
        {
            DALCliente DALobj = new DALCliente(conexao);
            return DALobj.LocalizarCPF(valor);
        }
        public ModeloCliente CarregarModeloCliente(int codigo)
        {
            DALCliente DALobj = new DALCliente(conexao);
            return DALobj.CarregaModeloCliente(codigo);
        }
        public ModeloCliente CarregarModeloCliente(string cpfcnpj)
        {
            DALCliente DALobj = new DALCliente(conexao);
            return DALobj.CarregaModeloCliente(cpfcnpj);
        }
    }
}
