using BLL;
using DAL;
using Ferramentas;
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
    public partial class frmCadastroFornecedor : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroFornecedor()
        {
            InitializeComponent();
        }
        public enum Campo
        {
            CPF = 1,
            CNPJ = 2,
            CEP = 3
        }
        public void Formatar(Campo Valor, TextBox txtCpfCnpj)
        {
            switch (Valor)
            {
                case Campo.CPF:
                    txtCpfCnpj.MaxLength = 14;
                    if (txtCpfCnpj.Text.Length == 3)
                    {
                        txtCpfCnpj.Text = txtCpfCnpj.Text + ".";
                        txtCpfCnpj.SelectionStart = txtCpfCnpj.Text.Length + 1;
                    }
                    else if (txtCpfCnpj.Text.Length == 7)
                    {
                        txtCpfCnpj.Text = txtCpfCnpj.Text + ".";
                        txtCpfCnpj.SelectionStart = txtCpfCnpj.Text.Length + 1;
                    }
                    else if (txtCpfCnpj.Text.Length == 11)
                    {
                        txtCpfCnpj.Text = txtCpfCnpj.Text + "-";
                        txtCpfCnpj.SelectionStart = txtCpfCnpj.Text.Length + 1;
                    }
                    break;
                case Campo.CNPJ:
                    txtCpfCnpj.MaxLength = 18;
                    if (txtCpfCnpj.Text.Length == 2 || txtCpfCnpj.Text.Length == 6)
                    {
                        txtCpfCnpj.Text = txtCpfCnpj.Text + ".";
                        txtCpfCnpj.SelectionStart = txtCpfCnpj.Text.Length + 1;
                    }
                    else if (txtCpfCnpj.Text.Length == 10)
                    {
                        txtCpfCnpj.Text = txtCpfCnpj.Text + "/";
                        txtCpfCnpj.SelectionStart = txtCpfCnpj.Text.Length + 1;
                    }
                    else if (txtCpfCnpj.Text.Length == 15)
                    {
                        txtCpfCnpj.Text = txtCpfCnpj.Text + "-";
                        txtCpfCnpj.SelectionStart = txtCpfCnpj.Text.Length + 1;
                    }
                    break;
                case Campo.CEP:
                    txtCep.MaxLength = 9;
                    if (txtCpfCnpj.Text.Length == 5)
                    {
                        txtCpfCnpj.Text = txtCpfCnpj.Text + "-";
                        txtCpfCnpj.SelectionStart = txtCpfCnpj.Text.Length + 1;
                    }
                    break;
            }
        }
            public void limpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtRazaoSocial.Clear();
            txtRgIe.Clear(); ;
            txtCpfCnpj.Clear();
            txtEmail.Clear();
            txtTel.Clear();
            txtCel.Clear();
            txtCep.Clear();
            txtBairro.Clear();
            txtEstado.Clear();
            txtCidade.Clear();
            txtEnd.Clear();
            txtEndNumero.Clear();
            
        }

        private void frmCadastroFornecedor_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
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

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura de dados
                DialogResult d = MessageBox.Show("Deseja excluir o fornecedor?", "Aviso", MessageBoxButtons.YesNo);

                if (d.ToString() == "Yes")
                {
                    // obj para gravar os dados no banco
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLFornecedor bll = new BLLFornecedor(cx);
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

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaFornecedor f = new frmConsultaFornecedor();
            // obj para gravar os dados no banco
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLFornecedor bll = new BLLFornecedor(cx);
            //exibe o frmConsultaCategoria para seleção da alteração
            f.ShowDialog();
            //verifica se foi armazenado uma categoria no frmConsultaCategoria
            if (f.codigo != 0)
            {
                ModeloFornecedor modelo = bll.CarregarModeloFornecedor(f.codigo);
                txtCodigo.Text = modelo.ForCod.ToString();
                txtNome.Text = modelo.ForNome;
                txtRazaoSocial.Text = modelo.ForRsocial;
                txtCpfCnpj.Text = modelo.ForCnpj;
                txtRgIe.Text = modelo.ForIe;
                txtEmail.Text = modelo.ForEmail;
                txtTel.Text = modelo.ForFone;
                txtCel.Text = modelo.ForCel;
                txtCep.Text = modelo.ForCep;
                txtBairro.Text = modelo.ForBairro;
                txtEnd.Text = modelo.ForEndereco;
                txtEndNumero.Text = modelo.ForEndNumero;
                txtCidade.Text = modelo.ForCidade;
                txtEstado.Text = modelo.ForEstado;
                alteraBotoes(3);
            }
            else
            {
                this.limpaTela();
                this.alteraBotoes(1);
            }
            f.Dispose();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura de dados
                ModeloFornecedor modelo = new ModeloFornecedor();
                modelo.ForNome = txtNome.Text;
                modelo.ForRsocial = txtRazaoSocial.Text;
                modelo.ForCnpj = txtCpfCnpj.Text;
                modelo.ForIe = txtRgIe.Text;
                modelo.ForFone = txtTel.Text;
                modelo.ForEmail = txtEmail.Text;
                modelo.ForCel = txtCel.Text;
                modelo.ForCep = txtCep.Text;
                modelo.ForBairro = txtBairro.Text;
                modelo.ForEstado = txtEstado.Text;
                modelo.ForCidade = txtCidade.Text;
                modelo.ForEndereco = txtEnd.Text;
                modelo.ForEndNumero = txtEndNumero.Text;

                // obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLFornecedor bll = new BLLFornecedor(cx);

                if (this.operacao == "inserir")
                {
                    //cadastrar um fornecedor
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado com sucesso! O código do fornecedor é: " + modelo.ForCod.ToString());

                }
                else
                {
                    //alterar um fornecedor
                    modelo.ForCod = Convert.ToInt32(txtCodigo.Text);
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

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.alteraBotoes(2);
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            //Valida CEP
            if (Validacao.ValidaCep(txtCep.Text) == false)
            {
                MessageBox.Show("O CEP é inválido");
                txtBairro.Clear();
                txtEstado.Clear();
                txtCidade.Clear();
                txtEnd.Clear();
            }
            else
            {
                if (BuscaEndereco.verificaCEP(txtCep.Text) == true)
                {
                    txtBairro.Text = BuscaEndereco.bairro;
                    txtEstado.Text = BuscaEndereco.estado;
                    txtCidade.Text = BuscaEndereco.cidade;
                    txtEnd.Text = BuscaEndereco.endereco;
                }
            }
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8)
            {
                Campo edit = Campo.CEP;
                Formatar(edit, txtCep);
            }
        }

        private void txtCpfCnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8)
            {
                Campo edit = Campo.CPF;
                edit = Campo.CNPJ;
                Formatar(edit, txtCpfCnpj);
            }
        }

        private void txtCpfCnpj_Leave(object sender, EventArgs e)
        {
            lbValorIncorreto.Visible = false;
            
                if (Validacao.IsCnpj(txtCpfCnpj.Text) == false)
                {
                    lbValorIncorreto.Visible = true;
                }
            
        }
    }
}
