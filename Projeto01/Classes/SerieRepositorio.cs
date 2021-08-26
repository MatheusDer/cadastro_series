using System;
using System.Collections.Generic;
using Projeto01.Interfaces;

namespace Projeto01
{
    public class SerieRepositorio : IRepositorio<Serie>
    {

        private List<Serie> listaSeries = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            listaSeries[id] = entidade;
        }
        public void Exclui(int id)
        {
            listaSeries[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            listaSeries.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSeries[id];
        }
        public List<Serie> RetornaPorGenero(int genero)
        {            
            List<Serie> listaSeriePorGenero = new List<Serie>(); 
            foreach (var lista in listaSeries)
            {
                if (lista.retornaGenero() == (Genero)genero)
                {
                    listaSeriePorGenero.Add(lista);
                }
            }
            return listaSeriePorGenero;
        }
    }
}