using System.ComponentModel.DataAnnotations;

namespace ITLAssessmentWebapp.Models
{
    public class FileViewModel
    {
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [Display(Name = "CSV File")]
        public IFormFile CSVFile { get; set; }
    }
}
