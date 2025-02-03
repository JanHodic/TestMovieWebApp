using EntityFrameworkCore.Triggered;
using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Data.Triggers
{
    public class SearchTrigger : IAfterSaveTrigger<UserDateIdentity>
    {
        /// <summary>
        /// Looks for duplicities among Actor records an erases them if necessary.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="DbUpdateException"></exception>
        public Task AfterSave(ITriggerContext<UserDateIdentity> context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
