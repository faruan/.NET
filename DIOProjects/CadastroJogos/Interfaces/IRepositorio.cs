using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroJogos.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Anula(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}
