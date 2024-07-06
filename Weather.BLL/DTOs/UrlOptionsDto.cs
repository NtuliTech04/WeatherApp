using Weather.BLL.Utilities.Mappings.Generic;
using Weather.DAL.Models;

namespace Weather.BLL.DTOs
{
    public class UrlOptionsDto : IMapFrom<UrlOptions>
    {
        public string City { get; set; }

        public string Unit { get; set; }
    }
}
