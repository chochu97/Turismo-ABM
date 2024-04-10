using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TipoTurismoBusiness
    {
        TipoTurismoDAO tipoTurismoDao = new TipoTurismoDAO();

        public List<TipoTurismo> GetTurismos()
        {
            return tipoTurismoDao.GetTipoTurismos();
        }
    }
}
