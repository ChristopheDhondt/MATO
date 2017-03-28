using MATO.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Add() {
            return View();
        }
    }
}
