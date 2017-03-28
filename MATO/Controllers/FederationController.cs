using MATO.Models;
using MATO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Controllers
{
    public class FederationController : Controller
    {
        private IMatoRepository __repository;

        public FederationController(IMatoRepository repository)
        {
            __repository = repository;
        }

        public IActionResult Index() {
            
                var data = __repository.GetAllFederations();
                return View(data);
            
        }

        [HttpGet]
        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FederationViewModel federation)
        {
            if (ModelState.IsValid) {
                try
                {
                    __repository.AddFederation(federation);
                    await __repository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
