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
        
        public async Task<ActionResult> Index( string busca = null)
        {
            if(busca != null)
                return View(_alunos.CustomFind(x => x.Nome.ToUpper().Contains(busca.ToUpper())));
            
            return View(await _alunos.GetAll());
        }

      
        public async Task<ActionResult> Details(int id)
        {
            var aluno =  await _alunos.GetById(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
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
 
        public async Task<ActionResult> Edit(int id)
        {
            var aluno = await _alunos.GetById(id);
            if ( aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }
        
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
 
        public async Task<ActionResult> Delete(int id)
        {

            var aluno = await _alunos.GetById(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            
            return View(aluno);
        }
        
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
