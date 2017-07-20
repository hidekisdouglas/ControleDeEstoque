using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelo;
using DAL;
using BLL;

namespace GUI
{
    public partial class frmCadastroCategoria : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroCategoria()
        {
            InitializeComponent();
        }
        public void limpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.limpaTela();
            this.alteraBotoes(1);
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            //leitura de dados
            ModeloCategoria modelo = new ModeloCategoria();
            modelo.CatNome = txtNome.Text;
            // obj para gravar os dados no banco
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bll = new BLLCategoria(cx);

            if (this.operacao == "inserir")
            {
                //cadastrar uma categoria
                bll.Incluir(modelo);
                
            }
            else
            {
                //alterar uma categoria
                modelo.CatCod = Convert.ToInt32(txtCodigo.Text);
                bll.Alterar(modelo);
            }
        }
    }
}
