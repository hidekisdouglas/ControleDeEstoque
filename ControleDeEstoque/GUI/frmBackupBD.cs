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
    public partial class frmBackupBD : Form
    {
        public frmBackupBD()
        {
            InitializeComponent();
        }

        private void btBackupBancoDeDados_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "Backup Files |*.bak";
            d.ShowDialog();
            if (d.FileName != "")
            {
                string nomeBanco = DadosDaConexao.banco;
                String conexao = @"Data Source=" + DadosDaConexao.servidor + "; Initial Catolog=master;User=" + DadosDaConexao.usuario + ";Password=" + DadosDaConexao.senha;
            }
        }
    }
}
