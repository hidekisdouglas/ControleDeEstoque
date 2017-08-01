using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLProduto
    {
        private DALConexao conexao;

        public BLLProduto(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloProduto modelo)
        {
            if (modelo.ProNome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }
            if (modelo.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("A descri~ção do produto é obrigatório");
            }
            if (modelo.ProValorVenda <= 0)
            {
                throw new Exception("O Valor de venda do prooduto é obrigatório");
            }
            if (modelo.ProQtde < 0)
            {
                throw new Exception("A quantidade do prooduto deve ser maior ou igual a 0");
            }
            if (modelo.UmedCod <= 0)
            {
                throw new Exception("É necessário escolher uma unidade de medida.");
            }
            if (modelo.CatCod <= 0)
            {
                throw new Exception("É necessário escolher uma categoria.");
            }
            if (modelo.ScatCod <= 0)
            {
                throw new Exception("É necessário escolher uma subcategoria.");
            }

            modelo.ProNome = modelo.ProNome.ToUpper();
            modelo.ProDescricao = modelo.ProDescricao.ToUpper();
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloProduto modelo)
        {
            if (modelo.ProNome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }
            if (modelo.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("A descri~ção do produto é obrigatório");
            }
            if (modelo.ProValorVenda <= 0)
            {
                throw new Exception("O Valor de venda do prooduto é obrigatório");
            }
            if (modelo.ProQtde < 0)
            {
                throw new Exception("A quantidade do prooduto deve ser maior ou igual a 0");
            }
            if (modelo.UmedCod <= 0)
            {
                throw new Exception("É necessário escolher uma unidade de medida.");
            }
            if (modelo.CatCod <= 0)
            {
                throw new Exception("É necessário escolher uma categoria.");
            }
            if (modelo.ScatCod <= 0)
            {
                throw new Exception("É necessário escolher uma subcategoria.");
            }
            if (modelo.ProCod <= 0)
            {
                throw new Exception("O código do produto é obrigatório.");
            }
            modelo.ProNome = modelo.ProNome.ToUpper();
            modelo.ProDescricao = modelo.ProDescricao.ToUpper();
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Excluir(codigo);
        }
        public DataTable Localizar(String valor)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.Localizar(valor);
        }
        public ModeloProduto CarregarModeloProduto(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.CarregaModeloProduto(codigo);
        }
    }
}
