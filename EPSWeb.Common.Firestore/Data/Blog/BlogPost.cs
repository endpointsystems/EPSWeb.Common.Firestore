using System.Collections.Generic;
using Google.Cloud.Firestore;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace EPSWeb.Common.Firestore.Data.Blog
{
    [FirestoreData]
    public class BlogPost: BaseEntity
    {
            private List<BlogComment> _blogComments;

            /// <summary>
            /// Gets or sets the URL slug for the blog post
            /// </summary>
            [FirestoreProperty] public string slug { get; set; }

            /// <summary>
            /// Gets or sets the language identifier
            /// </summary>
            [FirestoreProperty] public int languageId { get; set; }

            /// <summary>
            /// Gets or sets the value indicating whether this blog post should be included in sitemap
            /// </summary>
            [FirestoreProperty] public bool includeInSiteMap { get; set; }

            /// <summary>
            /// Gets or sets the blog post title
            /// </summary>
            [FirestoreProperty] public string title { get; set; }

            /// <summary>
            /// Gets or sets the blog post body
            /// </summary>
            [FirestoreProperty] public string body { get; set; }

            /// <summary>
            /// Gets or sets the blog post overview. If specified, then it's used on the blog page instead of the "Body"
            /// </summary>
            [FirestoreProperty] public string overview { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the blog post comments are allowed
            /// </summary>
            [FirestoreProperty] public bool allowComments { get; set; }

            /// <summary>
            /// Gets or sets the blog tags
            /// </summary>
            [FirestoreProperty] public string tags { get; set; }

        /// <summary>
        /// Gets or sets the blog post start date and time
        /// </summary>
        [FirestoreProperty] public Timestamp? startDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the blog post end date and time
        /// </summary>
        [FirestoreProperty] public Timestamp? endDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the meta keywords
        /// </summary>
        [FirestoreProperty] public string metaKeywords { get; set; }

        /// <summary>
        /// Gets or sets the meta description
        /// </summary>
        [FirestoreProperty] public string metaDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta title
        /// </summary>
        [FirestoreProperty] public string metaTitle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        [FirestoreProperty] public virtual bool limitedToStores { get; set; }


        /// <summary>
        /// Gets or sets the blog comments
        /// </summary>
        public virtual List<BlogComment> BlogComments
        {
                get => _blogComments ??= new List<BlogComment>();
                protected set => _blogComments = value;
        }
    }
}
