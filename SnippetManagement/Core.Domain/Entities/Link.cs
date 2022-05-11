using Core.Domain.Common;

namespace Core.Domain.Entities
{
    public class Link : BaseEntity
    {
        public string Value { get; set; }
        public int SnippetId { get; set; }
        public Snippet Snippet { get; set; }
    }
}
