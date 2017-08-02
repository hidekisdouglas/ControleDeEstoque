using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmConsultaProduto : Form
    {
        public frmConsultaProduto()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLProduto bll = new BLLProduto(cx);
            dgvDados.DataSource = bll.Localizar(txtValor.Text);

        }

        private void frmConsultaProduto_Load(object sender, EventArgs e)
        {
            btLocalizar_Click(sender, e);
            //Carregar todos as categorias ao abrir o formulario de consulta
            btLocalizar_Click(sender, e);
            //troca o header da tabela
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 30;
            dgvDados.Columns[1].HeaderText = "Produto";
            dgvDados.Columns[1].Width = 80;
            dgvDados.Columns[2].HeaderText = "Descrição";
            dgvDados.Columns[2].Width = 150;
            dgvDados.Columns[3].HeaderText = "Imagem";
            dgvDados.Columns[3].Width = 50;
            dgvDados.Columns[4].HeaderText = "Valor pago";
            dgvDados.Columns[4].Width = 80;
            dgvDados.Columns[5].HeaderText = "Valor venda";
            dgvDados.Columns[5].Width = 80;
            dgvDados.Columns[6].HeaderText = "Qtde";
            dgvDados.Columns[6].Width = 60;
            dgvDados.Columns[7].HeaderText = "Und. de Med.";
            dgvDados.Columns[7].Width = 80;
            dgvDados.Columns[8].HeaderText = "Categoria";
            dgvDados.Columns[8].Width = 150;
            dgvDados.Columns[9].HeaderText = "Subcatogria";
            dgvDados.Columns[9].Width = 150;
        }
    }
}
