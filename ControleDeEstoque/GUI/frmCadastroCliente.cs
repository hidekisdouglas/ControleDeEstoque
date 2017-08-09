﻿using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ferramentas;

namespace GUI
{
    public partial class frmCadastroCliente : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroCliente()
        {
            InitializeComponent();
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
            rbFisica.Checked = true;
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
            try
            {
                //leitura de dados
                ModeloCliente modelo = new ModeloCliente();
                modelo.CliNome = txtNome.Text;
                modelo.CliRsocial = txtRazaoSocial.Text;
                modelo.CliCpfCnpj = txtCpfCnpj.Text;
                modelo.CliRgIe = txtRgIe.Text;
                modelo.CliFone = txtTel.Text;
                modelo.CliEmail = txtEmail.Text;
                modelo.CliCel = txtCel.Text;
                modelo.CliCep = txtCep.Text;
                modelo.CliBairro = txtBairro.Text;
                modelo.CliEstado = txtEstado.Text;
                modelo.CliCidade = txtCidade.Text;
                modelo.CliEndereco = txtEnd.Text;
                modelo.CliEndNumero = txtEndNumero.Text;
                if (rbFisica.Checked == true)
                {
                    modelo.CliTipo = 0; // fisica
                    modelo.CliRsocial = "";
                }
                else
                {
                    modelo.CliTipo = 1; // juridica
                }
                // obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCliente bll = new BLLCliente(cx);

                if (this.operacao == "inserir")
                {
                    //cadastrar um cliente
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado com sucesso! O código do cliente é: " + modelo.CliCod.ToString());

                }
                else
                {
                    //alterar um cliente
                    modelo.CliCod = Convert.ToInt32(txtCodigo.Text);
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

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura de dados
                DialogResult d = MessageBox.Show("Deseja excluir o cliente?", "Aviso", MessageBoxButtons.YesNo);

                if (d.ToString() == "Yes")
                {
                    // obj para gravar os dados no banco
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLCliente bll = new BLLCliente(cx);
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
            frmConsultaCliente f = new frmConsultaCliente();
            // obj para gravar os dados no banco
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCliente bll = new BLLCliente(cx);
            //exibe o frmConsultaCategoria para seleção da alteração
            f.ShowDialog();
            //verifica se foi armazenado uma categoria no frmConsultaCategoria
            if (f.codigo != 0)
            {
                ModeloCliente modelo = bll.CarregarModeloCliente(f.codigo);
                txtCodigo.Text = modelo.CliCod.ToString();
                txtNome.Text = modelo.CliNome;
                alteraBotoes(3);
            }
            else
            {
                this.limpaTela();
                this.alteraBotoes(1);
            }
            f.Dispose();
            
        }

        private void frmCasastroCliente_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            rbFisica.Checked = true;
        }

        private void rbFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFisica.Checked == true)
            {
                lbRazaoSocial.Visible = false;
                txtRazaoSocial.Visible = false;
                lbCpfCnpj.Text = "CPF";
                lbRgIe.Text = "RG";
            }
            else
            {
                lbRazaoSocial.Visible = true;
                txtRazaoSocial.Visible = true;
                lbCpfCnpj.Text = "CNPJ";
                lbRgIe.Text = "I.E";
            }
        }

        private void txtCep_Leave(object sender, EventArgs e)
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
}
