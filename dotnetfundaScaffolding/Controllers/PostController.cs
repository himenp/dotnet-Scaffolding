using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dotnetfundaScaffolding.Models;
namespace dotnetfundaScaffolding.Controllers
{
	public class PostController : Controller
	{
		private IRepository<Post> repository = null;
		private bool Success = false;

		// GET: Post
		public PostController()
		{
			this.repository = new Repository<Post>();
		}
		public PostController(IRepository<Post> repository)
		{
			this.repository = repository;
		}
		public ActionResult Index()
		{
			try
			{
				ViewBag.PageTitle = "Post | Post List";
				if (TempData["Message"] != null)
				{
					ViewBag.Message = TempData["Message"];
				}
				var model = (List<Post>)repository.SelectAll();
				return View("PostList",model);
			}
			catch (Exception ex)
			{
				ViewBag.Message = ex.Message;
				return View();
			}
		}
		// GET: Post/New
		[HttpGet]
		public ActionResult New()
		{
			ViewBag.PageTitle = "Post | New Post";
			if (TempData["Message"] != null)
			{
				ViewBag.Message = TempData["Message"];
			}
			return View("Post", new PostModel());
		}
		// POST: Post/New
		[HttpPost]
		public ActionResult New(PostModel postmodel)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ViewBag.PageTitle = "Post | New Post";
					return View("Post", new PostModel());
				}
				var post = new Post
				{
					//TODO :
				};
				repository.Insert(post);
				Success = repository.Save();
				if (Success)
				{
					TempData["Message"] = "Post Successfully Created.";
				}
				return RedirectToAction("Index");
			}
			catch
			{
				ViewBag.PageTitle = "Post | New Post";
				return View("Post", new PostModel());
			}
		}
		// GET: Post/Edit/
		public ActionResult Edit(int id)
		{
			try
			{
				ViewBag.PageTitle = "Post | Edit Post";
				if (TempData["Message"] != null)
				{
					ViewBag.Message = TempData["Message"];
				}
				Post post = repository.SelectByID(id);
				var model = new PostModel
				{
					//TODO :
				};
				return View("Post", model);
			}
			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return RedirectToAction("Index");
			}
		}
		// POST: Post/Edit/
		[HttpPost]
		public ActionResult Edit(int id, PostModel postmodel)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return RedirectToAction("Edit", new { id = id });
				}
				var post = new Post
				{
					//TODO :
				};
				repository.Update(post);
				Success = repository.Save();
				if (Success)
				{
					TempData["Message"] = "Post Successfully Updated.";
				}
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return RedirectToAction("Edit", new { id = id });
			}
		}
		// GET: Post/Delete/
		public ActionResult Delete(int id)
		{
			try
			{
				repository.Delete(id);
				Success = repository.Save();
				if (Success)
				{
					TempData["Message"] = "Post Successfully Deleted.";
				}
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return RedirectToAction("Index");
			}
		}
	}
}