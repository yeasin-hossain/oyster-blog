using System.ComponentModel.DataAnnotations;

namespace oyster_blog.Service.DTO.Request
{
    public class CreateBlogRequest
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }
    }
}
