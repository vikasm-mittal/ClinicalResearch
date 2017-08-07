using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Models
{
    public class StudyResult
    {
        [Key]
        public int Id { get; set; }

        public int StudyDataPoint1 { get; set; }

        public string StudyDataPoint2 { get; set; }
    }
}
