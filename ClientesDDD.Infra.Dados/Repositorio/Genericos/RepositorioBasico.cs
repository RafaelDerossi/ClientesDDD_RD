using ClientesDDD.Dominio.Interfaces.Repositorio;
using ClientesDDD.Infra.Dados.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientesDDD.Infra.Dados.Repositorio.Genericos
{
    public class RepositorioBasico<T> : IRepositorioBasico<T>, IDisposable where T : class
    {


        private readonly DbContextOptions<ClientesDbContext> _optionsBuilder;

        public RepositorioBasico()
        {
            _optionsBuilder = new DbContextOptions<ClientesDbContext>();
        }




        public void Adicionar(T obj)
        {
            using (var db = new ClientesDbContext(_optionsBuilder))
            {
                db.Set<T>().Add(obj);
                db.SaveChanges();
            }

        }

        public void Atualizar(T obj)
        {
            using (var db = new ClientesDbContext(_optionsBuilder))
            {
                db.Set<T>().Update(obj);
                db.SaveChanges();
            }

        }

        public void Excluir(T obj)
        {
            using (var db = new ClientesDbContext(_optionsBuilder))
            {
                db.Set<T>().Remove(obj);
                db.SaveChanges();
            }

        }

        public IList<T> Listar()
        {
            using (var db = new ClientesDbContext(_optionsBuilder))
            {
                return db.Set<T>().AsNoTracking().ToList();
            }

        }

        public T RecuperarPorId(Guid id)
        {
            using (var db = new ClientesDbContext(_optionsBuilder))
            {
                return db.Set<T>().Find(id);
            }

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
