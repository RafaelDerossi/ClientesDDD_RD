using ClientesDDD.Aplicacao.Interfaces;
using ClientesDDD.Dominio.Entidades;
using ClientesDDD.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesDDD.Aplicacao.Aplicacoes
{
   public class AppCliente : IAppCliente
    {
        IRepositorioCliente _repositorioClienteInterface;

        public AppCliente(IRepositorioCliente repositorioClienteInterface)
        {
            _repositorioClienteInterface = repositorioClienteInterface;
        }


        public void Adicionar(Cliente obj)
        {
            _repositorioClienteInterface.Adicionar(obj);
        }

        public void Atualizar(Cliente obj)
        {
            _repositorioClienteInterface.Atualizar(obj);
        }

        public void Excluir(Cliente obj)
        {
            _repositorioClienteInterface.Excluir(obj);
        }

        public IList<Cliente> Listar()
        {
            return _repositorioClienteInterface.Listar();
        }

        public Cliente RecuperarPorId(Guid id)
        {
            return _repositorioClienteInterface.RecuperarPorId(id);
        }
    }
}
