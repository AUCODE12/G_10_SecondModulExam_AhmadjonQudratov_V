using Movie.Api.Services.DTOs;

namespace Movie.Api.Services;

public interface IMovieService
{
    Guid AddMovie(MovieCreateDto movieCreateDto);

    List<MovieDto> GetAllMovies();

    MovieDto GetMovieById(Guid id);

    void UpdateMovie (MovieDto updateMovieDto);

    void DeleteMovie (Guid id);

    List<MovieDto> GetAllMoviesByDirector(string director);

    MovieDto GetTopRatedMovie();

    List<MovieDto> GetMoviesReleasedAfterYear(int year);

    MovieDto GetHighestGrossingMovie();

    List<MovieDto> SearchMovieByTitle(string keyword);

    List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes);

    long GetTotalBoxOfficeEarningsByDirector(string director);

    List<MovieDto> GetMoviesSortedByRating();

    List<MovieDto> GetRecentMovies(int year);
}