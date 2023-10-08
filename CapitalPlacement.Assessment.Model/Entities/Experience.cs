

namespace CapitalPlacement.Assessment.Model.Entities
{
    public class Experience
    {
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsStillWorking { get; set; }
    }
}
