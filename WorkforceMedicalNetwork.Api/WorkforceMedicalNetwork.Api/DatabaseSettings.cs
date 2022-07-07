using System;

namespace WorkforceMedicalNetwork.Api
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;
        public string LocationsCollectionName { get; set; } = null!;

    }
}

