using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public class BLLSubcategoria
    {
        private DALConexao conexao;

       public BLLSubcategoria(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloSubCategoria modelo)
        {
            if (modelo.ScatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da subcategoria é obrigatório");
            }
            if (modelo.CatCod <=0)
            {
                throw new Exception("O código da categoria é obrigatório");
            }
            modelo.ScatNome = modelo.ScatNome.ToUpper();
            DALSubcategoria DALobj = new DALSubcategoria(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloSubCategoria modelo)
        {
            if (modelo.ScatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da subcategoria é obrigatório");
            }
            if (modelo.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatório");
            }

            if (modelo.ScatCod <= 0)
            {
                throw new Exception("O código da subcategoria é obrigatório");
            }
            

            modelo.ScatNome = modelo.ScatNome.ToUpper();
            DALSubcategoria DALobj = new DALSubcategoria(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALSubcategoria DALobj = new DALSubcategoria(conexao);
            DALobj.Excluir(codigo);
        }
        public DataTable Localizar(String valor)
        {
            DALSubcategoria DALobj = new DALSubcategoria(conexao);
            return DALobj.Localizar(valor);
        }
        public ModeloSubCategoria CarregarModeloSubCategoria(int codigo)
        {
            DALSubcategoria DALobj = new DALSubcategoria(conexao);
            return DALobj.CarregaModeloSubCategoria(codigo);
        }
    }
}
