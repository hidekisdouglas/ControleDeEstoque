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
    public partial class frmProduto : GUI.frmModeloDeFormularioDeCadastro
    {
        public string foto = "";

        public frmProduto()
        {
            InitializeComponent();
        }
        public void limpaTela()
        {
            txtCodigo.Clear();
            txtProduto.Clear();
            txtDescricao.Clear();
            txtQtde.Clear();
            txtValorPago.Clear();
            txtValorVenda.Clear();
            
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            //criar conexão para exibir no combobox os nomes da categoria
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bll = new BLLCategoria(cx);
            cbCategoria.DataSource = bll.Localizar("");
            cbCategoria.DisplayMember = "cat_nome";
            cbCategoria.ValueMember = "cat_cod";
            try
            {
                //criar conexão para exibir no combobox os nomes da subcategoria
                BLLSubcategoria sbll = new BLLSubcategoria(cx);
                cbSubCategoria.DataSource = sbll.LocalizaPorCategoria((int)cbCategoria.SelectedValue);
                cbSubCategoria.DisplayMember = "scat_nome";
                cbSubCategoria.ValueMember = "scat_cod";
            }
            catch
            {
                MessageBox.Show("Cadastre uma cegoria");
            }
            
            //criar conexão para exibir no combobox os nomes da unidade de medidas
            BLLUnidadeDeMedida ubll = new BLLUnidadeDeMedida(cx);
            cbUnidadeDeMedida.DataSource = ubll.Localizar("");
            cbUnidadeDeMedida.DisplayMember = "umed_nome";
            cbUnidadeDeMedida.ValueMember = "umed_cod";
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorPago.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
           
        }

        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            if (txtValorPago.Text.Contains(".") == false)
            {
                txtValorPago.Text += ".00";
            }
            else
            {
                if (txtValorPago.Text.IndexOf(".") == txtValorPago.Text.Length -1)
                {
                    txtValorPago.Text += "00";
                }
            }
            try
            {
                double d = Convert.ToDouble(txtValorPago.Text);
            }
            catch
            {
                txtValorPago.Text = "0.00";
            }
        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorVenda.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            if (txtValorVenda.Text.Contains(".") == false)
            {
                txtValorVenda.Text += ".00";
            }
            else
            {
                if (txtValorVenda.Text.IndexOf(".") == txtValorVenda.Text.Length - 1)
                {
                    txtValorVenda.Text += "00";
                }
            }
            try
            {
                double d = Convert.ToDouble(txtValorVenda.Text);
            }
            catch
            {
                txtValorVenda.Text = "0.00";
            }
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtQtde.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        private void txtQtde_Leave(object sender, EventArgs e)
        {
            if (txtQtde.Text.Contains(".") == false)
            {
                txtQtde.Text += ".00";
            }
            else
            {
                if (txtQtde.Text.IndexOf(".") == txtQtde.Text.Length - 1)
                {
                    txtQtde.Text += "00";
                }
            }
            try
            {
                double d = Convert.ToDouble(txtQtde.Text);
            }
            catch
            {
                txtQtde.Text = "0.00";
            }
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
                DialogResult d = MessageBox.Show("Deseja excluir o produto?", "Aviso", MessageBoxButtons.YesNo);

                if (d.ToString() == "Yes")
                {
                    // obj para gravar os dados no banco
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLProduto bll = new BLLProduto(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.limpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Não é possível excluir a categoria! \n A categoria está sendo utilizada em outro local.");
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
                ModeloProduto modelo = new ModeloProduto();
                modelo.ProNome = txtProduto.Text;
                // obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLProduto bll = new BLLProduto(cx);

                if (this.operacao == "inserir")
                {
                    //cadastrar uma categoria
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado com sucesso! O código do produto é: " + modelo.ProCod.ToString());

                }
                else
                {
                    //alterar uma categoria
                    modelo.ProCod = Convert.ToInt32(txtCodigo.Text);
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
            frmConsultaCategoria f = new frmConsultaCategoria();
            // obj para gravar os dados no banco
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLProduto bll = new BLLProduto(cx);
            //exibe o frmConsultaProduto para seleção da alteração
            f.ShowDialog();
            //verifica se foi armazenado uma categoria no frmConsultaCategoria
            if (f.codigo != 0)
            {
                ModeloProduto modelo = bll.CarregarModeloProduto(f.codigo);
                txtCodigo.Text = modelo.ProCod.ToString();
                txtProduto.Text = modelo.ProNome;
                alteraBotoes(3);
            }
            else
            {
                this.limpaTela();
                this.alteraBotoes(1);
            }
            f.Dispose();

        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //criar conexão para exibir no combobox os nomes da categoria
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            try
            {
                cbSubCategoria.Text = "";
                //criar conexão para exibir no combobox os nomes da subcategoria
                BLLSubcategoria sbll = new BLLSubcategoria(cx);
                cbSubCategoria.DataSource = sbll.LocalizaPorCategoria((int)cbCategoria.SelectedValue);
                cbSubCategoria.DisplayMember = "scat_nome";
                cbSubCategoria.ValueMember = "scat_cod";
            }
            catch
            {
               // MessageBox.Show("Cadastre uma cegoria");
            }
        }
    }
}
