using CapitalPlacement.Assessment.Model.Enum;


namespace CapitalPlacement.Assessment.Model.Dto
{
    public class WorkFlowRequestDto
    {
        public string StageName { get; set; }
        public StageType StageType { get; set; }
        public object StageTypeBody { get; set; }
        public bool IsVisibleToCandidate { get; set; }
    }
}
