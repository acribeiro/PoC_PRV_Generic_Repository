using Providencia.DAL.Repositorios.Base;
using Providencia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providencia.DAL.Repositorios
{
    public class ConstituicaoFamiliarRepositorio : Repositorio<PRV_CONSTITUICAO_FAMILIAR>
    {
        public PRV_CONSTITUICAO_FAMILIAR RetornaConstituicaoFamiliar()
        {
            using (PRV_Model DbContext = new PRV_Model())
            {
                PRV_CONSTITUICAO_FAMILIAR pRV_CONSTITUICAO_FAMILIAR = DbContext.PRV_CONSTITUICAO_FAMILIAR.Include("PRV_EDUCANDO").FirstOrDefault();
                return pRV_CONSTITUICAO_FAMILIAR;
            }
        }
    }
}
