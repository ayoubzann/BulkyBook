using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BulkyBookWeb.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [DisplayName("Release date")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        
        //public Category Category { get; set; }
    }

}
