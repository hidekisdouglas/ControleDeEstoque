﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DadosDaConexao
    {
        public static String StringDeConexao
        {
            get
            {
                return "Data Source=DOUGLAS-PC\\SQLEXPRESS;Initial Catalog=db_Agenda;Integrated Security=True";
            }
        }
    }
}
