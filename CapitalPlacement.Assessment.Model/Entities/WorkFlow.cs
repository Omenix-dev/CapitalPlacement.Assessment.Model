
using CapitalPlacement.Assessment.Model.Enum;

namespace CapitalPlacement.Assessment.Model.Entities
{
    public class WorkFlow : BaseEntity
    {
        public string StageName { get; set; }
        public string StageType { get; set; }
        public object StageTypeBody { get; set; }
        public bool IsVisibleToCandidate { get; set; }
    }
}
