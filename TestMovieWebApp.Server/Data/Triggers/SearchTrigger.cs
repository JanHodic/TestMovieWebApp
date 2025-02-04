using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;
using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Data.Triggers
{
    public class SearchTrigger : IAfterSaveTrigger<UserDateIdentity>
    {
        private readonly TestWebAppDbContext _dbContext;
        public SearchTrigger(TestWebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Looks for duplicities among Actor records an erases them if necessary.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateException"></exception>
        public Task AfterSave(ITriggerContext<UserDateIdentity> context, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
