using System;
using EPSWeb.Common.Firestore.Config;
using Google.Api.Gax;
using Google.Cloud.Firestore;
using Microsoft.Extensions.Logging;

namespace EPSWeb.Common.Firestore.Repos
{
    public class BaseRepo
    {
        protected readonly FirestoreConfig config;
        protected readonly FirestoreDb db;
        protected readonly ILogger log;

        protected BaseRepo(FirestoreConfig firestoreConfig, ILogger logger)
        {
            log = logger;
            config = firestoreConfig;
            if (config.Emulator)
            {
                if (string.IsNullOrEmpty(config.EmulatorUrl))
                    throw new MissingFieldException(nameof(config.EmulatorUrl));


                var fb = new FirestoreDbBuilder
                {
                    ProjectId = config.ProjectId,
                    EmulatorDetection = EmulatorDetection.EmulatorOnly
                };

                db = fb.Build();
                return;
            }
            db = FirestoreDb.Create(config.ProjectId);
        }

        public FirestoreDb Database => db;
    }

}
