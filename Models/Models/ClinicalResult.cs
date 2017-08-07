using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Models
{
    public class ClinicalResult
    {
        [Key]
        public int Id { get; set; }

        public int ClinicalDataPoint1 { get; set; }

        public string ClinicalDataPoint2 { get; set; }

        public List<CustomClinicalDataPoint> CustomClinicalDataPoints { get; set; }

    }
}
