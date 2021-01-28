using AutoMapper;
using Game.ApiV2.Dtos;
using Game.ApiV2.Models;
using Game.ApiV2.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Controllers
{
    [Route("api/developers")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDeveloperRepository _repository;
        private readonly IMapper _mapper;

        public DevelopersController(IDeveloperRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //private readonly MockDeveloperRepository _repository = new MockDeveloperRepository();
        //GET api/developers
        [HttpGet]
        public ActionResult<IEnumerable<DeveloperReadDto>> GetAllDevelopers()
        {
            var developerItems = _repository.GetAllDevelopers();

            return Ok(_mapper.Map<IEnumerable<DeveloperReadDto>>(developerItems));
        }

        //GET api/developers/{developerId}
        [HttpGet("{developerId}", Name = "GetDeveloperById")]
        public ActionResult<DeveloperReadDto> GetDeveloperById(Guid developerId)
        {
            var developerItem = _repository.GetDeveloperById(developerId);

            if (developerItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DeveloperReadDto>(developerItem));
        }

        //POST api/developers
        [HttpPost]
        public ActionResult<DeveloperReadDto> CreateDeveloper(DeveloperCreateDto developerCreateDto)
        {
            var developerModel = _mapper.Map<Developer>(developerCreateDto);
            _repository.CreateDeveloper(developerModel);
            _repository.SaveChanges();

            var developerReadDto = _mapper.Map<DeveloperReadDto>(developerModel);

            return CreatedAtRoute(nameof(GetDeveloperById), new { developerId = developerReadDto.Id }, developerReadDto);
        }

        //PUT api/developers/{developerId}
        [HttpPut("{developerId}")]
        public ActionResult UpdateDeveloper(Guid developerId, DeveloperUpdateDto developerUpdateDto)
        {
            var developerModelFromRepo = _repository.GetDeveloperById(developerId);
            if(developerModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(developerUpdateDto, developerModelFromRepo);

            _repository.UpdateDeveloper(developerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        //PATCH api/developer/{developerId}
        [HttpPatch("{developerId}")]
        public ActionResult PartialDeveloperUpdate(Guid developerId, JsonPatchDocument<DeveloperUpdateDto> patchDocument)
        {
            var developerModelFromRepo = _repository.GetDeveloperById(developerId);
            if (developerModelFromRepo == null)
            {
                return NotFound();
            }

            var developerToPatch = _mapper.Map<DeveloperUpdateDto>(developerModelFromRepo);

            patchDocument.ApplyTo(developerToPatch, ModelState);
            if (!TryValidateModel(developerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(developerToPatch, developerModelFromRepo);

            _repository.UpdateDeveloper(developerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        //DELETE api/developer/{developerId}
        [HttpDelete("{developerId}")]
        public ActionResult DeleteDeveloper(Guid developerId)
        {
            var developerModelFromRepo = _repository.GetDeveloperById(developerId);
            if (developerModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteDeveloper(developerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpGet("detailed/{developerId}")]
        public ActionResult<DeveloperReadDto> GetDeveloperAndGames(Guid developerId)
        {
            var developerItem = _repository.GetDeveloperAndGames(developerId);

            if (developerItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DeveloperReadDto>(developerItem));
        }



    }
}
