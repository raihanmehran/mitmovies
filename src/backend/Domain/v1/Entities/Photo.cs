using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.v1.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsProfile { get; set; }
        public bool IsCover { get; set; }
        public string PublicId { get; set; }
        public int AppUserId { get; set; }
        public AppUser User { get; set; }
    }
}