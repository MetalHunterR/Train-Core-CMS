using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace TrainCore.Module.Models
{
	public class LayoutPart : ContentPart
	{
        public string LayoutTheme { get; set; }

        public TextField Description { get; set; }

        public float Length { get; set; }

        public float Width { get; set; }

		public float Height { get; set; }
	}
}
