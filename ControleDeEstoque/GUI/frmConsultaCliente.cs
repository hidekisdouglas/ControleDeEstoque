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
    public partial class frmConsultaCliente : Form
    {
        public int codigo = 0;

        public frmConsultaCliente()
        {
            InitializeComponent();
        }

        private void frmConsultaCliente_Load(object sender, EventArgs e)
        {
            rbNome.Checked = true;
            btLocalizar_Click(sender, e);
            //Carregar todos as categorias ao abrir o formulario de consulta
            btLocalizar_Click(sender, e);
            //troca o header da tabela
            dgvDados.Columns[0].HeaderText = "Cód";
            dgvDados.Columns[0].Width = 30;
            dgvDados.Columns[1].HeaderText = "Nome";
            dgvDados.Columns[1].Width = 100;
            dgvDados.Columns[2].HeaderText = "CPF/CNPJ";
            dgvDados.Columns[2].Width = 110;
            dgvDados.Columns[3].HeaderText = "RG/I.E";
            dgvDados.Columns[3].Width = 70;
            dgvDados.Columns[4].HeaderText = "Razão Social";
            dgvDados.Columns[4].Width = 200;
            dgvDados.Columns[5].HeaderText = "Tipo de Cliente";
            dgvDados.Columns[5].Width = 60;
            dgvDados.Columns[6].HeaderText = "CEP";
            dgvDados.Columns[6].Width = 60;
            dgvDados.Columns[7].HeaderText = "Endereco";
            dgvDados.Columns[7].Width = 200;
            dgvDados.Columns[8].HeaderText = "Bairro";
            dgvDados.Columns[8].Width = 150;
            dgvDados.Columns[9].HeaderText = "Telefone";
            dgvDados.Columns[9].Width = 80;
            dgvDados.Columns[10].HeaderText = "Celular";
            dgvDados.Columns[10].Width = 80;
            dgvDados.Columns[11].HeaderText = "Email";
            dgvDados.Columns[11].Width = 180;
            dgvDados.Columns[12].HeaderText = "Número";
            dgvDados.Columns[12].Width = 40;
            dgvDados.Columns[13].HeaderText = "Cidade";
            dgvDados.Columns[13].Width = 150;
            dgvDados.Columns[14].HeaderText = "UF";
            dgvDados.Columns[14].Width = 30;


            // ocultar colunas
            //dgvDados.Columns["pro_foto"].Visible = false;
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCliente bll = new BLLCliente(cx);
            if (rbNome.Checked == true)
            {
                dgvDados.DataSource = bll.LocalizarNome(txtValor.Text);
            }
            else
            {
                dgvDados.DataSource = bll.LocalizarCpfcnpj(txtValor.Text);
            }
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
