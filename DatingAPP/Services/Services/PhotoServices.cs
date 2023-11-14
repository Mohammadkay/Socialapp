using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using DatingAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Services.Services
{
    public class PhotoServices : IPhotoServices
    {

        private readonly Cloudinary _cloudinary;

        public PhotoServices(IOptions<CloudinarySettings> config)
        {
            var acc = new Account
                (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(acc);

        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult=new ImageUploadResult();
            if (file.Length > 0)
            {
                using var strem = file.OpenReadStream();
                var uploadParms = new ImageUploadParams
                {
                    File = new FileDescription(file.Name, strem),
                    Transformation = new Transformation().Height(500).Width(500).Crop("file").Gravity("face"),
                    Folder = "da-net7"
                    };
                uploadResult=await _cloudinary.UploadAsync(uploadParms);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicid)
        {
            var deleteParams=new DeletionParams(publicid);

            return await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}
