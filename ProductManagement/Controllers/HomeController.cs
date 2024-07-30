using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductManagement.Models;
using ProductManagementDataAccess.Repositories.Abstracts;
using ProductManagementDomainLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vm = new ProductListViewModel
            {
                Products = await _productRepository.GetAllAsync()
            };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.DeleteByIdAsync(id);
            await _productRepository.SaveAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Add(int id)
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Product.ImageLink = "/images/Smoothie.png";
                await _productRepository.AddAsync(vm.Product);
                await _productRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            var vm = new ProductEditViewModel { Product = product };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.UpdateAsync(vm.Product);
                await _productRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
