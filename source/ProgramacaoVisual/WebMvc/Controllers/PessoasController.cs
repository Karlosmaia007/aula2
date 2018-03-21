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


        private static IList<Pessoa> pessoaList = new List<Pessoa>
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

            var viewModel = new PessoaViewModel
            {
                Items = pessoaList
            };
            //visualizaçao dos dados 
            return View(viewModel);
        }

        public IActionResult create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome")]Pessoa newPessoa)
        {
            if (!ModelState.IsValid)
                return View(newPessoa);

            newPessoa.Id = pessoaList.Max(p => p.Id) + 1;
            pessoaList.Add(newPessoa);
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var pessoa = pessoaList
                .FirstOrDefault(p => p.Id == id);

            if (pessoa == null)
                return NotFound();

            return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(
            [Bind("Id, Nome")]Pessoa editPessoa
            )
        {
            if (!ModelState.IsValid)
                return View(editPessoa);

            var pessoaToEdit = pessoaList
                .FirstOrDefault(p => p.Id == editPessoa.Id);

            if (pessoaToEdit == null)
                return NotFound();

            pessoaToEdit.Nome = editPessoa.Nome;

            return RedirectToAction(nameof(Index));
        }


    }
}