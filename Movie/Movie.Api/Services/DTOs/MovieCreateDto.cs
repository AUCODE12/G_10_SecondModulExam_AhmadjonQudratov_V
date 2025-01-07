namespace Movie.Api.Services.DTOs;

public class MovieCreateDto
{
    public string Title { get; set; }

    public string Director { get; set; }

    public int DurationMinutes { get; set; }

    public double Rating { get; set; }

    public long BoxOfficeEarnings { get; set; }

    public DateTime ReleaceDate { get; set; }
}
