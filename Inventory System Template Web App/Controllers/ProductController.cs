using CloudinaryDotNet.Actions;
using Inventory_System_Template_Web_App.Interfaces;
using Inventory_System_Template_Web_App.Models;
using Inventory_System_Template_Web_App.Utilities;
using Inventory_System_Template_Web_App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Security.Principal;

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
                var result = await _photoService.AddPhotoAsync(addItemViewModel.Image!);
                Item item = new Item 
                {
                    Guid = Guid.NewGuid(),
                    Id = Generators.NewId(),
                    Sku = addItemViewModel.SKU!,
                    BrandName = addItemViewModel.Brand!,
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
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            AddItemViewModel? viewmodel = null;
            var getItem = await _productRepository.GetByIdAsync(id);
            if (getItem != null) 
            {
                viewmodel = new AddItemViewModel
                {
                    SKU = getItem.Sku,
                    Brand = getItem.BrandName,
                    ProductName = getItem.ProductName,
                    Price = getItem.Price,
                    Category = getItem.Category,
                    Quantity = getItem.Quantity                
                };
            }
            return View(viewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, AddItemViewModel addItemViewModel)
        {
            ImageUploadResult? photoResult = null;
            string photo = string.Empty;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit account");
                return View(addItemViewModel);
            }
            var account = await _productRepository.GetByIdAsyncAsNoTraking(id);
            if (account != null) 
            {
                if (addItemViewModel.Image != null)
                {
                    try
                    {
                        await _photoService.DeletePhotoAsync(account.Image);
                        photoResult = await _photoService.AddPhotoAsync(addItemViewModel.Image);
                        photo = photoResult.Url.ToString();
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Could not delete photo " + ex.ToString());
                        return View(addItemViewModel);
                    }
                }
                else
                {
                    photo = account.Image;
                }
                Item editItem = new Item
                {
                    Guid = account.Guid,
                    Id = account.Id,
                    Sku = addItemViewModel.SKU!,
                    BrandName = addItemViewModel.Brand!,
                    ProductName = addItemViewModel.ProductName!,
                    Price = addItemViewModel.Price,
                    Category = addItemViewModel.Category!,
                    Quantity = addItemViewModel.Quantity,
                    Image = photo,
                    InStock = addItemViewModel.Quantity > 0 ? true : false,
                    DateCreated = account.DateCreated,
                    DateModified = DateTime.Now
                };
                await _productRepository.Update(editItem);
                return RedirectToAction("Index");
            }
            return View(addItemViewModel);
        }
    }
}
