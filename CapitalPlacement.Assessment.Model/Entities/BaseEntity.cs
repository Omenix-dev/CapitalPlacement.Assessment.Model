
namespace CapitalPlacement.Assessment.Model.Entities
{
    public class BaseEntity
    {
        public string id { get; set; } = Guid.NewGuid().ToString(); 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
