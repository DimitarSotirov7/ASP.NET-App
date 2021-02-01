using Application.Models.Films_Game;

namespace Application.Services.Films_Game.Contracts
{
    public interface IFilmsService
    {
        public bool CreateFilm(Film film);
    }
}
