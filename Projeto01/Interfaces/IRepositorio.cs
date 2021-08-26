using System.Collections.Generic;

namespace Projeto01.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaPorId(int id);
         void Insere(T entidade);
         void Atualiza(int id, T entidade);
         void Exclui(int id);
         int ProximoId();
         List<T> RetornaPorGenero(int genero);

    }
}