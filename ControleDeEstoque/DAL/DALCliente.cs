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
    public class DALCliente
    {
        private DALConexao conexao;
        //Construtor
        public DALCliente(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloCliente modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "insert into cliente(cli_cod, cli_nome, cli_cpfcnpj, cli_rgie, cli_rsocial, cli_tipo, cli_cep, cli_endereco, cli_endnumero, cli_bairro, " +
                " cli_fone, cli_cel, cli_email, cli_cidade, cli_estado) " +
                " values (@cli_cod, @cli_nome, @cli_cpfcnpj, @cli_rgie, @cli_rsocial, @cli_tipo, @cli_cep, @cli_endereco, cli_endnumero, cli_bairro, " +
                " @cli_fone, @cli_cel, @cli_email, @cli_cidade, @cli_estado); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@cli_nome", modelo.CliNome);
            cmd.Parameters.AddWithValue("@cli_cpfcnpj", modelo.CliCpfCnpj);
            cmd.Parameters.AddWithValue("@cli_rgie", modelo.CliRgIe);
            cmd.Parameters.AddWithValue("@cli_rsocial", modelo.CliRsocial);
            cmd.Parameters.AddWithValue("@cli_tipo", modelo.CliTipo);
            cmd.Parameters.AddWithValue("@cli_cep", modelo.CliCep);
            cmd.Parameters.AddWithValue("@cli_endereco", modelo.CliEndereco);
            cmd.Parameters.AddWithValue("@cli_endnumero", modelo.CliEndNumero);
            cmd.Parameters.AddWithValue("@cli_bairro", modelo.CliBairro);
            cmd.Parameters.AddWithValue("@cli_fone", modelo.CliFone);
            cmd.Parameters.AddWithValue("@cli_cel", modelo.CliCel);
            cmd.Parameters.AddWithValue("@cli_email", modelo.CliEmail);
            cmd.Parameters.AddWithValue("@cli_cidade", modelo.CliCidade);
            cmd.Parameters.AddWithValue("@cli_estado", modelo.CliEstado);
            conexao.Connectar();
            modelo.CliCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void Alterar(ModeloCliente modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "update cliente set cli_nome = @cli_nome, cli_cpfcnpj = @cli_cpfcnpj, cli_rgie = @cli_rgie, cli_rsocial = @cli_rsocial, cli_tipo = @cli_tipo," +
                " cli_cep = @cli_cep, cli_endereco = @cli_endereco, cli_endnumero  = @cli_endnumero, cli_bairro = @cli_bairro, " +
                " cli_fone = @cli_fone, cli_cel = @cli_cel, cli_email = @cli_email, cli_cidade = @cli_cidade, cli_estado = @cli_estado  where cli_cod = @cli_cod";
            cmd.Parameters.AddWithValue("@cli_cod", modelo.CliCod);
            cmd.Parameters.AddWithValue("@cli_nome", modelo.CliNome);
            cmd.Parameters.AddWithValue("@cli_cpfcnpj", modelo.CliCpfCnpj);
            cmd.Parameters.AddWithValue("@cli_rgie", modelo.CliRgIe);
            cmd.Parameters.AddWithValue("@cli_rsocial", modelo.CliRsocial);
            cmd.Parameters.AddWithValue("@cli_tipo", modelo.CliTipo);
            cmd.Parameters.AddWithValue("@cli_cep", modelo.CliCep);
            cmd.Parameters.AddWithValue("@cli_endereco", modelo.CliEndereco);
            cmd.Parameters.AddWithValue("@cli_endnumero", modelo.CliEndNumero);
            cmd.Parameters.AddWithValue("@cli_bairro", modelo.CliBairro);
            cmd.Parameters.AddWithValue("@cli_fone", modelo.CliFone);
            cmd.Parameters.AddWithValue("@cli_cel", modelo.CliCel);
            cmd.Parameters.AddWithValue("@cli_email", modelo.CliEmail);
            cmd.Parameters.AddWithValue("@cli_cidade", modelo.CliCidade);
            cmd.Parameters.AddWithValue("@cli_estado", modelo.CliEstado);
            conexao.Connectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;

            cmd.CommandText = "delete from cliente where cli_cod = @cli_cod";
            cmd.Parameters.AddWithValue("@cli_cod", codigo);
            conexao.Connectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable LocalizarNome(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from cliente where cli_nome like '%" + valor + "%'", conexao.stringConexao);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloCliente CarregaModeloCliente(int codigo)
        {
            ModeloCliente modelo = new ModeloCliente();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = ("select * from cliente where cli_cod = @cli_cod");
            cmd.Parameters.AddWithValue("@cli_cod", codigo);
            conexao.Connectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.CliCod = Convert.ToInt32(registro["cli_cod"]);
                modelo.CliNome = Convert.ToString(registro["cli_nome"]);
                modelo.CliCpfCnpj = Convert.ToString(registro["cli_cpfcnpj"]);
                modelo.CliRgIe = Convert.ToString(registro["cli_rgie"]);
                modelo.CliRsocial = Convert.ToString(registro["cli_rsocial"]);
                modelo.CliTipo = Convert.ToInt32(registro["cli_tipo"]);
                modelo.CliCep = Convert.ToString(registro["cli_cep"]);
                modelo.CliEndereco = Convert.ToString(registro["cli_endereco"]);
                modelo.CliEndNumero = Convert.ToString(registro["cli_endnumero"]);
                modelo.CliBairro = Convert.ToString(registro["cli_bairro"]);
                modelo.CliFone = Convert.ToString(registro["cli_fone"]);
                modelo.CliCel = Convert.ToString(registro["cli_cel"]);
                modelo.CliEmail = Convert.ToString(registro["cli_email"]);
                modelo.CliCidade = Convert.ToString(registro["cli_cidade"]);
                modelo.CliEstado = Convert.ToString(registro["cli_estado"]);
            }
            conexao.Desconectar();
            return modelo;
        }
        public ModeloCliente CarregaModeloCliente(string cpfcnpj)
        {
            ModeloCliente modelo = new ModeloCliente();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = ("select * from cliente where cli_cpfcnpj = @cli_cpfcnpj");
            cmd.Parameters.AddWithValue("@cli_cpfcnpj", cpfcnpj);
            conexao.Connectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.CliCod = Convert.ToInt32(registro["cli_cod"]);
                modelo.CliNome = Convert.ToString(registro["cli_nome"]);
                modelo.CliCpfCnpj = Convert.ToString(registro["cli_cpfcnpj"]);
                modelo.CliRgIe = Convert.ToString(registro["cli_rgie"]);
                modelo.CliRsocial = Convert.ToString(registro["cli_rsocial"]);
                modelo.CliTipo = Convert.ToInt32(registro["cli_tipo"]);
                modelo.CliCep = Convert.ToString(registro["cli_cep"]);
                modelo.CliEndereco = Convert.ToString(registro["cli_endereco"]);
                modelo.CliEndNumero = Convert.ToString(registro["cli_endnumero"]);
                modelo.CliBairro = Convert.ToString(registro["cli_bairro"]);
                modelo.CliFone = Convert.ToString(registro["cli_fone"]);
                modelo.CliCel = Convert.ToString(registro["cli_cel"]);
                modelo.CliEmail = Convert.ToString(registro["cli_email"]);
                modelo.CliCidade = Convert.ToString(registro["cli_cidade"]);
                modelo.CliEstado = Convert.ToString(registro["cli_estado"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
