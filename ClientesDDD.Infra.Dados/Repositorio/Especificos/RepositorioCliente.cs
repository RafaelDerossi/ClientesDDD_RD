using ClientesDDD.Dominio.Entidades;
using ClientesDDD.Dominio.Interfaces.Repositorio;
using ClientesDDD.Infra.Dados.Repositorio.Genericos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesDDD.Infra.Dados.Repositorio.Especificos
{
   public class RepositorioCliente : RepositorioBasico<Cliente>, IRepositorioCliente
    {
    }
}
