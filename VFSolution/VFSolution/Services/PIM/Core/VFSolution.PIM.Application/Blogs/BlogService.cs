using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFSolution.PIM.Application.Base;
using VFSolution.PIM.Application.Blogs.Request;
using VFSolution.PIM.Application.Extentions;
using VFSolution.PIM.Persistence;

namespace VFSolution.PIM.Application.Blogs
{
    public class BlogService : BaseService<BlogModel>, IBlogService
    {
        private readonly VFDbContext _dbContext;

        public BlogService(VFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateAsync(BlogRequest request)
        {
            var entity = new Domain.Entities.Blog()
            {
               Title = request.Title,
               Link = request.Link,
               Text = request.Text,
               CategoryId = request.CategoryId
            };

            await _dbContext.Blogs.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<string> DeleteAsync(string Id)
        {
            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(p => p.Id == new Guid(Id));

            blog.IsDelete = true;

            await _dbContext.SaveChangesAsync();

            return blog.Id.ToString();
        }

        public PagedResult<BlogModel> Get(CommonRequest request)
        {
            var query = _dbContext.Blogs.AsNoTracking().Where(a => !a.IsDelete).AsQueryable();
            var result = PagingExtensions.GetPaged<Domain.Entities.Blog, BlogModel>(query, request.PageIndex, request.PageSize);
            return this.ComposeResponse(result);
        }

        public async Task<BlogModel> GetById(Guid id)
        {
            var query = await _dbContext.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<Domain.Entities.Blog, BlogModel>(query);
        }

        public async Task<IEnumerable<BlogModel>> GetBlogs()
        {
            var result = await _dbContext.Blogs.Select(x => new BlogModel
            {
                Id = x.Id.ToString(),
                CategoryId = x.CategoryId,
                Text = x.Text,
                Link = x.Link,
                Title = x.Title
            }).ToListAsync();
            return result;
        }

        public async Task<string> UpdateAsync(BlogRequest request)
        {
            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(p => p.Id == new Guid(request.Id) && !p.IsDelete);

            if (blog == null)
            {
                throw new Exception("Blog not found");
            }

            blog.Link = request.Link;
            blog.Text = request.Text;
            blog.Title = request.Title;
            blog.CategoryId = request.CategoryId;
            blog.UpdatedDate = DateTime.UtcNow;
            //blog.UpdatedBy = new Guid(request.UserId);

            await _dbContext.SaveChangesAsync();

            return blog.Id.ToString();
        }
    }
}
