using Movie.Api.DataAccess.Entities;
using Movie.Api.Repositories;
using Movie.Api.Services.DTOs;

namespace Movie.Api.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService()
    {
        _movieRepository = new MovieRepository();
    }

    public Guid AddMovie(MovieCreateDto movieCreateDto)
    {
        var movieId = _movieRepository.WriteMovie(ConverToEntity(movieCreateDto));
        return movieId;
    }

    public void DeleteMovie(Guid id)
    {
        _movieRepository.RemoveMovie(id);
    }

    public List<MovieDto> GetAllMovies()
    {
        var moviesEntity = _movieRepository.ReadAllMovies();
        var movies = new List<MovieDto>();
        foreach (var movie in moviesEntity)
        {
            movies.Add(ConvertToDto(movie));
        }
        return movies;
    }

    public List<MovieDto> GetAllMoviesByDirector(string director)
    {
        var moviesEntity = _movieRepository.ReadAllMovies();
        var movies = new List<MovieDto>();
        foreach (var movie in moviesEntity)
        {
            if (movie.Director == director)
            {
                movies.Add(ConvertToDto(movie));
            }
        }
        return movies;
    }

    public MovieDto GetHighestGrossingMovie()
    {
        var moviesEntity = _movieRepository.ReadAllMovies();
        var mostEarningsMovie = moviesEntity[0];
        for (int i = 1; i < moviesEntity.Count; i++)
        {
            if (moviesEntity[i].BoxOfficeEarnings > mostEarningsMovie.BoxOfficeEarnings)
            {
                mostEarningsMovie = moviesEntity[i];
            }
        }
        return ConvertToDto(mostEarningsMovie);
    }

    public MovieDto GetMovieById(Guid id)
    {
        var movieEntity = _movieRepository.ReadMovieById(id);
        return ConvertToDto(movieEntity);
    }

    public List<MovieDto> GetMoviesReleasedAfterYear(int year)
    {
        var moviesEntity = _movieRepository.ReadAllMovies();
        var movies = new List<MovieDto>();
        foreach (var movie in moviesEntity)
        {
            if (movie.ReleaceDate.Year > year)
            {
                movies.Add(ConvertToDto(movie));
            }
        }
        return movies;
    }

    public List<MovieDto> GetMoviesSortedByRating()
    {
        var moviesEntity = _movieRepository.ReadAllMovies();
        var movies = new List<MovieDto>();
        for (int i = 0; i < moviesEntity.Count; i++)
        {
            var topRatingMovie = moviesEntity[0];
            if (moviesEntity[i].Rating > topRatingMovie.Rating)
            {
                topRatingMovie = moviesEntity[i];
                movies.Add(ConvertToDto(topRatingMovie));
            }
            moviesEntity.Remove(topRatingMovie);
        }
        return movies;
    }

    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        var moviesEntity = _movieRepository.ReadAllMovies();
        var movies = new List<MovieDto>();
        foreach (var movie in moviesEntity)
        {
            if (movie.DurationMinutes >= minMinutes && movie.DurationMinutes <= maxMinutes)
            {
                movies.Add(ConvertToDto(movie));
            }
        }
        return movies;
    }

    public List<MovieDto> GetRecentMovies(int year)
    {
        var moviesEntity = _movieRepository.ReadAllMovies();
        var movies = new List<MovieDto>();
        foreach (var movie in moviesEntity)
        {
            if (movie.ReleaceDate.Year == year)
            {
                movies.Add(ConvertToDto(movie));
            }
        }
        return movies;
    }

    public MovieDto GetTopRatedMovie()
    {
        var moviesEntity = _movieRepository.ReadAllMovies();
        var topRatedMovie = moviesEntity[0];
        for (int i = 1; i < moviesEntity.Count; i++)
        {
            if (topRatedMovie.Rating < moviesEntity[i].Rating)
            {
                topRatedMovie = moviesEntity[i];
            }
        }
        return ConvertToDto(topRatedMovie);
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        var moviesEntity = _movieRepository.ReadAllMovies();
        var totalBox = 0l;
        foreach (var movie in moviesEntity)
        {
            if (movie.Director == director)
            {
                totalBox += movie.BoxOfficeEarnings;
            }
        }
        return totalBox;
    }

    public List<MovieDto> SearchMovieByTitle(string keyword)
    {
        var moviesEntity = _movieRepository.ReadAllMovies();
        var movies = new List<MovieDto>();
        foreach (var movie in moviesEntity)
        {
            if (movie.Title.Contains(keyword))
            {
                movies.Add(ConvertToDto(movie));
            }
        }
        return movies;
    }

    public void UpdateMovie(MovieDto updateMovieDto)
    {
        _movieRepository.UpdateMovie(ConverToEntity(updateMovieDto));
    }

    private MovieEntity ConverToEntity(MovieDto movieDto)
    {
        return new MovieEntity
        {
            BoxOfficeEarnings = movieDto.BoxOfficeEarnings,
            Director = movieDto.Director,
            Title = movieDto.Title,
            DurationMinutes = movieDto.DurationMinutes,
            Id = movieDto.Id,
            Rating = movieDto.Rating,
            ReleaceDate = movieDto.ReleaceDate,
        };
    }

    private MovieEntity ConverToEntity(MovieCreateDto movieCreateDto)
    {
        return new MovieEntity
        {
            BoxOfficeEarnings = movieCreateDto.BoxOfficeEarnings,
            Director = movieCreateDto.Director,
            Title = movieCreateDto.Title,
            DurationMinutes = movieCreateDto.DurationMinutes,
            Id = Guid.NewGuid(),
            Rating = movieCreateDto.Rating,
            ReleaceDate = movieCreateDto.ReleaceDate,
        };
    }

    private MovieDto ConvertToDto(MovieEntity movieEntity)
    {
        return new MovieDto
        {
            Id = movieEntity.Id,
            ReleaceDate = movieEntity.ReleaceDate,
            BoxOfficeEarnings = movieEntity.BoxOfficeEarnings,
            Director = movieEntity.Director,
            Title = movieEntity.Title,
            DurationMinutes = movieEntity.DurationMinutes,
            Rating = movieEntity.Rating,
        };
    }
}
