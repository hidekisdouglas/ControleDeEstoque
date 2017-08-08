using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class ModeloTipoDePagamento
    {
        public ModeloTipoDePagamento()
        {
            this.TpaCod = 0;
            this.TpatNome = "";
        }
        public ModeloTipoDePagamento(int tpacod, string tpanome)
        {
            this.TpaCod = tpacod;
            this.TpatNome = tpa_nome;
        }

        private int tpa_cod;
        public int TpaCod
        {
            get { return this.tpa_cod; }
            set { this.tpa_cod = value; }
        }
        private String tpa_nome;
        public String TpatNome
        {
            get { return this.tpa_nome; }
            set { this.tpa_nome = value; }
        }
    }
}
