using ClientesDDD.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesDDD.Dominio.Interfaces.Repositorio
{
   public interface IRepositorioCliente : IRepositorioBasico<Cliente>
    {
        //Herdando todos os métodos de IRepositorioBasico

    }
}
