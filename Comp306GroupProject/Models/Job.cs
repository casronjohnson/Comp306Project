using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Comp306GroupProject.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Company Name")]
        public string? CompanyName { get; set; }

        [Required]
        [DisplayName("Job Title")]
        public string? JobTitle { get; set; }

        [Required]
        [DisplayName("Job Description")]
        public string? JobDescription { get; set; }

        [Required]
        [DisplayName("Required Knowledge and Skills")]
        public string? RequiredSkills { get; set; }

        [Required]
        [DisplayName("Education + Experience")]
        public string? EducationExperience { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Salary { get; set; }

        [Required]
        [DisplayName("Part-Time / Full-Time")]
        public string? JobNature { get; set; }

        [Required]
        public DateOnly PostDate = DateOnly.FromDateTime(DateTime.Today);
    }
}
