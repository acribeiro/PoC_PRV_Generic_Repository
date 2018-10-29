using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Providencia.Entidades;

namespace Providencia.DAL.Contexto
{
    public class BancoContexto : PRV_Model
    {
        public BancoContexto() 
            : base("PRV_Model")
        {

        }
    }
}
