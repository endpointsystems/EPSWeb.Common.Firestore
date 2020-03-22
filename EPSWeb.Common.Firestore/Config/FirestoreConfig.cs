namespace EPSWeb.Common.Firestore.Config
{
    public class FirestoreConfig
    {
        /// <summary>
        /// The GCP project Id
        /// </summary>
        public string ProjectId { get; set; }
        /// <summary>
        /// If <c>true</c>, use the Emulator
        /// </summary>
        public bool Emulator { get; set; }
        /// <summary>
        /// The url to the emulator
        /// </summary>
        public string EmulatorUrl { get; set; }
        /// <summary>
        /// The port to the emulator URL
        /// </summary>
        public int EmulatorPort { get; set; }

        public string BlogPath { get; set; }
    }
}
