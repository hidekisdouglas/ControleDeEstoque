using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroSubCategoria : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroSubCategoria()
        {
            InitializeComponent();
        }
        public void limpaTela()
        {
            txtSCod.Clear();
            txtNomeSubcategoria.Clear();
        }

        private void frmCadastroSubCategoria_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            //criar conexão para exibir no combobox os nomes da categoria
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bll = new BLLCategoria(cx);
            cbNomeCategoria.DataSource = bll.Localizar("");
            cbNomeCategoria.DisplayMember = "cat_nome";
            cbNomeCategoria.ValueMember = "cat_cod";
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

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura de dados
                DialogResult d = MessageBox.Show("Deseja excluir a subcategoria?", "Aviso", MessageBoxButtons.YesNo);

                if (d.ToString() == "Yes")
                {
                    // obj para gravar os dados no banco
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLSubcategoria bll = new BLLSubcategoria(cx);
                    bll.Excluir(Convert.ToInt32(txtSCod.Text));
                    this.limpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Não é possível excluir a subcategoria! \n A subcategoria está sendo utilizada em outro local.");
                this.alteraBotoes(3);
            }
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
                ModeloSubCategoria modelo = new ModeloSubCategoria();
                modelo.ScatNome = txtNomeSubcategoria.Text;
                modelo.CatCod = Convert.ToInt32(cbNomeCategoria.SelectedValue);
                // obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLSubcategoria bll = new BLLSubcategoria(cx);

                if (this.operacao == "inserir")
                {
                    //cadastrar uma subcategoria
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado com sucesso! \n O código da subcategoria é: " + modelo.ScatCod.ToString());

                }
                else
                {
                    //alterar uma subcategoria
                    modelo.ScatCod = Convert.ToInt32(txtSCod.Text);
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

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaSubCategoria f = new frmConsultaSubCategoria();
            // obj para gravar os dados no banco
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLSubcategoria bll = new BLLSubcategoria(cx);
            //exibe o frmConsultaCategoria para seleção da alteração
            f.ShowDialog();
            //verifica se foi armazenado uma categoria no frmConsultaCategoria
            if (f.codigo != 0)
            {
                ModeloSubCategoria modelo = bll.CarregarModeloSubCategoria(f.codigo);
                txtSCod.Text = modelo.ScatCod.ToString();
                txtNomeSubcategoria.Text = modelo.ScatNome;
                cbNomeCategoria.SelectedValue = modelo.CatCod;
                alteraBotoes(3);
            }
            else
            {
                this.limpaTela();
                this.alteraBotoes(1);
            }
            f.Dispose();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmCadastroCategoria f = new frmCadastroCategoria();
            f.ShowDialog();
            f.Dispose();
            //carrega as categorias atualizadas
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bll = new BLLCategoria(cx);
            cbNomeCategoria.DataSource = bll.Localizar("");
            cbNomeCategoria.DisplayMember = "cat_nome";
            cbNomeCategoria.ValueMember = "cat_cod";
        }
    }
}
