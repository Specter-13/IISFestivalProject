using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalProject.BL.Models.FestivalInterpretDto
{
    public class FestivalInterpretCreateUpdate
    {
        public Guid FestivalId { get; set; }

        public Guid InterpretId { get; set; }
    }
}
