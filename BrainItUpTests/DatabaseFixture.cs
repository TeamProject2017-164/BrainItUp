using System;
using Xunit;
using DatabaseModels.Models;

namespace BrainItUpTests
{
    public class DatabaseFixture : IDisposable
    {
        public BrainItUpDatabaseEntities BrainItUp { get; private set; }
        public DatabaseFixture()
        {
            BrainItUp = new BrainItUpDatabaseEntities();
        }

        public void Dispose()
        {
            BrainItUp.Dispose();
        }
    }

    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

}
