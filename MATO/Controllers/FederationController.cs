using MATO.Models;
using MATO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MATO.Controllers
{    
    public class FederationController : Controller
    {
        private IMatoRepository _repository;

        public FederationController(IMatoRepository repository) {
            _repository = repository;
        }

        public IActionResult Index() {            
            var data = _repository.GetAllFederations();
            return View(data);            
        }

        [HttpGet]
        public IActionResult Add() {
            return View("Form");
        }

        [HttpPost]
        public async Task<IActionResult> Add(Federation newFederation) {
            if (ModelState.IsValid) {
                try {                   
                    await _repository.AddFederation(newFederation);                    
                }
                catch (DbUpdateConcurrencyException) {
                }
                return RedirectToAction("Index");
            }
            return View("Form", newFederation);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var federation = _repository.FindFederation(id);       

            return View("Form", federation);
        }

        //[HttpPost,ActionName("Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(Federation editedFederation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await TryUpdateModelAsync<Federation>(_repository.FindFederation(editedFederation.Id));
                    await _repository.SaveChangesAsync();              
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction("Index");
            }
            return View("Form");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _repository.DeleteFederation(id);
            return RedirectToAction("Index");
        }
    }
}
