﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Model.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductDataProvider _productData;

        public ProductController(IProductDataProvider productData)
        {
            _productData = productData;
        }
        public IActionResult ProductList()
        {
            var products = _productData.GetProducts();
            return View(products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            }).OrderBy(p => p.Name));
        }
    }
}