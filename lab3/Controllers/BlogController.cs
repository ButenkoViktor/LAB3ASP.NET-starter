using lab3.Models;
using lab3.Models.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            var entities = InMemoryBlogStore.GetAll();
            var viewModels = entities.Select(e => e.ToViewModel()); 
            return View(viewModels);
        }

        public IActionResult Article(string id)
        {
            var post = InMemoryBlogStore.GetById(id);
            if (post == null) return NotFound();
            var viewModel = post.ToViewModel();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateBlogArticleModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateBlogArticleModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (InMemoryBlogStore.Exists(viewModel.Id))
            {
                ModelState.AddModelError(nameof(viewModel.Id), "Id must be unique.");
                return View(viewModel);
            }

            var entity = viewModel.ToEntity();
            InMemoryBlogStore.Add(entity);
            return RedirectToAction(nameof(Article), new { id = entity.Id });
        }
    }
}
