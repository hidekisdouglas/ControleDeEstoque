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
    public partial class frmCadastroUnidadeDeMedida : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroUnidadeDeMedida()
        {
            InitializeComponent();
        }
        public void limpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaUnidadeDeMedida f = new frmConsultaUnidadeDeMedida();
            f.ShowDialog();
            if (f.codigo !=0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cx);
                ModeloUnidadeDeMedida modelo = bll.CarregarModeloUnidadeDeMedida(f.codigo);
                txtCodigo.Text = modelo.UmedCod.ToString();
                txtNome.Text = modelo.UmedNome;
                alteraBotoes(3);
            }
            else
            {
                this.alteraBotoes(1);
            }
            f.Dispose();
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.alteraBotoes(2);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.limpaTela();
            this.alteraBotoes(1);
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura de dados
                ModeloUnidadeDeMedida modelo = new ModeloUnidadeDeMedida();
                modelo.UmedNome = txtNome.Text;
                // obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cx);

                if (this.operacao == "inserir")
                {
                    //cadastrar uma categoria
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado com sucesso! O código da Unidade de Medida é: " + modelo.UmedCod.ToString());

                }
                else
                {
                    //alterar uma categoria
                    modelo.UmedCod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro atualizado com sucesso!");
                }
                this.limpaTela();
                this.alteraBotoes(1);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura de dados
                DialogResult d = MessageBox.Show("Deseja excluir a Unidade de Medida?", "Aviso", MessageBoxButtons.YesNo);

                if (d.ToString() == "Yes")
                {
                    // obj para gravar os dados no banco
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.limpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Não é possível excluir a Unidade de Medida! \n A unidade de medida está sendo utilizada em outro local.");
                this.alteraBotoes(3);
            }
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (this.operacao == "inserir")
            {
                int r = 0;
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cx);
                r = bll.VerificaUnidadeDeMedida(txtNome.Text);
                if (r > 0)
                {
                        //leitura de dados
                        DialogResult d = MessageBox.Show("Já existe um registro com esse nome. Deseja alterar o registro?", "Aviso", MessageBoxButtons.YesNo);
                        if (d.ToString() == "Yes")
                        {
                        this.operacao = "alterar";
                        ModeloUnidadeDeMedida modelo = bll.CarregarModeloUnidadeDeMedida(r);
                        txtCodigo.Text = modelo.UmedCod.ToString();
                        txtNome.Text = modelo.UmedNome;
                        //alteraBotoes(3);
                    }
                }

            }
        }
    }
}
