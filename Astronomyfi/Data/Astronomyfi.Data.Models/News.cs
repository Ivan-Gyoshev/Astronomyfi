namespace Astronomyfi.Data.Models
{
    using Astronomyfi.Data.Common.Models;

    public class News : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

    }
}
