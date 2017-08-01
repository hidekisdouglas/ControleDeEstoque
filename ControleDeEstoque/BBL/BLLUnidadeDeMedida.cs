using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLUnidadeDeMedida
    {
        private DALConexao conexao;

        public BLLUnidadeDeMedida(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloUnidadeDeMedida modelo)
        {
            if (modelo.UmedNome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatório");
            }
            modelo.UmedNome = modelo.UmedNome.ToUpper();
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloUnidadeDeMedida modelo)
        {
            if (modelo.UmedCod <= 0)
            {
                throw new Exception("O código da unidade de medida é obrigatório");
            }

            if (modelo.UmedNome.Trim().Length == 0)
            {
                throw new Exception("O nome da unidade de medida é obrigatório");
            }
            modelo.UmedNome = modelo.UmedNome.ToUpper();
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            DALobj.Excluir(codigo);
        }
        public DataTable Localizar(String valor)
        {
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            return DALobj.Localizar(valor);
        }
        public ModeloUnidadeDeMedida CarregarModeloUnidadeDeMedida(int codigo)
        {
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            return DALobj.CarregaModeloUnidadeDeMedida(codigo);
        }
        public int VerificaUnidadeDeMedida(String valor)
        {
            int r = 0;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = ("select * from undmedida where umed_nome = @nome");
            cmd.Parameters.AddWithValue("@nome", valor);
            conexao.Connectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r = Convert.ToInt32(registro["umed_cod"]);

            }
            conexao.Desconectar();
            return r;
        }
    }
}
