using KolokwiumDF.Models;
using System.Threading.Tasks;

namespace KolokwiumDF.Repositories
{
    public interface IClientRepository
    {
        Task<Client?> GetClientAsync(int idClient);
        Task<Client?> GetClientWithSubscriptionsAsync(int idClient);
        Task<int?> GetClientDiscountAsync(int idClient);
    }
}
