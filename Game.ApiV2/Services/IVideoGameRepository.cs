using Game.ApiV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Services
{
    public interface IVideoGameRepository
    {
        IEnumerable<VideoGame> GetAllVideoGames();
        VideoGame GetVideoGameById(Guid VideoGameId);
        IEnumerable<VideoGame> GetVideoGamesReleasedBeforeDate(DateTimeOffset date);
        IEnumerable<VideoGame> GetVideoGamesByGenre(string genre);
        void CreateVideoGame(VideoGame game);
        void UpdateVideoGame(VideoGame game);
        void DeleteVideoGame(VideoGame game);
        bool SaveChanges();
    }
}
