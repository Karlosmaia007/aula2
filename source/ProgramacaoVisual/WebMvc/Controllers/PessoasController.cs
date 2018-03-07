using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
 
namespace WebMvc.Controllers
{
    public class PessoasController : Controller
    {


           private static IList<Pessoa> PessoaList = new List<Pessoa>
        {
            new Pessoa {Id = 1, Nome = "Joao"},
            new Pessoa {Id = 2, Nome = "Joao"},
            new Pessoa {Id = 3, Nome = "John"}
        };



    // Actions

    // localhost:5000/pessoas
    //localhost:5000/pessoas/Index
        public IActionResult Index()
        {
            // busca dos dados
            //transforma dados em dados de visualização 

            var viewModel  = new PessoaViewModel
            {
                Items = PessoaList
            };
            //visualizaçao dos dados 
            return View(viewModel);
         }
    }
}