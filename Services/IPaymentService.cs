using System.Threading.Tasks;

namespace KolokwiumDF.Services
{
    public interface IPaymentService
    {
        Task<int?> AddPaymentAsync(int idClient, int idSubscription, decimal paymentAmount);
    }
}
