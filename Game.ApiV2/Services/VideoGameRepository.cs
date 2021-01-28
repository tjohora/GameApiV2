using Game.ApiV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Services
{
    public class VideoGameRepository : IVideoGameRepository
    {
        private readonly GameApiContext _context;

        public VideoGameRepository(GameApiContext context)
        {
            _context = context;
        }

        public void CreateVideoGame(VideoGame game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            _context.VideoGames.Add(game);
        }

        public void DeleteVideoGame(VideoGame game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            _context.VideoGames.Remove(game);
        }

        public IEnumerable<VideoGame> GetAllVideoGames()
        {
            return _context.VideoGames.ToList();
        }

        public VideoGame GetVideoGameById(Guid VideoGameId)
        {
            return _context.VideoGames.FirstOrDefault(p => p.Id == VideoGameId);
        }

        public IEnumerable<VideoGame> GetVideoGamesByGenre(string genre)
        {
            List<VideoGame> videoGameList = new List<VideoGame>();

            foreach (var videoGame in _context.VideoGames)
            {
                if (videoGame.Genre1.ToLower().Equals(genre.ToLower()) || videoGame.Genre2.ToLower().Equals(genre.ToLower()))
                {
                    videoGameList.Add(videoGame);
                }
            }
            return videoGameList;
        }

        public IEnumerable<VideoGame> GetVideoGamesReleasedBeforeDate(DateTimeOffset date)
        {
            List<VideoGame> videoGameList = new List<VideoGame>();

            foreach (var videoGame in _context.VideoGames)
            {
                if (DateTimeOffset.Compare(videoGame.ReleaseDate, date) < 0)
                {
                    videoGameList.Add(videoGame);
                }
            }
            return videoGameList;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateVideoGame(VideoGame game)
        {
            
        }
    }
}
