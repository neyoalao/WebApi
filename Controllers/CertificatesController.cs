using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCertificate(int id, CertificateUpdateDto certificateUpdateDto)
        {
            var certificateModelFromRepo = _repository.GetCertificateById(id);
            if (certificateModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(certificateUpdateDto, certificateModelFromRepo);

            _repository.UpdateCertificate(certificateModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CertificateUpdateDto> patchDocument)
        {

            // checks whether the respource exists
            var certificateModelFromRepo = _repository.GetCertificateById(id);
            if (certificateModelFromRepo == null)
            {
                return NotFound();
            }

            //Creating a new certificateupsatedto with the content from the repo
            var certificateToPatch = _mapper.Map<CertificateUpdateDto>(certificateModelFromRepo);
            patchDocument.ApplyTo(certificateToPatch, ModelState);
            if (TryValidateModel(certificateToPatch))
            {
                return ValidationProblem(ModelState);
            }

            //now updating the resource in the repo
            _mapper.Map(certificateToPatch, certificateModelFromRepo);
            _repository.UpdateCertificate(certificateModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCertificate(int id)
        {
            // checks whether the respource exists
            var certificateModelFromRepo = _repository.GetCertificateById(id);
            if (certificateModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCertificate(certificateModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
} 
