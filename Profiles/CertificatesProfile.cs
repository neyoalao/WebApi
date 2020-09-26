using AutoMapper;
using NsigVerificationAPI.Dtos;
using NsigVerificationAPI.Models;

namespace NsigVerificationAPI.Profiles
{
    public class CertificatesProfile: Profile
    {
        public CertificatesProfile()
        {
            // source -> Target
            CreateMap<Certificate, CertificateReadDto>();


            CreateMap<CertificateCreateDto, Certificate>();
        }
    }
}
