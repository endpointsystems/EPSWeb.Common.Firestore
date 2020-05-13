using Google.Cloud.Firestore;

namespace EPSWeb.Common.Firestore.Data
{
    /// <summary>
    /// Image is a class based on the metadata information provided by Cloudinary. It's in the Firestore library because
    /// a) the data is useful regardless of whether you're using Cloudinary or not, and b) we intend to use them very
    /// closely together.
    /// </summary>
    /// <see href="https://cloudinary.com/documentation/dotnet_image_and_video_upload#_net_image_upload"/>
    [FirestoreData]
    public class Image: BaseEntity
    {
        [FirestoreProperty] public string publicId { get; set; }
        [FirestoreProperty] public string version { get; set; }
        [FirestoreProperty] public string signature { get; set; }
        [FirestoreProperty] public int width { get; set; }
        [FirestoreProperty] public int height { get; set; }
        [FirestoreProperty] public string format { get; set; }
        [FirestoreProperty] public string resourceType { get; set; }
        [FirestoreProperty] public string created { get; set; }
        [FirestoreProperty] public long bytes { get; set; }

        /// <summary>
        /// We store the secure url here. The 'unsecure' url is ignored. Nobody likes unsecure urls.
        /// </summary>
        [FirestoreProperty] public string url { get; set; }
    }
}
