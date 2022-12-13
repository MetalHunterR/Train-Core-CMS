using System.ComponentModel.DataAnnotations;

namespace TrainCore.Module.ViewModels
{
	public class LayoutPartViewModel
	{
        [Required]
        public float Width { get; set; }

        [Required]
        public float Height { get; set; }

        [Required]
        public float Length { get; set; }

        [Required]
        public string LayoutTheme { get; set; }

        [Required]
        public string Descreption { get; set; }
    }
}
