using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrabalhoIHM.Models;

namespace TrabalhoIHM.Interfaces
{
    public interface IAlunos
    {
        Task<ActionResult> Index();
    }
}
