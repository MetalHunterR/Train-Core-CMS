using Microsoft.AspNetCore.Mvc;
using OrchardCore.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainCore.Module.Controllers
{
    internal class FileManagementController : Controller
    {
        private readonly IMediaFileStore mediaFileStore;

        public FileManagementController(IMediaFileStore mediaFileStore)
        {
            this.mediaFileStore = mediaFileStore;
        }
    }
}
