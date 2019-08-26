using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrabalhoIHM.Auto_Mapper;
using TrabalhoIHM.Dominio.UoW;
using TrabalhoIHM.Dtos;
using TrabalhoIHM.Interfaces;
using TrabalhoIHM.Models;

namespace TrabalhoIHM.Controllers
{
    public class AlunosController : Controller
    {

        private readonly IAlunosRepository _alunos;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AlunosController(IAlunosRepository alunos, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _alunos = alunos;
            _unitOfWork = unitOfWork;
            _mapper = AutoMapper_config.Mapper;
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
        public async Task<ActionResult> Edit(AlunosDto alunosdto)
        {
            if (ModelState.IsValid)
            {
                Aluno alunoedit = await _alunos.GetById(alunosdto.Id);
                alunoedit.Nome = alunosdto.Nome;
                   // _mapper.Map(alunoedit, alunosdto);
                
                await _unitOfWork.CommitAsync();
                return RedirectToAction("Index");
            }
            return View(alunosdto);
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
