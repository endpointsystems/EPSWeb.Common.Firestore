using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EPSWeb.Common.Firestore.Config;
using EPSWeb.Common.Firestore.Data.Blog;
using EPSWeb.Common.Firestore.Repos;
using Google.Cloud.Firestore;
using LoremNET;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace EPSWeb.Common.Firestore.Test
{
    public class BlogTest
    {
        private readonly ITestOutputHelper output;
        private readonly ILogger<BlogRepo> log;
        private readonly BlogRepo blog;
        private readonly List<BlogPost> posts;
        public BlogTest(ITestOutputHelper outputHelper)
        {
            //for consistency:
            //gcloud beta emulators firestore start --host-port=localhost:8888 --
            Environment.SetEnvironmentVariable("FIRESTORE_EMULATOR_HOST","localhost:8888");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS","/raid/repos/epsweb-firestore/EPSWeb.Common.Firestore/epsweb-217515-5631b4260996.json");
            //Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS","/your/credential/key.json");
            output = outputHelper;
            log = output.BuildLoggerFor<BlogRepo>();

            blog = new BlogRepo(new FirestoreConfig
            {
                Root = "blogtest",
                Emulator = true,
                EmulatorUrl = "http://localhost:8888",
                EmulatorPort = 8888,
                ProjectId = "epsweb-217515"
            }, log);

            posts = new List<BlogPost>();

            for (int i = 0; i < 20; i++)
            {
                posts.Add(new BlogPost
                {
                    body = Lorem.Paragraphs(500, 250, 3).ToCombinedString(),
                    overview = Lorem.Sentence(10),
                    tags = Lorem.Words(5).Split(',').ToCombinedString(),
                    title = $"blog post {i}",
                    slug = $"blog-post-{i}"
                });
            }
        }

        [Fact]
        public async Task TestAddBlogPostsAndComments()
        {
            foreach (var post in posts)
            {
                var p = await blog.AddPost(post);
                Assert.NotNull(p.id);

                for (int i = 0; i < 5; i++)
                {
                    await blog.AddComment(post, new BlogComment
                    {
                        commentText = $"comment {i} for blog post '{post.title}",
                        isApproved = true,
                        userId = $"user{i}"
                    });
                }
            }
        }

        [Fact]
        public async Task TestGetBlogPostsAndComments()
        {
            var ps = await blog.GetAllPosts();
            foreach (var p in ps)
            {
                var pc = await blog.GetComments(p);
                foreach (var comment in p.BlogComments)
                {
                    Assert.NotNull(p.id);
                    Assert.NotEqual(p.createdOnUtc,Timestamp.FromDateTime(DateTime.MinValue.ToUniversalTime()));
                    Assert.NotEqual(p.lastReadUtc, Timestamp.FromDateTime(DateTime.MinValue.ToUniversalTime()));
                    log.LogInformation(p.createdOnUtc.ToString());
                    log.LogInformation(p.lastReadUtc.ToString());
                }
                Assert.Equal(pc.Count,p.BlogComments.Count);
            }
        }
    }
}
