namespace EPSWeb.Common.Firestore.Data
{
    /// <summary>
    /// Image is a class based on the metadata information provided by Cloudinary. It's in the Firestore library because
    /// a) the data is useful regardless of whether you're using Cloudinary or not, and b) we intend to use them very
    /// closely together.
    /// </summary>
    /// <see cref="https://cloudinary.com/documentation/dotnet_image_and_video_upload#_net_image_upload"/>
    public class Image
    {
        public string publicId { get; set; }
        public string version { get; set; }
        public string signature { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string format { get; set; }
        public string resourceType { get; set; }
        public string created { get; set; }
        public int bytes { get; set; }
        /// <summary>
        /// We store the secure url here. The 'unsecure' url is ignored. Nobody likes unsecure urls.
        /// </summary>
        public string url { get; set; }

    }
}
