using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EntradaBusiness
    {
        EntradaDAO EntradaDAO = new EntradaDAO();   

        public void GuardarEntrada(Entrada entrada)
        {
            EntradaDAO.GuardarEntrada(entrada);
        }

        public void EliminarEntrada(int id)
        {
            EntradaDAO.EliminarEntrada(id);
        }

        public void ModificarEntrada(int id, DateTime fecha)
        {
            EntradaDAO.ModificarEntrada(id, fecha);
        }

        public List<Entrada> GetEntradas()
        {
            return EntradaDAO.GetEntradaList();
        }
    }
}
