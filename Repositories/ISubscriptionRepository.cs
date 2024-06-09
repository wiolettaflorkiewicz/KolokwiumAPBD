using KolokwiumDF.Models;
using System.Threading.Tasks;

namespace KolokwiumDF.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<Subscription?> GetSubscriptionAsync(int idSubscription);
        Task<Sale?> GetLatestSaleAsync(int idClient, int idSubscription);
    }
}
