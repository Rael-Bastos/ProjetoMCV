using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrabalhoIHM.Dominio.UoW;
using TrabalhoIHM.Interfaces;
using TrabalhoIHM.Models;

namespace TrabalhoIHM.Controllers
{
    public class AlunosController : Controller
    {

        private readonly IAlunosRepository _alunos;
        private readonly IUnitOfWork _unitOfWork;
        public AlunosController(IAlunosRepository alunos, IUnitOfWork unitOfWork)
        {
            _alunos = alunos;
            _unitOfWork = unitOfWork;
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
        public ActionResult Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var alunoAdd = aluno;
                 _alunos.Save(alunoAdd);
                _unitOfWork.CommitAsync();
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
                var alunoedit = await _alunos.GetById(alunos.Id);
                alunoedit = alunos;
                _alunos.Save(alunoedit);
                await _unitOfWork.CommitAsync();
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
            await _unitOfWork.CommitAsync();

            return RedirectToAction("Index");
        }
    }
}
