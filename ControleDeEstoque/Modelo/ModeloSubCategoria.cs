﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloSubCategoria
    {
        private int scat_cod;
        public int ScatCod
        {
            get { return this.scat_cod; }
            set { this.scat_cod = value; }
        }

        private int cat_cod;
        public int CatCod
        {
            get { return this.cat_cod; }
            set { this.cat_cod = value; }
        }

        private String scat_nome;
        public String ScatNome
        {
            get { return this.scat_nome; }
            set { this.scat_nome = value; }
        }
    }
}
