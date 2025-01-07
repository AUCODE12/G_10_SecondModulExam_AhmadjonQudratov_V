using Movie.Api.DataAccess.Entities;
using System.Text.Json;

namespace Movie.Api.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly string _path;
    private readonly List<MovieEntity> _movies;

    public MovieRepository()
    {
        _path = "../../../DataAccess/Data/Movies.json";
        if(!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _movies = ReadAllMovies();
    }


    public void RemoveMovie(Guid movieId)
    {
        var fromDb = ReadMovieById(movieId);
        _movies.Remove(fromDb);
        SaveData();
    }

    public List<MovieEntity> ReadAllMovies()
    {
        var movieJson = File.ReadAllText(_path);
        var movieList = JsonSerializer.Deserialize<List<MovieEntity>>(movieJson);
        return movieList;
    }

    public MovieEntity ReadMovieById(Guid id)
    {
        foreach (var movie in _movies)
        {
            if (movie.Id == id)
            {
                return movie;
            }
        }

        throw new Exception($"{id} : Bunday Id mavjud emas");
    }

    public void UpdateMovie(MovieEntity updatingMovie)
    {
        var fromDb = ReadMovieById(updatingMovie.Id);
        var index = _movies.IndexOf(fromDb);
        _movies[index] = updatingMovie;
        SaveData();
    }
    public Guid WriteMovie(MovieEntity movie)
    {
        _movies.Add(movie);
        SaveData();
        return movie.Id;
    }

    private void SaveData()
    {
        var movieJson = JsonSerializer.Serialize(_movies);
        File.WriteAllText(_path, movieJson);
    }
}
