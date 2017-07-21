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
    public partial class frmConsultaSubCategoria : Form
    {
        public int codigo = 0;

        public frmConsultaSubCategoria()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLSubcategoria bll = new BLLSubcategoria(cx);
            dgvDados.DataSource = bll.Localizar(txtValor.Text);

        }

        private void frmConsultaSubCategoria_Load(object sender, EventArgs e)
        {
            //Carregar todos as categorias ao abrir o formulario de consulta
            btLocalizar_Click(sender, e);
            //troca o header da tabela
            dgvDados.Columns[0].HeaderText = "Cod SubCat";
            dgvDados.Columns[0].Width = 70;
            dgvDados.Columns[1].HeaderText = "SubCategoria";
            dgvDados.Columns[1].Width = 280;
            dgvDados.Columns[2].HeaderText = "Cod Cat";
            dgvDados.Columns[2].Width = 70;
            dgvDados.Columns[3].HeaderText = "Categoria";
            dgvDados.Columns[3].Width = 280;

        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Seleção de toda a linha da tabela
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }

        
    }
}
