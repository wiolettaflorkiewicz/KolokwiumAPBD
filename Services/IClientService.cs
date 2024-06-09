using KolokwiumDF.DTOs;
using System.Threading.Tasks;

namespace KolokwiumDF.Services
{
    public interface IClientService
    {
        Task<ClientDto?> GetClientWithSubscriptionsAsync(int idClient);
    }
}
