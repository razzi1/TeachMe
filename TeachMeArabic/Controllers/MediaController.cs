using System.Data.Entity;
using System.Linq;
using MediaDataLayer;
using System.Web.Http;
using AutoMapper;
using MediaDataLayer.Entities;
using Repository;
using TeachMeArabic.Models;

namespace TeachMeArabic.Controllers
{
    public class MediaController : ApiController
    {
        private readonly IRepository repository;

        public MediaController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IHttpActionResult Post(Search search)
        {
            return search.GetCountOnly ? GetMediaListCount(search) : GetMediaList(search);
        }
        private IHttpActionResult GetMediaList(Search search)
        {
            var mediaList = repository.GetAll<Media>()
                .Where(me =>
                    (search.SelectedLanguage.Equals("All (الكل)") || me.Language.Name == search.SelectedLanguage) &&
                    (search.SelectedCategory.Equals("All (الكل)") ||
                     me.Categories.Any(mc => mc.Type == search.SelectedCategory)) &&
                    (string.IsNullOrEmpty(search.Title) || me.Title.Contains(search.Title) ||
                     me.Description.Contains(search.Title)) &&
                    (string.IsNullOrEmpty(search.Author) || me.Authors.Any(a => a.Fullname.Contains(search.Author))))
                .OrderBy(me => me.Id)
                .Skip(search.Offset)
                .Take(search.Limit);

            var result = mediaList
                .Select(Mapper.Map<Media, MediaSeachModel>)
                .ToList();
            return Ok(result);
        }

        private IHttpActionResult GetMediaListCount(Search search)
        {
            var mediaCount = repository
                .GetAll<Media>()
                .Count(me => (search.SelectedLanguage.Equals("All (الكل)") || me.Language.Name == search.SelectedLanguage) &&
                    (search.SelectedCategory.Equals("All (الكل)") ||
                     me.Categories.Any(mc => mc.Type == search.SelectedCategory)) &&
                    (string.IsNullOrEmpty(search.Title) || me.Title.Contains(search.Title) ||
                     me.Description.Contains(search.Title)) &&
                    (string.IsNullOrEmpty(search.Author) || me.Authors.Any(a => a.Fullname.Contains(search.Author))));
            return Ok(new { mediaCount = mediaCount });
        }

        public IHttpActionResult Get(int id)
        {
            var media = repository
                .GetAll<Media>()
                .Include(me => me.MediaCollection)
                .Include(me => me.Authors)
                .Include(me => me.Language)
                .Include(me => me.Categories)
                .Include(me => me.Publisher)
                .Include(me => me.ContentPages)
                .Single(me => me.Id == id);
            var mediaModels = Mapper.Map<Media, MediaModel>(media);
            mediaModels.ContentPages = media.ContentPages.OrderBy(mtc => mtc.Sequence).ToList();
            return Ok(mediaModels);
        }
    }
}
