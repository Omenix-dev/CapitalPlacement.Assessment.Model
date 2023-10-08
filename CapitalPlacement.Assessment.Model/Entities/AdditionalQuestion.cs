using CapitalPlacement.Assessment.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Assessment.Model.Entities
{
    public class AdditionalQuestion
    {
        public QuestionType Type { get; set; }
        public string Question { get; set; }
        public object extras { get; set; }
    }
}
