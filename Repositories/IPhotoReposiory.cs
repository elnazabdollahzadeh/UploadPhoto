using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadAPI.Models;

namespace UploadAPI.Repositories
{
    public interface IPhotoReposiory
    {
        Task<Photo> Add(Photo item);

        IEnumerable<Photo> GetAll();

        Task<Photo> Find(int id);

        Task<Photo> Remove(int id);

        Task<Photo> Update(Photo item);

        Task<bool> Exists(int id);
        //Task<int> Save();
    }
}
