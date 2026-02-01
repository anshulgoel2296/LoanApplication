using AutoMapper;
using LoanApplicationAPI.DBModels;
using LoanApplicationAPI.RequestModels;

namespace LoanApplicationAPI.AutoMapper
{
    public class LoanApplicationAutoMapper: Profile
    {
        public LoanApplicationAutoMapper()
        {
            CreateMap<UserRequest, User>()
                .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<User, UserRequest>();

            CreateMap<LoanTypeRequest, LoanType>()
                .ForMember(dest => dest.LoanId, opt => opt.Ignore());

            CreateMap<LoanType, LoanTypeRequest>();

            CreateMap<ApplicationStatusRequest, ApplicationStatus>()
                .ForMember(dest => dest.StatusId, opt => opt.Ignore());

            CreateMap<ApplicationStatus, ApplicationStatusRequest>();

            CreateMap<LoanApplicationRequest, LoanApplication>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDateTime, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore());

            CreateMap<LoanApplication, LoanApplicationRequest>()
                .ForMember(dest => dest.LoanAmount, opt => opt.MapFrom(src => src.LoanAmount));
        }
    }
}
