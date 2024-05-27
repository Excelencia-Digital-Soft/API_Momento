using Models.MomentoApp;
using Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.Concreter
{
    public class PostsRepository : BaseRepository<PostsData>, IPostsRepository
    {
        public PostsRepository(MomentosAppContext _context) : base(_context)
        {
        }

        public async Task<List<PostsData>> GetAllPosts(int idUser)
        {
            return await (from publication in Context.Publications
                          join picture in Context.PublicationPictures on publication.IdPublication equals picture.IdPublication
                          join text in Context.PublicationTexts on publication.IdPublication equals text.IdPublication
                          join audit in Context.PublicationAudits on publication.IdPublication equals audit.IdPublication
                          where publication.IdUser == idUser && !publication.Annulated
                          select new PostsData
                          {
                              IdPublication = publication.IdPublication,
                              Picture = picture.Picture.ToString(),
                              Text = text.Text,
                              PictureByte = picture.Picture,
                              CreationDate = audit.CreationDate,
                              CreationDateString = audit.CreationDate.ToString(),
                              AgoDate = ""
                          }).ToListAsync();
        }

    }
}

