namespace Application.v1.DTOs
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsProfile { get; set; }
        public bool IsCover { get; set; }
    }
}