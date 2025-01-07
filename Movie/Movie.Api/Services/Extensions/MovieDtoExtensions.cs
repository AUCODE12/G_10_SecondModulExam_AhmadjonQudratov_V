using Movie.Api.Services.DTOs;

namespace Movie.Api.Services.Extensions;

public static class MovieDtoExtensions
{
    public static double DurationMinutesToHour(this MovieDto movieDto)
    {
        var durationHour = movieDto.DurationMinutes / 60d;
        return durationHour;
    }

    public static long AllMovieBoxOfficeEarnings(this List<MovieDto> moviesDto)
    {
        var totalBox = 0l;
        foreach (var movie in moviesDto)
        {
            totalBox += movie.BoxOfficeEarnings;
        }
        return totalBox;
    }

}
