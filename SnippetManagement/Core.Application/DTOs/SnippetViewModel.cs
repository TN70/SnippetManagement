namespace Core.Application.DTOs
{
    public class SnippetViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Language { get; set; }
        public string? Tags { get; set; }
        public string? Description { get; set; }
        public string? Origin { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
