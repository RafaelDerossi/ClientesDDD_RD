using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientesDDD.Dominio.Entidades;
using ClientesDDD.Infra.Dados.Config;
using ClientesDDD.Aplicacao.Interfaces;

namespace ClientesDDD.MVC.Controllers
{
    public class ClienteMVCController : Controller
    {
        private readonly IAppCliente _IAppCliente;

        public ClienteMVCController(IAppCliente IAppCliente)
        {
            _IAppCliente = IAppCliente;
        }

        // GET: Clientes
        public IActionResult Index()
        {
            return View(_IAppCliente.Listar().ToList());
        }

        // GET: Clientes/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _IAppCliente.RecuperarPorId((Guid)id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,Sobrenome,DataNascimento")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Id = Guid.NewGuid();
                _IAppCliente.Adicionar(cliente);                
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _IAppCliente.RecuperarPorId((Guid)id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Nome,Sobrenome,DataNascimento")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _IAppCliente.Atualizar(cliente);                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _IAppCliente.RecuperarPorId((Guid)id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var cliente = _IAppCliente.RecuperarPorId((Guid)id);
            _IAppCliente.Excluir(cliente);            
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(Guid id)
        {          
            if (_IAppCliente.RecuperarPorId((Guid)id) == null)
                return false;
            return true;
        }
    }
}
