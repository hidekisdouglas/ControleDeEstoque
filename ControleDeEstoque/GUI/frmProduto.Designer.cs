namespace GUI
{
    partial class frmProduto
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.txtValorVenda = new System.Windows.Forms.TextBox();
            this.txtQtde = new System.Windows.Forms.TextBox();
            this.cbUnidadeDeMedida = new System.Windows.Forms.ComboBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.cbSubCategoria = new System.Windows.Forms.ComboBox();
            this.pnFoto = new System.Windows.Forms.Panel();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btCarregar = new System.Windows.Forms.Button();
            this.btRemover = new System.Windows.Forms.Button();
            this.pnDados.SuspendLayout();
            this.pnBotoes.SuspendLayout();
            this.pnFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.btRemover);
            this.pnDados.Controls.Add(this.btCarregar);
            this.pnDados.Controls.Add(this.label10);
            this.pnDados.Controls.Add(this.pnFoto);
            this.pnDados.Controls.Add(this.cbSubCategoria);
            this.pnDados.Controls.Add(this.cbCategoria);
            this.pnDados.Controls.Add(this.cbUnidadeDeMedida);
            this.pnDados.Controls.Add(this.txtQtde);
            this.pnDados.Controls.Add(this.txtValorVenda);
            this.pnDados.Controls.Add(this.txtValorPago);
            this.pnDados.Controls.Add(this.txtDescricao);
            this.pnDados.Controls.Add(this.txtProduto);
            this.pnDados.Controls.Add(this.txtCodigo);
            this.pnDados.Controls.Add(this.label9);
            this.pnDados.Controls.Add(this.label8);
            this.pnDados.Controls.Add(this.label7);
            this.pnDados.Controls.Add(this.label6);
            this.pnDados.Controls.Add(this.label5);
            this.pnDados.Controls.Add(this.label4);
            this.pnDados.Controls.Add(this.label3);
            this.pnDados.Controls.Add(this.label2);
            this.pnDados.Controls.Add(this.label1);
            // 
            // btSalvar
            // 
            this.btSalvar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // btInserir
            // 
            this.btInserir.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Produto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valor Pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Valor Venda";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Quantidade";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Unidade de Medida";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Categoria";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(213, 325);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Subcategoria";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(16, 21);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 9;
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(16, 73);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(246, 20);
            this.txtProduto.TabIndex = 10;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(16, 140);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(378, 68);
            this.txtDescricao.TabIndex = 11;
            // 
            // txtValorPago
            // 
            this.txtValorPago.Location = new System.Drawing.Point(13, 244);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(171, 20);
            this.txtValorPago.TabIndex = 12;
            this.txtValorPago.Text = "0.00";
            this.txtValorPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPago_KeyPress);
            this.txtValorPago.Leave += new System.EventHandler(this.txtValorPago_Leave);
            // 
            // txtValorVenda
            // 
            this.txtValorVenda.Location = new System.Drawing.Point(216, 243);
            this.txtValorVenda.Name = "txtValorVenda";
            this.txtValorVenda.Size = new System.Drawing.Size(178, 20);
            this.txtValorVenda.TabIndex = 13;
            this.txtValorVenda.Text = "0.00";
            this.txtValorVenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorVenda_KeyPress);
            this.txtValorVenda.Leave += new System.EventHandler(this.txtValorVenda_Leave);
            // 
            // txtQtde
            // 
            this.txtQtde.Location = new System.Drawing.Point(16, 292);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(168, 20);
            this.txtQtde.TabIndex = 14;
            this.txtQtde.Text = "0.00";
            this.txtQtde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtde_KeyPress);
            this.txtQtde.Leave += new System.EventHandler(this.txtQtde_Leave);
            // 
            // cbUnidadeDeMedida
            // 
            this.cbUnidadeDeMedida.FormattingEnabled = true;
            this.cbUnidadeDeMedida.Location = new System.Drawing.Point(216, 291);
            this.cbUnidadeDeMedida.Name = "cbUnidadeDeMedida";
            this.cbUnidadeDeMedida.Size = new System.Drawing.Size(178, 21);
            this.cbUnidadeDeMedida.TabIndex = 15;
            // 
            // cbCategoria
            // 
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(13, 341);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(171, 21);
            this.cbCategoria.TabIndex = 16;
            this.cbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbCategoria_SelectedIndexChanged);
            // 
            // cbSubCategoria
            // 
            this.cbSubCategoria.FormattingEnabled = true;
            this.cbSubCategoria.Location = new System.Drawing.Point(216, 341);
            this.cbSubCategoria.Name = "cbSubCategoria";
            this.cbSubCategoria.Size = new System.Drawing.Size(178, 21);
            this.cbSubCategoria.TabIndex = 17;
            // 
            // pnFoto
            // 
            this.pnFoto.Controls.Add(this.picFoto);
            this.pnFoto.Location = new System.Drawing.Point(430, 21);
            this.pnFoto.Name = "pnFoto";
            this.pnFoto.Size = new System.Drawing.Size(315, 342);
            this.pnFoto.TabIndex = 18;
            // 
            // picFoto
            // 
            this.picFoto.BackColor = System.Drawing.Color.Silver;
            this.picFoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFoto.Location = new System.Drawing.Point(0, 0);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(315, 342);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(427, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Foto";
            // 
            // btCarregar
            // 
            this.btCarregar.BackColor = System.Drawing.Color.Lime;
            this.btCarregar.FlatAppearance.BorderSize = 0;
            this.btCarregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCarregar.ForeColor = System.Drawing.Color.Black;
            this.btCarregar.Location = new System.Drawing.Point(430, 370);
            this.btCarregar.Name = "btCarregar";
            this.btCarregar.Size = new System.Drawing.Size(148, 41);
            this.btCarregar.TabIndex = 20;
            this.btCarregar.Text = "Carregar";
            this.btCarregar.UseVisualStyleBackColor = false;
            // 
            // btRemover
            // 
            this.btRemover.BackColor = System.Drawing.Color.Red;
            this.btRemover.FlatAppearance.BorderSize = 0;
            this.btRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRemover.Location = new System.Drawing.Point(597, 369);
            this.btRemover.Name = "btRemover";
            this.btRemover.Size = new System.Drawing.Size(148, 42);
            this.btRemover.TabIndex = 21;
            this.btRemover.Text = "Remover";
            this.btRemover.UseVisualStyleBackColor = false;
            // 
            // frmProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Name = "frmProduto";
            this.Text = "Cadastro de Produto";
            this.Load += new System.EventHandler(this.frmProduto_Load);
            this.pnDados.ResumeLayout(false);
            this.pnDados.PerformLayout();
            this.pnBotoes.ResumeLayout(false);
            this.pnFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSubCategoria;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.ComboBox cbUnidadeDeMedida;
        private System.Windows.Forms.TextBox txtQtde;
        private System.Windows.Forms.TextBox txtValorVenda;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btRemover;
        private System.Windows.Forms.Button btCarregar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnFoto;
        private System.Windows.Forms.PictureBox picFoto;
    }
}
