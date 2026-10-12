using Club_Management_System.DTOs;
using Club_Management_System.Models;

namespace Club_Management_System.Repos.Interfaces
{
    public interface IPayment : IGenericRepo<Payment>
    {
        Task<PaymentDTO> GetPaymentWithStaticsAsync();
    }
}
