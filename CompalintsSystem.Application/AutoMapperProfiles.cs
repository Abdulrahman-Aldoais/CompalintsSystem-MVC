using AutoMapper;
using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels;
namespace CompalintsSystem.Application
{
    public class UploadProfile : Profile
    {
        public UploadProfile()
        {

            CreateMap<InputCompmallintVM, UploadsComplainte>()
            .ForMember(u => u.Id, op => op.Ignore())
            .ForMember(u => u.UploadDate, op => op.Ignore());

            CreateMap<AddCommunicationVM, UsersCommunication>()
             .ForMember(u => u.Id, op => op.Ignore());
            CreateMap<UploadsComplainte, InputCompmallintVM>();
            CreateMap<UsersCommunication, AddCommunicationVM>();
        }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<ApplicationUser, AddUserViewModel>()
                .ForMember(u => u.Password, op => op.MapFrom(u => u.PasswordHash != null));
            CreateMap<ApplicationUser, UserProfileEditVM>();
            CreateMap<ApplicationUser, UserViewModels>();
            CreateMap<ApplicationUser, ChangePasswordViewModel>();




        }

    }
}
