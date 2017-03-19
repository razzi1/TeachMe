using System.Linq;
using MediaDataLayer;
using System.Web.Http;
using MediaDataLayer.Entities;
using Repository;

namespace TeachMeArabic.Controllers
{
    public class MediaCategoriesController : ApiController
    {
        private readonly IRepository<Category> repository;

        public MediaCategoriesController(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public IHttpActionResult Get()
        {
            var mediaCategoriesController = repository.GetAll().Select(bt => bt.Type).ToList();
            mediaCategoriesController.Insert(0, "All (الكل)");
            return Ok(mediaCategoriesController);
        }
    }
}
