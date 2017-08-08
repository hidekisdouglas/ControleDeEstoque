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
    public class DALTipoPagamento
    {
        private DALConexao conexao;
        //Construtor
        public DALTipoPagamento(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloTipoDePagamento modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "insert into tipopagamento(tpa_nome) values (@nome); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", modelo.TpaNome);
            conexao.Connectar();
            modelo.TpaCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void Alterar(ModeloTipoDePagamento modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "update tipopagamento set tpa_nome = @nome where tpa_cod = @codigo";
            cmd.Parameters.AddWithValue("@nome", modelo.TpaNome);
            cmd.Parameters.AddWithValue("@codigo", modelo.TpaCod);
            conexao.Connectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "delete from tipopagamento where tpa_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Connectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tipopagamento where tpa_nome like '%" + valor + "%'", conexao.stringConexao);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloTipoDePagamento CarregaModeloTipoPagamento(int codigo)
        {
            ModeloTipoDePagamento modelo = new ModeloTipoDePagamento();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = ("select * from tipopagamento where tpa_cod = @codigo");
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Connectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.TpaCod = Convert.ToInt32(registro["tpa_cod"]);
                modelo.TpaNome = Convert.ToString(registro["tpa_nome"]);
            }
            conexao.Desconectar();
            return modelo;
        }

    }
}
