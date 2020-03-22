using Google.Cloud.Firestore;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace EPSWeb.Common.Firestore.Data.Blog
{
    [FirestoreData]
    public class BlogComment: BaseEntity
    {
        [FirestoreProperty] public string title { get; set; }
        [FirestoreProperty] public string userId { get; set; }
        /// <summary>
        /// Gets or sets the comment text
        /// </summary>
        [FirestoreProperty] public string commentText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the comment is approved
        /// </summary>
        [FirestoreProperty] public bool isApproved { get; set; }

    }
}
