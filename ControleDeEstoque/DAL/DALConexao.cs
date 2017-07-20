﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DALConexao
    {
            private String _stringConexao;
            private SqlConnection _conexao;
    

        //Construtor
        public DALConexao(string dadosConexao)
        {
            this._conexao = new SqlConnection();
            this._stringConexao = dadosConexao;
            this._conexao.ConnectionString = dadosConexao;
        }

        public String stringConexao
        {
            get { return this._stringConexao; }
            set { this._stringConexao = value; }
        }
        public SqlConnection ObjetoConexao
        {
            get { return this._conexao; }
            set { this._conexao = value; }
        }
        public void Connectar()
        {
            this._conexao.Open();
        }
        public void Desconectar()
        {
            this._conexao.Close();
        }

    }
}
