using Club_Management_System.Repos.Implementation;

namespace Club_Management_System.Repos.Interfaces
{
    public interface IUnitOfWork
    {
        BookingCustomRepo BookingCustomRepo { get; }
        PaymentCustomRepo PaymentCustomRepo { get; }
        MemberCustomRepo MemberCustomRepo { get; }
        MemberShipCustomRepo MemberShipCustomRepo { get; }
        FacilityCustomRepo FacilityCustomRepo { get; }
        AuthRepoCustomRepo AuthRepoCustomRepo { get; }
        Task SaveChangesAsync();

    }
}
