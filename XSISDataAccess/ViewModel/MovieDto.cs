using System.ComponentModel.DataAnnotations;

namespace XSISDataAccess.ViewModel
{
    public class MovieDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int? Rating { get; set; }

        public string? Images { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
