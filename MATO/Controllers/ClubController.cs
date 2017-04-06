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
    public class ClubController : Controller
    {
        private IClubRepository _repository;
        private IFederationRepository _repositoryFederation;

        public ClubController(IClubRepository repository, IFederationRepository repositoryFederation) {            
            _repository = repository;
            _repositoryFederation = repositoryFederation;
        }

        public IActionResult Index() {            
            var data = _repository.GetAllClubs().Result;
            ViewBag.title = "Club List";
            return View(data);            
        }

        [HttpGet]
        public async Task<IActionResult> Add() {
            ViewBag.title = "Add Club";
            ViewBag.federations = await _repositoryFederation.GetSelectListItems();
            return View("Form");
        }

        [HttpPost]
        public async Task<IActionResult> Add(Club newClub) {
            if (ModelState.IsValid) {
                try {                   
                    await _repository.AddClub(newClub);                    
                }
                catch (DbUpdateConcurrencyException) {
                }
                return RedirectToAction("Index");
            }
            ViewBag.title = "Add Club";
            ViewBag.federations = await _repositoryFederation.GetSelectListItems();
            return View("Form", newClub);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {            
            if (id == null)
            {
                return NotFound();
            }
            var club = await _repository.FindClub(id);
            ViewBag.title = "Edit Club";
            ViewBag.federations = await _repositoryFederation.GetSelectListItems();
            return View("Form", club);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Club editedClub)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await TryUpdateModelAsync<Club>(await _repository.FindClub(editedClub.Id));
                    await _repository.SaveChangesAsync();              
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction("Index");
            }
            ViewBag.title = "Edit Federation";
            ViewBag.federations = await _repositoryFederation.GetSelectListItems();
            return View("Form");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var federation = await _repository.FindClub(id);
            ViewBag.title = "Delete Club";
            return View("Delete", federation);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _repository.DeleteClub(id);
            return RedirectToAction("Index");
        }
    }
}
