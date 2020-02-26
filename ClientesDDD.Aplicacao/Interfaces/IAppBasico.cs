using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesDDD.Aplicacao.Interfaces
{
    interface IAppBasico<T> where T : class
    {
        void Adicionar(T obj);

        T RecuperarPorId(Guid id);

        void Atualizar(T obj);

        void Excluir(T obj);

        IList<T> Listar();
    }
}
