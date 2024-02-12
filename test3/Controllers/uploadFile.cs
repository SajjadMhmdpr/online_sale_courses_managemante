using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test3.Controllers
{
    public class uploadFile
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public uploadFile(IWebHostEnvironment hostEnvironment)
        {
            webHostEnvironment = hostEnvironment;
        }

        public string upload(IFormFile file)
        {

            if (file == null)
                return "";

            var path = webHostEnvironment.WebRootPath + "\\images\\teachers\\" + file.FileName;
            var f = System.IO.File.Create(path);
            file.CopyTo(f);

            f.Close();

            return file.FileName;

            /*path = path.Split("wwwroot")[1];
            return path;*/
            
        }

        public string uploadVideo(IFormFile file)
        {

            if (file == null)
                return "";

            var path = webHostEnvironment.WebRootPath + "\\videos\\courses\\" + file.FileName;
            var f = System.IO.File.Create(path);
            file.CopyTo(f);

            path = path.Split("wwwroot")[1];

            f.Close();

            return path;

        }
    }
}
