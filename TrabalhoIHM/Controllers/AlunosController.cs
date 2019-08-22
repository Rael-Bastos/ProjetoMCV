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
        public ActionResult Details(int id)
        {
            var aluno = _alunos.GetById(id);
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

        // POST: Alunos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Alunos/Edit/5
        public ActionResult Edit(int id)
        {
            var aluno = _alunos.GetById(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Endereco,Telefone,Email,Nascimento,Ativo")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var alunos = _alunos.CustomFind(x => x.Id == aluno.Id);
                _alunos.Save(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int id)
        {

            var alunaaa = _alunos.GetById(id);
            _alunos.DeleteMany(alunaaa);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            
            return View();
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            db.Alunos.Remove(aluno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
