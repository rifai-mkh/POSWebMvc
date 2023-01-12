﻿using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _service;
        public CustomerController(ApplicationDbContext context)
        {
            _service = new CustomerService(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var customers = _service.Get();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(
            [Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax")] CustomerModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Add(new CustomersEntity(request));
                return Redirect("Index");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var customer = _service.View(id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var customer = _service.View(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax")] CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                CustomersEntity entity = new CustomersEntity(customer);
                entity.Id = customer.Id;
                _service.Update(entity);
                return Redirect("Index");
            }
            return View("Edit", customer);
            /*_service.Update(customer);
            return Redirect("Index");*/
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.Delete(id);
            return Redirect("/Customer");
        }
    }
}
