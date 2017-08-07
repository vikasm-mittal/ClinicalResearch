using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
                
        public int DoctorId { get; set; }

        public int ManagerId { get; set; }

        public int TechnicianId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<ClinicalResult> ClinicalResults { get; set; }

        public List<StudyResult> StudyResults { get; set; }
    }
}
