
using CapitalPlacement.Assessment.Model.Enum;

namespace CapitalPlacement.Assessment.Model.Entities
{
    public class VideoInterview
    {
        public string VideoInterviewQuestion { get; set; }
        public string AdditionalInfo { get; set; }
        public int Duration { get; set; }
        public DurationMeasure DurationMeasure { get; set; }
        public int VideoDeadline { get; set; }
    }
}
