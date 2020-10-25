﻿
using FPTApp.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;
namespace FPTApp.Controllers
{
	public class CategoriesController : Controller
	{

		private readonly ApplicationDbContext _context;
		public CategoriesController()
		{
			_context = new ApplicationDbContext();
		}

		public ActionResult Index()
		{
			return View(_context.Categories.ToList());
		}



		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Category category)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Create");
			}
			if (_context.Categories.Any(p => p.Name.Contains(category.Name)))
			{
				ModelState.AddModelError("Name", " Name Already Exists.");
				return View();
			}
			_context.Categories.Add(category);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var categoryInDb = _context.Categories
				.SingleOrDefault(p => p.Id == id);
			if (categoryInDb == null)
			{
				return HttpNotFound();
			}
			return View(categoryInDb);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Category category)
		{
			var categoryInDb = _context.Categories
				.SingleOrDefault(p => p.Id == category.Id);
			if (categoryInDb == null)
			{
				return HttpNotFound();
			}

			categoryInDb.Name = category.Name;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var categoryInDb = _context.Categories
				.SingleOrDefault(p => p.Id == id);
			if (categoryInDb == null)
			{
				return HttpNotFound();
			}
			_context.Categories.Remove(categoryInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}

}