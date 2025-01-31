using EntityFrameworkCore.Triggered;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Data.Triggers
{
    public class BaseUserDateTrigger : IBeforeSaveTrigger<UserDateIdentity>
    {
        private readonly TestWebAppDbContext _dbContext;
        public BaseUserDateTrigger(
            TestWebAppDbContext entityDbContext
            )
        {
            _dbContext = entityDbContext;
        }

        /// <summary>
        /// Sets automatically the name and date of data changes
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateException"></exception>
        public Task BeforeSave(ITriggerContext<UserDateIdentity> context, CancellationToken cancellationToken)
        {

            switch (context.ChangeType)
            {
                case ChangeType.Added:
                    context.Entity.Created = DateTime.Now;
                    context.Entity.LastEdited = DateTime.Now;
                    break;

                case ChangeType.Modified:
                    var originalValidTo = _dbContext.Entry(context.Entity).OriginalValues["ValidTo"];
                    var originalDeletedAt = _dbContext.Entry(context.Entity).OriginalValues["DeletedAt"];
                    if (originalValidTo != null && originalDeletedAt != null) // protection against rewriting later
                    {
                        throw new DbUpdateException();
                    }

                    context.Entity.LastEdited = DateTime.Now;
                    break;

                default: break;
            }
            return Task.CompletedTask;
        }
    }
}
