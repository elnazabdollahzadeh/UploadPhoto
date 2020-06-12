using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadAPI.Models;

namespace UploadAPI.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Photo> PhotoRepository { get; }

        void Save();

        void Dispose();
        //void Dispose(bool disposing);
    }
}
