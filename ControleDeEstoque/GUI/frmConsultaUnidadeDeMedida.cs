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
    public partial class frmConsultaUnidadeDeMedida : Form
    {
        public int codigo = 0;

        public frmConsultaUnidadeDeMedida()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
           
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cx);
                dgvDados.DataSource = bll.Localizar(txtValor.Text);
        }

        private void frmConsultaUnidadeDeMedida_Load(object sender, EventArgs e)
        {
            //Carregar todos as categorias ao abrir o formulario de consulta
            btLocalizar_Click(sender, e);
            //troca o header da tabela
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 70;
            dgvDados.Columns[1].HeaderText = "Und. de Media";
            dgvDados.Columns[1].Width = 630;
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
