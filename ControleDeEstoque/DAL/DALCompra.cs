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
        //Localizar por fornecedor
        public DataTable Localizar(int codigo)
        {
            DataTable tabela = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("select * from compra where for_cod = " + codigo.ToString() , conexao.stringConexao);
            SqlDataAdapter da = new SqlDataAdapter("select c.com_cod, c.com_data, c.com_nfiscal, c.com_nparcelas, c.com_total, c.com_status, c.for_cod, c.tpa_cod," +
                " f.for_nome from compra c inner join fornecedor f on c.for_cod = f.for_cod where f.for_cod = " + codigo.ToString(), conexao.stringConexao);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarPorNomeFornecedor(String nome)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select c.com_cod, c.com_data, c.com_nfiscal, c.com_nparcelas, c.com_total, c.com_status, c.for_cod, c.tpa_cod," +
                " f.for_nome from compra c inner join fornecedor f on c.for_cod = f.for_cod where f.for_nome like '%" + nome + "%'", conexao.stringConexao);
            da.Fill(tabela);
            return tabela;
        }
        //localizar por data
        public DataTable Localizar(DateTime dtInicial, DateTime dtFinal)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "select c.com_cod, c.com_data, c.com_nfiscal, c.com_nparcelas, c.com_total, c.com_status, c.for_cod, c.tpa_cod," +
                " f.for_nome from compra c inner join fornecedor f on c.for_cod = f.for_cod where c.com_data between @dtInicial and @dtFinal";
            cmd.Parameters.Add("@dtInicial", System.Data.SqlDbType.DateTime);
            cmd.Parameters["@dtInicial"].Value = dtInicial;
            cmd.CommandText = "select c.com_cod, c.com_data, c.com_nfiscal, c.com_nparcelas, c.com_total, c.com_status, c.for_cod, c.tpa_cod," +
               " f.for_nome from compra c inner join fornecedor f on c.for_cod = f.for_cod where c.com_data between @dtInicial and @dtFinal";
            cmd.Parameters.Add("@dtFinal", System.Data.SqlDbType.DateTime);
            cmd.Parameters["@dtFinal"].Value = dtFinal;
            //conexao.Connectar();
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabela);
            //conexao.Desconectar();
            return tabela;

        }

        public ModeloCompra CarregaModeloCompra(int codigo)
        {
            ModeloCompra modelo = new ModeloCompra();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = ("select * from compra where com_cod = @codigo");
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Connectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.ComCod = Convert.ToInt32(registro["com_cod"]);
                modelo.ComData = Convert.ToDateTime(registro["com_data"]);
                modelo.ComNFiscal = Convert.ToInt32(registro["com_nfiscal"]);
                modelo.ComNParcela = Convert.ToInt32(registro["com_nparcelas"]);
                modelo.ComTotal = Convert.ToDouble(registro["com_total"]);
                modelo.ComStatus = Convert.ToString(registro["com_status"]);
                modelo.ForCod = Convert.ToInt32(registro["for_cod"]);
                modelo.TpaCod = Convert.ToInt32(registro["tpa_cod"]);
                
            }
            conexao.Desconectar();
            return modelo;
        }

    }
}
