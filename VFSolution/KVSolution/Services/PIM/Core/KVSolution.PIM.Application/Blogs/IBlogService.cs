using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KVSolution.PIM.Application.Blogs.Request;
using KVSolution.PIM.Application.Extentions;

namespace KVSolution.PIM.Application.Blogs
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
