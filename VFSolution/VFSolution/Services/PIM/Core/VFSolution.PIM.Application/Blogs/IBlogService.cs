using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VFSolution.PIM.Application.Blogs.Request;
using VFSolution.PIM.Application.Extentions;

namespace VFSolution.PIM.Application.Blogs
{
    public interface IBlogService
    {
        Task<bool> CreateAsync(BlogRequest request);

        Task<string> UpdateAsync(BlogRequest request);

        PagedResult<BlogModel> Get(CommonRequest request);

         Task<IEnumerable<BlogModel>> GetBlogs();

        Task<BlogModel> GetById(Guid id);

        Task<string> DeleteAsync(string Id);
    }
}
