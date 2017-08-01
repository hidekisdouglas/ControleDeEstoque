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

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }
    }
}
