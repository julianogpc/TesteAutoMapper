using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TesteAutoMapper.Context;
using TesteAutoMapper.Models;
using TesteAutoMapper.ViewModels;
using System.Data;

namespace TesteAutoMapper.Controllers
{
    public class HomeController : Controller
    {
        DBContext db = new DBContext();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Home/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CadastrarFuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var funcionario = Mapper.Map<CadastrarFuncionarioViewModel, Funcionario>(funcionarioViewModel);
                db.Funcionario.Add(funcionario);
                db.SaveChanges();
                db.Dispose();
            }
            return View(funcionarioViewModel);
        }

        //
        // GET: /Edit/

        public ActionResult Edit(int id = 0)
        {
            var funcionario = db.Funcionario.Include(x => x.Usuario).FirstOrDefault(x => x.Id == id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            var funcionarioViewModel = Mapper.Map<Funcionario, EditarFuncionarioViewModel>(funcionario);
            return View(funcionarioViewModel);
        }

        //
        // POST: /Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditarFuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var funcionario = Mapper.Map<EditarFuncionarioViewModel, Funcionario>(funcionarioViewModel);
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Index");
            }
            return View(funcionarioViewModel);
        }

    }
}
