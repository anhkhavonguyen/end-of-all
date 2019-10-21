using KVSolution.PIM.Application.Blogs;
using KVSolution.PIM.Application.Blogs.Request;
using KVSolution.PIM.Persistence;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace KVSolution.PIM.UnitTest
{
    [TestFixture]
    public class TestBlogService
    {
        private Mock<KVDbContext> _mockDBContext;

        private Mock<IBlogService> _blogService;

        [SetUp]
        public void Setup()
        {
            _blogService = new Mock<IBlogService>();
            _mockDBContext = new Mock<KVDbContext>();
        }

        [Test]
        public async Task Add_Blog_Success()
        {
            BlogRequest request = new BlogRequest()
            {
                Link = "https://scalyr.com/blog/microservices-communication-how-to-share-data-between-microservices",
                Text = "For some, the ideal picture of a modern application is a collection of microservices that stand alone. This perfect design isolates each service with a unique set of messages and operations.",
                Title = "MICROSERVICES COMMUNICATION: HOW TO SHARE DATA FOR SUCCESS",
                CategoryId = "0055e3d5-7c43-475e-a2e4-da15797b1fd8"
            };

            _blogService.Setup(s => s.CreateAsync(request)).Returns(Task.FromResult<bool>(true));

            var result = await _blogService.Object.CreateAsync(request);

            Assert.IsTrue(result, "Add Blog Success");
        }
    }
}