using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application.Common.SettingModels
{
   public class ImageUploadSetting : IImageUploadSetting
    {
        public string Path { get; set; }
    }

    public interface IImageUploadSetting
    {
        string Path { get; set; }
    }
}
