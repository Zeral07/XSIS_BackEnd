using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XSISDataAccess.ViewModel
{
    public class MovieDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public double? Rating { get; set; }

        public string? Images { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}
