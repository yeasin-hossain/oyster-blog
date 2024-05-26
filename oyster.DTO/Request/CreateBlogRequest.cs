using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oyster.DTO.Request
{
    public class CreateBlogRequest
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }
    }
}
