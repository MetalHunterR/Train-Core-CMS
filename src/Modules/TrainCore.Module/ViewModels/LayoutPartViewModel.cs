using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentFields.Fields;
using System.ComponentModel.DataAnnotations;

namespace TrainCore.Module.ViewModels
{
	public class LayoutPartViewModel
	{
        [Required]
        public string LayoutTheme { get; set; }

        [Required]
        public TextField Description { get; set; }

        [Required]
        public float Length { get; set; }

        [Required]
        public float Width { get; set; }
		
        [Required]
        public float Height { get; set; }
	}
}
