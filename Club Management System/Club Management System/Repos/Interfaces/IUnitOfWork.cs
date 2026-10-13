using Club_Management_System.Repos.Implementation;

namespace Club_Management_System.Repos.Interfaces
{
    public interface IUnitOfWork
    {
        IBooking BookingCustomRepo { get; }
        IPayment PaymentCustomRepo { get; }
        IMember MemberCustomRepo { get; }
        IMemberShip MemberShipCustomRepo { get; }
        IFacility FacilityCustomRepo { get; }
        IAuthRepo AuthRepoCustomRepo { get; }
        Task SaveChangesAsync();

    }
}
