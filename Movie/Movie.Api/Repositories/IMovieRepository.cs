using Movie.Api.DataAccess.Entities;

namespace Movie.Api.Repositories;

public interface IMovieRepository
{
    Guid WriteMovie(MovieEntity movie);

    List<MovieEntity> ReadAllMovies();

    MovieEntity ReadMovieById(Guid id);

    void UpdateMovie(MovieEntity updatingMovie);

    void RemoveMovie(Guid movieId);
}