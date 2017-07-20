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
    public partial class frmModeloDeFormularioDeCadastro : Form
    {
        public String operacao;
        
        public frmModeloDeFormularioDeCadastro()
        {
            InitializeComponent();
        }

        public void alteraBotoes(int op)
        {
            //op = operacoes que serao feitas com os botoes
            //1  = Preparar botoes para inserir e localizar
            //2  = preparar para inserir/alterar um registro
            //3  = prepara a tela para excluir ou alterar
            pnDados.Enabled = false;
            btInserir.Enabled = false;
            btLocalizar.Enabled = false;
            btAlterar.Enabled = false;
            btExcluir.Enabled = false;
            btSalvar.Enabled = false;
            //btCancelar.Enabled = false;
            btCancelar.Enabled = false;

            if (op == 1)
            {
                btInserir.Enabled = true;
                btLocalizar.Enabled = true;
            }
            if (op == 2)
            {
                pnDados.Enabled = true;
                btSalvar.Enabled = true;
                btCancelar.Enabled = true;
            }
            if (op == 3)
            {
                btAlterar.Enabled = true;
                btExcluir.Enabled = true;
                btCancelar.Enabled = true;
            }
        }


    }
}
