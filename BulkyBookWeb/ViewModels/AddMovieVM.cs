using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.ViewModels
{
    public class AddMovieVM
    {
        [Required]
        public string Title { get; set; }

        [DisplayName("Release date")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        [Required] // Not null
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100.")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
