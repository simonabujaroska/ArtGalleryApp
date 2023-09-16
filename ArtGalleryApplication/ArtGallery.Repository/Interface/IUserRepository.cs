using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallery.Domain.Identity;

namespace ArtGallery.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<ArtGalleryAppUser> GetAll();
        ArtGalleryAppUser Get(string id);
        void Insert(ArtGalleryAppUser entity);
        void Update(ArtGalleryAppUser entity);
        void Delete(ArtGalleryAppUser entity);
    }
}
