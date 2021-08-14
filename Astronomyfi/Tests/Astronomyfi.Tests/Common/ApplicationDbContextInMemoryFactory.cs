namespace Astronomyfi.Services.Data.Tests.Common
{
    using System;

    using Astronomyfi.Data;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContextInMemoryFactory
    {
        public static ApplicationDbContext InitializeContext
        {
            get
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

                return new ApplicationDbContext(options);
            }
        }
    }
}
