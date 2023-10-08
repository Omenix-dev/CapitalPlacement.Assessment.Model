
using System.ComponentModel;

namespace CapitalPlacement.Assessment.Model.Enum
{
    public enum QuestionType
    {
        Paragraph,
        [Description ("short answer")]
        ShortAnswer,
        [Description("Yes/NO")]
        YesOrNo,
        [Description("Drop down")]
        DropDown,
        MultipleChoice,
        Date,
        Number,
        [Description("File upload")]
        FileUpload,
        [Description("Video question")]
        VideoQuestion
    }
}
