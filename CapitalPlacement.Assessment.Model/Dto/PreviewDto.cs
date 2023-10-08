
namespace CapitalPlacement.Assessment.Model.Dto
{
    public class PreviewDto
    {
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public string ProgramSummary { get; set; }  
        public string ProgramBenefit { get; set; }
        public List<string> ListOfSkill { get; set; }
        public string ApplicationCriteria { get; set; }
        public string ProgramType { get; set; }
        public DateTime ProgramStart { get; set; }
        public DateTime ApplicationOpen { get; set; }
        public DateTime ApplicationCLose { get; set; }
        public int Duration { get; set; }
        public string ProgramLocation { get; set; }

    }
}
