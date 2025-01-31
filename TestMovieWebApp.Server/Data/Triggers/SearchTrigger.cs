using EntityFrameworkCore.Triggered;
using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Data.Triggers
{
    public class SearchTrigger : IAfterSaveTrigger<UserDateIdentity>
    {
        public Task AfterSave(ITriggerContext<UserDateIdentity> context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
