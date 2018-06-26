using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<CheeseCategory> categoryList = context.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategory = new AddCategoryViewModel();
            return View(addCategory);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategory)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory newCategory = new CheeseCategory();
                newCategory.Name = addCategory.Name;
                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("index");
            }
            else
            {
                return View(addCategory);
            }

        }
    }
}
