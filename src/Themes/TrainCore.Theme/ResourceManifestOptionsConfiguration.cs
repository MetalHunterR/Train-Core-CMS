using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace TrainCore.Theme
{
    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _manifest;

        static ResourceManagementOptionsConfiguration()
        {
            _manifest = new ResourceManifest();

            _manifest
                .DefineStyle("TheTheme-bootstrap-oc")
                .SetUrl("~/TrainCore.Theme/css/bootstrap-oc.min.css", "~/TrainCore.Theme/css/bootstrap-oc.css")
                .SetVersion("1.0.0");
        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}
