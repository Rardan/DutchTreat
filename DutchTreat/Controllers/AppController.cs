﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DutchTreat.Services;
using DutchTreat.Data;
using Microsoft.AspNetCore.Authorization;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IDutchRepository _repository;
       // private readonly DutchContext _context;

        public AppController(IMailService mailService, IDutchRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
         //   _context = context;
        }

        public IActionResult Index()
        {
        //    var results = _context.Products.ToList();
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the email
                _mailService.SendMessage("przemolex01@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }

        [Authorize]
        public IActionResult Shop()
        {
            //var results = _context.Products
            //    .OrderBy(p => p.Category)
            //    .ToList();

            //var results = from p in _context.Products
            //              orderby p.Category
            //              select p;

            // var results = _repository.GetAllProducts();
            //return View(results);

            return View();
        }
    }
}