using AutoMapper;
using PeopleManagement.Helpers;
using PeopleManagement.Model.Models;
using PeopleManagement.Models;
using System;
using System.Linq;
using static PeopleManagement.Helpers.Enums;

namespace PeopleManagement.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ///TO DO
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.SN, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.NumberOfSubjects, opt => opt.MapFrom(src => src.Subjects.Count()))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => Extentions.CalculateAge(src.Birthday)))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == "M" ? (char)GenderEnum.Male : (char)GenderEnum.Female ));

            CreateMap<Subject, SubjectModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.SubjectName));
        }
    }

}