using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TrabalhoIHM.Interfaces;
using TrabalhoIHM.Models;

namespace TrabalhoIHM.Repositorio
{
    public class AlunosRepository : Repository<Aluno>, IAlunosRepository
    {
        public AlunosRepository(EscolaContext context) : base(context)
        {
        }

    }   
}