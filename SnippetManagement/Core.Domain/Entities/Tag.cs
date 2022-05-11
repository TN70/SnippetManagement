using Core.Domain.Common;

namespace Core.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public int SnippetId { get; set; }
        public Snippet Snippet { get; set; }
    }
}
