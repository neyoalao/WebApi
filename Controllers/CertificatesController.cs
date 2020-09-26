using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NsigVerificationAPI.Data;
using NsigVerificationAPI.Dtos;
using NsigVerificationAPI.Models;

namespace NsigVerificationAPI.Controllers
{
    [Route("api/certificates")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly INsigVerificationAPIRepo _repository;
        private readonly IMapper _mapper;

        public CertificatesController(INsigVerificationAPIRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //private readonly MockNsigVerificationAPIRepo _repository = new MockNsigVerificationAPIRepo();

        //responds to GET api/certificates
        [HttpGet]
        public ActionResult <IEnumerable<CertificateReadDto>> GetAllCertificates()
        {
            var certificateItems = _repository.GetAllCertificates();

            return Ok(_mapper.Map< IEnumerable<CertificateReadDto>>(certificateItems));
        }

        // responds to GET api/certificates/{id}
        [HttpGet("{id}", Name = "GetCertificateById")]
        public ActionResult <CertificateReadDto> GetCertificateById(int id)
        {
            var certificateItem = _repository.GetCertificateById(id);

            if   (certificateItem != null)
            {
                return Ok(_mapper.Map<CertificateReadDto>(certificateItem));
            }
            return NotFound(); 

        }

        //POST api/commands
        [HttpPost]
        public ActionResult <CertificateReadDto> CreateCertificate(CertificateCreateDto certificateCreateDto)
        {
            // used to Map the created certificate back to database and the save changes is needed so as to allow the saving of the created item to theh daatabase
            var certificateModel = _mapper.Map<Certificate>(certificateCreateDto);
            _repository.CreateCertificate(certificateModel);
            _repository.SaveChanges();

            // Variable used to return created certificate
            var certificateReadDto = _mapper.Map<CertificateReadDto>(certificateModel);

            //return Ok(certificateReadDto);
            return CreatedAtRoute(nameof(GetCertificateById), new { Id = certificateReadDto.Id }, certificateReadDto);
        }
    }
} 
