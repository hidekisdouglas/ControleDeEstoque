using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALCompra
    {
        private DALConexao conexao;
        //Construtor
        public DALCompra(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloCompra modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "insert into compra(com_data, com_nfiscal, com_nparcelas, " +
                "com_total, com_status, for_cod, tpa_cod) values (@com_data, @com_nfiscal, @com_nparcelas, @com_status, @for_cod, @tpa_cod); select @@IDENTITY;";
            cmd.Parameters.Add("@com_data", System.Data.SqlDbType.DateTime);
            cmd.Parameters["@com_data"].Value = modelo.ComData;
            cmd.Parameters.AddWithValue("@com_nfiscal", modelo.ComNFiscal);
            cmd.Parameters.AddWithValue("@com_nparcelas", modelo.ComNParcela);
            cmd.Parameters.AddWithValue("@com_nfiscal", modelo.ComNFiscal);
            cmd.Parameters.AddWithValue("@com_total", modelo.ComTotal);
            cmd.Parameters.AddWithValue("@for_cod", modelo.ForCod);
            cmd.Parameters.AddWithValue("@tpa_cod", modelo.TpaCod);
            conexao.Connectar();
            modelo.ComCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void Alterar(ModeloCompra modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "update compra set " +
                "com_data = @com_data , com_nfiscal = @com_nfiscal, com_nparcelas = @com_nparcelas, " +
                "com_total = @com_total, com_status = @com_status, for_cod = @for_cod, tpa_cod = @tpa_cod  where com_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", modelo.ComCod);
            cmd.Parameters.Add("@com_data", System.Data.SqlDbType.DateTime);
            cmd.Parameters["@com_data"].Value = modelo.ComData;
            cmd.Parameters.AddWithValue("@com_nfiscal", modelo.ComNFiscal);
            cmd.Parameters.AddWithValue("@com_nparcelas", modelo.ComNParcela);
            cmd.Parameters.AddWithValue("@com_nfiscal", modelo.ComNFiscal);
            cmd.Parameters.AddWithValue("@com_total", modelo.ComTotal);
            cmd.Parameters.AddWithValue("@for_cod", modelo.ForCod);
            cmd.Parameters.AddWithValue("@tpa_cod", modelo.TpaCod);
            conexao.Connectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "delete from compra where com_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Connectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from compra where cat_nome like '%" + valor + "%'", conexao.stringConexao);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloCompra CarregaModeloCompra(int codigo)
        {
            ModeloCompra modelo = new ModeloCompra();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = ("select * from categoria where cat_cod = @codigo");
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Connectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.CatCod = Convert.ToInt32(registro["cat_cod"]);
                modelo.CatNome = Convert.ToString(registro["cat_nome"]);
            }
            conexao.Desconectar();
            return modelo;
        }

    }
}
