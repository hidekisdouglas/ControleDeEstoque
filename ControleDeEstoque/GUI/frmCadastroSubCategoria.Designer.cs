namespace GUI
{
    partial class frmCadastroSubCategoria
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
            this.cbNomeCategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSCod = new System.Windows.Forms.TextBox();
            this.txtNomeSubcategoria = new System.Windows.Forms.TextBox();
            this.pnDados.SuspendLayout();
            this.pnBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.txtNomeSubcategoria);
            this.pnDados.Controls.Add(this.txtSCod);
            this.pnDados.Controls.Add(this.label3);
            this.pnDados.Controls.Add(this.cbNomeCategoria);
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
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome da Subcatoria";
            // 
            // cbNomeCategoria
            // 
            this.cbNomeCategoria.FormattingEnabled = true;
            this.cbNomeCategoria.Location = new System.Drawing.Point(16, 118);
            this.cbNomeCategoria.Name = "cbNomeCategoria";
            this.cbNomeCategoria.Size = new System.Drawing.Size(339, 21);
            this.cbNomeCategoria.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nome da Categoria";
            // 
            // txtSCod
            // 
            this.txtSCod.Enabled = false;
            this.txtSCod.Location = new System.Drawing.Point(16, 21);
            this.txtSCod.Name = "txtSCod";
            this.txtSCod.Size = new System.Drawing.Size(100, 20);
            this.txtSCod.TabIndex = 4;
            // 
            // txtNomeSubcategoria
            // 
            this.txtNomeSubcategoria.Location = new System.Drawing.Point(16, 70);
            this.txtNomeSubcategoria.Name = "txtNomeSubcategoria";
            this.txtNomeSubcategoria.Size = new System.Drawing.Size(339, 20);
            this.txtNomeSubcategoria.TabIndex = 5;
            // 
            // frmCadastroSubCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Name = "frmCadastroSubCategoria";
            this.Text = "Cadastro de subcategoria";
            this.Load += new System.EventHandler(this.frmCadastroSubCategoria_Load);
            this.pnDados.ResumeLayout(false);
            this.pnDados.PerformLayout();
            this.pnBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeSubcategoria;
        private System.Windows.Forms.TextBox txtSCod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNomeCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
