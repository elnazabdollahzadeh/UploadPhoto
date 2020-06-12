using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UploadAPI.Models;
using UploadAPI.Repositories;
using System.IO;
using Microsoft.Extensions.Logging;

namespace UploadAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Upload")]
    [ApiController]
    
    public class UploadController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<UploadController> _logger;
        public UploadController(ILogger<UploadController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }
        [HttpGet]
        public List<Photo> Get()
        {
            return _unitOfWork.PhotoRepository.GetAll();
                             
        }

        [HttpPost]
        public IActionResult Post([FromBody] Photo value)
        {
            try
            {
                
                var dataURI = value.File;
                
                if (dataURI.Length>0)
                {
                    byte[] base64Data = Convert.FromBase64String(dataURI.Split(',')[1]);
                    var fileName = value.Name +".png";

                    var folderName = Path.Combine("StaticFiles", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    // Create the file, or overwrite if the file exists.
                    using FileStream fs = System.IO.File.Create(fullPath);
                    fs.Write(base64Data);
                    //bw.Write(data);


                    //add file path to model
                    value.Path = dbPath;
                    _unitOfWork.PhotoRepository.Add(value);
                    _unitOfWork.Save();

                    return Ok(new { dbPath });
                }
                else
                {
                    _logger.LogError("No image data to download.", "Post photo");
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Post photo");
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }
    }

}