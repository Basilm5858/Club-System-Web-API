using AutoMapper;
using Club_Management_System.DTOs;
using Club_Management_System.Models;

namespace Club_Management_System.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDTO>();
            CreateMap<CreateMemberDTO, Member>();
            CreateMap<UpdateMemberDTO, Member>();

            CreateMap<Membership, MembershipDTO>();
            CreateMap<CreateMembershipDTO, Membership>();
            CreateMap<UpdateMembershipDTO, Membership>();

            CreateMap<Facility, FacilityDTO>();
            CreateMap<CreateFacilityDTO, Facility>();
            CreateMap<UpdateFacilityDTO, Facility>();

            CreateMap<Booking, BookingDTO>();
            CreateMap<CreateBookingDTO, Booking>();
            CreateMap<UpdateBookingDTO, Booking>();

        }
    }
}
