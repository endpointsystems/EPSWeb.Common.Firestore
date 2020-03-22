using Google.Cloud.Firestore;

namespace EPSWeb.Common.Firestore.Data
{
    [FirestoreData]
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the Firestore document reference Id
        /// </summary>
        /// <remarks>This property is initialized and set by Firestore.</remarks>
        [FirestoreDocumentId] public DocumentReference id { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        [FirestoreDocumentCreateTimestamp] public Timestamp createdOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the timestamp for the last update (from Firestore)
        /// </summary>
        [FirestoreDocumentUpdateTimestamp] public Timestamp updatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the last read timestamp (from Firestore)
        /// </summary>
        [FirestoreDocumentReadTimestamp] public Timestamp lastReadUtc { get; set; }
    }
}
