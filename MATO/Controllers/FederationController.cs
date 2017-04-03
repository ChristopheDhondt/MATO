using MATO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Localization;

namespace MATO.Controllers
{    
    public class FederationController : Controller
    {
        private IFederationRepository _repository;        

        public FederationController(IFederationRepository repository) {            
            _repository = repository;
        }

        public IActionResult Index() {            
            var data = _repository.GetAllFederations().Result;
            ViewBag.title = "Federation List";
            return View(data);            
        }

        [HttpGet]
        public IActionResult Add() {
            ViewBag.title = "Add Federation";
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
            ViewBag.title = "Add Federation";
            return View("Form", newFederation);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {            
            if (id == null)
            {
                return NotFound();
            }
            var federation = await _repository.FindFederation(id);
            ViewBag.title = "Edit Federation";
            return View("Form", federation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Federation editedFederation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await TryUpdateModelAsync<Federation>(await _repository.FindFederation(editedFederation.Id));
                    await _repository.SaveChangesAsync();              
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction("Index");
            }
            ViewBag.title = "Edit Federation";
            return View("Form");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var federation = await _repository.FindFederation(id);
            ViewBag.title = "Delete Federation";
            return View("Delete", federation);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
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
