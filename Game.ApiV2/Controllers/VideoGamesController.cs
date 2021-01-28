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
    [Route("api/videoGames")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGameRepository _repository;
        private readonly IMapper _mapper;

        public VideoGamesController(IVideoGameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/videoGames
        [HttpGet]
        public ActionResult<IEnumerable<VideoGameReadDto>> GetAllVideoGames()
        {
            var videoGameItems = _repository.GetAllVideoGames();

            return Ok(_mapper.Map<IEnumerable<VideoGameReadDto>>(videoGameItems));
        }

        //GET api/videoGames/releasedbefore/{date}
        [HttpGet("releasedbefore/{date}")]
        public ActionResult<IEnumerable<VideoGameReadDto>> GetVideoGamesBeforeDate(DateTimeOffset date)
        {
            var videoGameItems = _repository.GetVideoGamesReleasedBeforeDate(date);

            return Ok(_mapper.Map<IEnumerable<VideoGameReadDto>>(videoGameItems));
        }

        //GET api/videoGames/genre/{genre}
        [HttpGet("genre/{genre}")]
        public ActionResult<IEnumerable<VideoGameReadDto>> GetVideoGamesByGenre(string genre)
        {
            var videoGameItems = _repository.GetVideoGamesByGenre(genre);

            return Ok(_mapper.Map<IEnumerable<VideoGameReadDto>>(videoGameItems));
        }

        //GET api/videoGames/{videoGameId}
        [HttpGet("{videoGameId}", Name = "GetVideoGameById")]
        public ActionResult<VideoGameReadDto> GetVideoGameById(Guid videoGameId)
        {
            var videoGameItem = _repository.GetVideoGameById(videoGameId);

            if (videoGameItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VideoGameReadDto>(videoGameItem));
        }

        //POST api/videoGames
        [HttpPost]
        public ActionResult<VideoGameCreateDto> CreateDeveloper(VideoGameCreateDto videoGameCreateDto)
        {
            var videoGameModel = _mapper.Map<VideoGame>(videoGameCreateDto);
            _repository.CreateVideoGame(videoGameModel);
            _repository.SaveChanges();

            var videoGameReadDto = _mapper.Map<VideoGameReadDto>(videoGameModel);

            return CreatedAtRoute(nameof(GetVideoGameById), new { videoGameId = videoGameReadDto.Id }, videoGameReadDto);
        }

        //PATCH api/videoGames/{videoGameId}
        [HttpPatch("{videoGameId}")]
        public ActionResult PartialVideoGameUpdate(Guid videoGameId, JsonPatchDocument<VideoGameCreateDto> patchDocument)
        {
            var videoGameModelFromRepo = _repository.GetVideoGameById(videoGameId);
            if (videoGameModelFromRepo == null)
            {
                return NotFound();
            }

            var videoGameToPatch = _mapper.Map<VideoGameCreateDto>(videoGameModelFromRepo);

            patchDocument.ApplyTo(videoGameToPatch, ModelState);
            if (!TryValidateModel(videoGameToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(videoGameToPatch, videoGameModelFromRepo);

            _repository.UpdateVideoGame(videoGameModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        //DELETE api/videoGames/{videoGames}
        [HttpDelete("{videoGames}")]
        public ActionResult DeleteVideoGame(Guid videoGameId)
        {
            var videoGameModelFromRepo = _repository.GetVideoGameById(videoGameId);
            if (videoGameModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteVideoGame(videoGameModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    }

}

