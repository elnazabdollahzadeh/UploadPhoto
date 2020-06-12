using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UploadAPI.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string File { get; set; }

        public string Path { get; set; }
    }
}
