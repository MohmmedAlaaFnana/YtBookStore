using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YtBookStore.Models.Domain;
using YtBookStore.Repositories.Abstract;
using YtBookStore.Repositories.Implementation;

namespace YtBookStore.Controllers
{
    public class BookController : Controller
    {
            private readonly IBookService bookService;
            private readonly IAuthorService authorService;
            private readonly IGenreService genreService;
            private readonly IPublisherService publisherService;


        public BookController(IBookService bookservice, IAuthorService authorService, IGenreService genreService, IPublisherService publisherService)
            {
                this.bookService = bookservice;
                this.authorService =authorService;
                this.genreService = genreService;
                this.publisherService = publisherService;
           }

            public IActionResult Add()
            {
                var model = new Book();
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(),Selected=a.Id==model.AuthorId }).ToList();
            model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(),Selected=a.Id==model.PublisherId }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(),Selected=a.Id==model.GenreId }).ToList();

            return View(model);
            }

            [HttpPost]

            public IActionResult Add(Book model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var result = bookService.Add(model);
                if (result)
                {
                    TempData["msg"] = "Added Successfully";
                    return RedirectToAction(nameof(Add));
                }
                TempData["msg"] = "Error has occured on server side";
                return View(model);
            }

            public IActionResult Update(int id)
            {
               var model = bookService.FindById(id);
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();

            return View(model);
            }

            [HttpPost]

            public IActionResult Update(Book model)
            {
          
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();

            if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var result = bookService.Update(model);
                if (result)
                {
                    TempData["msg"] = "Updated Successfully";
                    return RedirectToAction(nameof(Update));
                }
                TempData["msg"] = "Error has occured on server side";
                return View(model);
            }

            public IActionResult Delete(int id)
            {

                var result = bookService.Delete(id);
                return RedirectToAction("GetAll");

            }
            public IActionResult GetAll()
            {

                var data = bookService.GetAll();
                return View(data);

            }

        }

    }

