using Repository;

namespace MediaDataLayer.Entities
{
    public class Chapter : IHaveId
    {
        public int Id { get; set; }
        public int MediaId { get; set; }
        public string Title { get; set; }
        public int StartingPage { get; set; }
    }
}