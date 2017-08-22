using DAL;
using Ferramentas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLFornecedor
    {
        private DALConexao conexao;

        public BLLFornecedor(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloFornecedor modelo)
        {
            if (modelo.ForNome.Trim().Length == 0)
            {
                throw new Exception("O nome do fornecedor é obrigatório");
            }
            if (modelo.ForCnpj.Trim().Length == 0)
            {
                throw new Exception("O cnpj do fornecedor é obrigatório");
            }
           
            if (Validacao.IsCnpj(modelo.ForCnpj) == false)
            {
                throw new Exception("CNPJ Inválido");
            }
            
            if (modelo.ForIe.Trim().Length == 0)
            {
                throw new Exception("A insc.est. do fornecedor é obrigatório");
            }
            if (modelo.ForFone.Trim().Length == 0)
            {
                throw new Exception("O telefone do fornecedor é obrigatório");
            }
            // Validação para email
            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}"
            + "\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\"
            + ".)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(modelo.ForEmail))
            {
                throw new Exception("Digite um email válido.");
            }
            modelo.ForNome = modelo.ForNome.ToUpper();
            modelo.ForEndereco = modelo.ForEndereco.ToUpper();
            modelo.ForBairro = modelo.ForBairro.ToUpper();
            modelo.ForCidade = modelo.ForCidade.ToUpper();
            modelo.ForEstado = modelo.ForEstado.ToUpper();
            DALFornecedor DALobj = new DALFornecedor(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloFornecedor modelo)
        {
            if (modelo.ForNome.Trim().Length == 0)
            {
                throw new Exception("O nome do fornecedor é obrigatório");
            }
            if (modelo.ForCnpj.Trim().Length == 0)
            {
                throw new Exception("O cnpj do fornecedor é obrigatório");
            }
            if (modelo.ForIe.Trim().Length == 0)
            {
                throw new Exception("A insc. est. do fornecedor é obrigatório");
            }
            if (modelo.ForFone.Trim().Length == 0)
            {
                throw new Exception("O telefone do fornecedor é obrigatório");
            }
            // Validação para email
            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}"
            + "\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\"
            + ".)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(modelo.ForEmail))
            {
                throw new Exception("Digite um email válido.");
            }
            //Valida CEP
            if (Validacao.ValidaCep(modelo.ForCep) == false)
            {
                throw new Exception("O CEP é inválido");
            }
            modelo.ForNome = modelo.ForNome.ToUpper();
            modelo.ForEndereco = modelo.ForEndereco.ToUpper();
            modelo.ForBairro = modelo.ForBairro.ToUpper();
            modelo.ForCidade = modelo.ForCidade.ToUpper();
            modelo.ForEstado = modelo.ForEstado.ToUpper();
            DALFornecedor DALobj = new DALFornecedor(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALFornecedor DALobj = new DALFornecedor(conexao);
            DALobj.Excluir(codigo);
        }
        public DataTable LocalizarNome(String valor)
        {
            DALFornecedor DALobj = new DALFornecedor(conexao);
            return DALobj.LocalizarNome(valor);
        }
        public DataTable LocalizarCpfcnpj(String valor)
        {
            DALFornecedor DALobj = new DALFornecedor(conexao);
            return DALobj.LocalizarCNPJ(valor);
        }
        public ModeloFornecedor CarregarModeloForente(int codigo)
        {
            DALFornecedor DALobj = new DALFornecedor(conexao);
            return DALobj.CarregaModeloFornecedor(codigo);
        }
        public ModeloFornecedor CarregarModeloFornecedor(string cnpj)
        {
            DALFornecedor DALobj = new DALFornecedor(conexao);
            return DALobj.CarregaModeloFornecedor(cnpj);
        }
    }
}
