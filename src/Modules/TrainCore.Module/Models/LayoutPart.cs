using OrchardCore.ContentManagement;

namespace TrainCore.Module.Models
{
	public class LayoutPart : ContentPart
	{
		public float Width { get; set; }

		public float Height { get; set; }

		public float Length { get; set; }

		public string LayoutTheme { get; set; }

		public string Descreption { get; set; }
	}
}
