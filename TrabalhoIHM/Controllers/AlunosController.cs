using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrabalhoIHM.Interfaces;
using TrabalhoIHM.Models;

namespace TrabalhoIHM.Controllers
{
    public class AlunosController : Controller
    {

        private readonly IAlunosRepository _alunos;
        public AlunosController(IAlunosRepository alunos)
        {
            _alunos = alunos;
        }


        // GET: Alunos
        public async Task<ActionResult> Index()
        {
            return View(await _alunos.GetAll());
        }

        // GET: Alunos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var aluno =  await _alunos.GetById(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            return View();
        }

     //Post: Cria um novo registro de Aluno
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Endereco,Telefone,Email,Nascimento,Ativo")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                 _alunos.Save(aluno);
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: Alunos/Edit/id
        public async Task<ActionResult> Edit(int id)
        {
            var aluno = await _alunos.GetById(id);
            if ( aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Aluno alunos)
        {
            if (ModelState.IsValid)
            {
                var alunoss = await _alunos.GetById(alunos.Id);
                _alunos.Save(alunos);
                return RedirectToAction("Index");
            }
            return View(alunos);
        }

        // GET: Alunos/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            var aluno = await _alunos.GetById(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            
            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _alunos.GetById(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            _alunos.Delete(aluno);

            return RedirectToAction("Index");
        }

    }
}
