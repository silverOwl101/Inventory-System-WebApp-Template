using Inventory_System_Template_Web_App.Interfaces;
using Inventory_System_Template_Web_App.Models;
using Inventory_System_Template_Web_App.Utilities;
using Inventory_System_Template_Web_App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System_Template_Web_App.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IPhotoService _photoService;

        public ProductController(IProductRepository productRepository, IPhotoService photoService)
        {
            _productRepository = productRepository;
            _photoService = photoService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _productRepository.GetAll();
            return View(items);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddItemViewModel addItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(addItemViewModel.Image);
                Item item = new Item 
                {
                    Guid = Guid.NewGuid(),
                    Id = Generators.NewId(),
                    Sku = addItemViewModel.SKU!,
                    ProductName = addItemViewModel.ProductName!,
                    Price = addItemViewModel.Price,
                    Category = addItemViewModel.Category!,
                    Quantity = addItemViewModel.Quantity,
                    Image = result.Url.ToString(),
                    InStock = addItemViewModel.Quantity > 0 ? true : false,
                    DateCreated = DateTime.Now
                };
                await _productRepository.Add(item);
                return RedirectToAction("Index");
            }
            else 
                ModelState.AddModelError("", "Photo upload failed");
            return View(addItemViewModel);
        }
    }
}
