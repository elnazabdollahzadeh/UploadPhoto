using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadAPI.Context;
using UploadAPI.Models;

namespace UploadAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext context;
        private IRepository<Photo> photoRepository;

        public UnitOfWork(DataContext dbContext)
        {
            context = dbContext;
        }
        public IRepository<Photo> PhotoRepository
        {
            get
            {
                if (this.photoRepository == null)
                {
                    this.photoRepository = new GenericRepository<Photo>(context);
                }
                return photoRepository;
            }
        }


        // Part 2
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
