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
    public class DALFornecedor
    {
        private DALConexao conexao;
        //Construtor
        public DALFornecedor(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloFornecedor modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "insert into fornecedor( for_nome, for_cnpj, for_ie, for_rsocial, for_cep, for_endereco, for_endnumero, for_bairro, " +
                " for_fone, for_cel, for_email, for_cidade, for_estado) " +
                " values (@for_nome, @for_cnpj, @for_ie, @for_rsocial, @for_cep, @for_endereco, @for_endnumero, @for_bairro, " +
                " @for_fone, @for_cel, @for_email, @for_cidade, @for_estado); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@for_nome", modelo.ForNome);
            cmd.Parameters.AddWithValue("@for_cnpj", modelo.ForCnpj);
            cmd.Parameters.AddWithValue("@for_ie", modelo.ForIe);
            cmd.Parameters.AddWithValue("@for_rsocial", modelo.ForRsocial);
            cmd.Parameters.AddWithValue("@for_cep", modelo.ForCep);
            cmd.Parameters.AddWithValue("@for_endereco", modelo.ForEndereco);
            cmd.Parameters.AddWithValue("@for_endnumero", modelo.ForEndNumero);
            cmd.Parameters.AddWithValue("@for_bairro", modelo.ForBairro);
            cmd.Parameters.AddWithValue("@for_fone", modelo.ForFone);
            cmd.Parameters.AddWithValue("@for_cel", modelo.ForCel);
            cmd.Parameters.AddWithValue("@for_email", modelo.ForEmail);
            cmd.Parameters.AddWithValue("@for_cidade", modelo.ForCidade);
            cmd.Parameters.AddWithValue("@for_estado", modelo.ForEstado);

            conexao.Connectar();
            modelo.ForCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void Alterar(ModeloFornecedor modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "update fornecedor set for_nome = @for_nome, for_cnpj = @for_cnpj, for_ie = @for_ie, for_rsocial = @for_rsocial," +
                " for_cep = @for_cep, for_endereco = @for_endereco, for_endnumero  = @for_endnumero, for_bairro = @for_bairro, " +
                " for_fone = @for_fone, for_cel = @for_cel, for_email = @for_email, for_cidade = @for_cidade, for_estado = @for_estado  where for_cod = @for_cod";
            cmd.Parameters.AddWithValue("@for_cod", modelo.ForCod);
            cmd.Parameters.AddWithValue("@for_nome", modelo.ForNome);
            cmd.Parameters.AddWithValue("@for_cnpj", modelo.ForCnpj);
            cmd.Parameters.AddWithValue("@for_ie", modelo.ForIe);
            cmd.Parameters.AddWithValue("@for_rsocial", modelo.ForRsocial);
            cmd.Parameters.AddWithValue("@for_cep", modelo.ForCep);
            cmd.Parameters.AddWithValue("@for_endereco", modelo.ForEndereco);
            cmd.Parameters.AddWithValue("@for_endnumero", modelo.ForEndNumero);
            cmd.Parameters.AddWithValue("@for_bairro", modelo.ForBairro);
            cmd.Parameters.AddWithValue("@for_fone", modelo.ForFone);
            cmd.Parameters.AddWithValue("@for_cel", modelo.ForCel);
            cmd.Parameters.AddWithValue("@for_email", modelo.ForEmail);
            cmd.Parameters.AddWithValue("@for_cidade", modelo.ForCidade);
            cmd.Parameters.AddWithValue("@for_estado", modelo.ForEstado);
            conexao.Connectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "delete from fornecedor where for_cod = @for_cod";
            cmd.Parameters.AddWithValue("@for_cod", codigo);
            conexao.Connectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable LocalizarNome(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from fornecedor where for_nome like '%" + valor + "%'", conexao.stringConexao);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarCNPJ(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from fornecedor where for_cnpj like '%" + valor + "%'", conexao.stringConexao);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloFornecedor CarregaModeloFornecedor(int codigo)
        {
            ModeloFornecedor modelo = new ModeloFornecedor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = ("select * from fornecedor where for_cod = @for_cod");
            cmd.Parameters.AddWithValue("@for_cod", codigo);
            conexao.Connectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.ForCod = Convert.ToInt32(registro["for_cod"]);
                modelo.ForNome = Convert.ToString(registro["for_nome"]);
                modelo.ForCnpj = Convert.ToString(registro["for_cnpj"]);
                modelo.ForIe = Convert.ToString(registro["for_ie"]);
                modelo.ForRsocial = Convert.ToString(registro["for_rsocial"]);
                modelo.ForCep = Convert.ToString(registro["for_cep"]);
                modelo.ForEndereco = Convert.ToString(registro["for_endereco"]);
                modelo.ForEndNumero = Convert.ToString(registro["for_endnumero"]);
                modelo.ForBairro = Convert.ToString(registro["for_bairro"]);
                modelo.ForFone = Convert.ToString(registro["for_fone"]);
                modelo.ForCel = Convert.ToString(registro["for_cel"]);
                modelo.ForEmail = Convert.ToString(registro["for_email"]);
                modelo.ForCidade = Convert.ToString(registro["for_cidade"]);
                modelo.ForEstado = Convert.ToString(registro["for_estado"]);
            }
            conexao.Desconectar();
            return modelo;
        }
        public ModeloFornecedor CarregaModeloFornecedor(string cnpj)
        {
            ModeloFornecedor modelo = new ModeloFornecedor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = ("select * from fornecedor where for_cnpj = @for_cnpj");
            cmd.Parameters.AddWithValue("@for_cnpj", cnpj);
            conexao.Connectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.ForCod = Convert.ToInt32(registro["for_cod"]);
                modelo.ForNome = Convert.ToString(registro["for_nome"]);
                modelo.ForCnpj = Convert.ToString(registro["for_cnpj"]);
                modelo.ForIe = Convert.ToString(registro["for_ie"]);
                modelo.ForRsocial = Convert.ToString(registro["for_rsocial"]);
                modelo.ForCep = Convert.ToString(registro["for_cep"]);
                modelo.ForEndereco = Convert.ToString(registro["for_endereco"]);
                modelo.ForEndNumero = Convert.ToString(registro["for_endnumero"]);
                modelo.ForBairro = Convert.ToString(registro["for_bairro"]);
                modelo.ForFone = Convert.ToString(registro["for_fone"]);
                modelo.ForCel = Convert.ToString(registro["for_cel"]);
                modelo.ForEmail = Convert.ToString(registro["for_email"]);
                modelo.ForCidade = Convert.ToString(registro["for_cidade"]);
                modelo.ForEstado = Convert.ToString(registro["for_estado"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
