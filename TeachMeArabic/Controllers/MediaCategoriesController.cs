using System.Linq;
using MediaDataLayer;
using System.Web.Http;
using MediaDataLayer.Entities;
using Repository;

namespace TeachMeArabic.Controllers
{
    public class MediaCategoriesController : ApiController
    {
        private readonly IRepository repository;

        public MediaCategoriesController(IRepository repository)
        {
            this.repository = repository;
        }

        public IHttpActionResult Get()
        {
            var mediaCategoriesController = repository.GetAll<Category>().Select(bt => bt.Type).ToList();
            mediaCategoriesController.Insert(0, "All (الكل)");
            return Ok(mediaCategoriesController);
        }
    }
}
