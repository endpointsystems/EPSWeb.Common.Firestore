using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPSWeb.Common.Firestore.Config;
using EPSWeb.Common.Firestore.Data.Blog;
using Microsoft.Extensions.Logging;

namespace EPSWeb.Common.Firestore.Repos
{
    public class BlogRepo: BaseRepo
    {
        public BlogRepo(FirestoreConfig firestoreConfig, ILogger<BlogRepo> logger) :
            base(firestoreConfig, logger)
        {
        }

        public async Task<BlogPost> AddPost(BlogPost post)
        {
            var ret = await db.Collection(config.BlogPath).AddAsync(post);
            post.id = ret;
            return post;
        }

        public async Task<BlogPost> GetPost(string postId)
        {
            var ret = await db.Collection(config.BlogPath).Document(postId).GetSnapshotAsync();
            return ret.ConvertTo<BlogPost>();
        }

        /// <summary>
        /// Set/get the doc in Firestore, remove/add in cache
        /// </summary>
        /// <param name="post">The blog post to update</param>
        /// <returns>The updated blog post</returns>
        public async Task<BlogPost> UpdatePost(BlogPost post)
        {
             await db.Collection(config.BlogPath).Document(post.id.Id).SetAsync(post);
             var ret = await db.Collection(config.BlogPath).Document(post.id.Id).GetSnapshotAsync();
             var p = ret.ConvertTo<BlogPost>();
             return p;
        }

        /// <summary>
        /// Get all blog posts from Firestore/cache
        /// </summary>
        /// <returns></returns>
        public async Task<List<BlogPost>> GetAllPosts()
        {
            var ret = await db.Collection(config.BlogPath).GetSnapshotAsync();
            return ret.Documents.Select(doc => doc.ConvertTo<BlogPost>()).ToList();
        }

        public async Task<BlogPost> AddComment(BlogPost post, BlogComment comment)
        {
            var ret = await db.Collection(config.BlogPath).Document(post.id.Id).Collection("comments")
                .AddAsync(comment);
            comment.id = ret;
            if (!post.BlogComments.Contains(comment)) post.BlogComments.Add(comment);
            return post;
        }

        public async Task<List<BlogComment>> GetComments(BlogPost post)
        {
            var ret = await db.Collection(config.BlogPath).Document(post.id.Id).Collection("comments").GetSnapshotAsync();
            var c = ret.Documents.Select(doc => doc.ConvertTo<BlogComment>()).ToList();
            post.BlogComments.Clear();
            post.BlogComments.AddRange(c);
            return c;
        }
    }
}
