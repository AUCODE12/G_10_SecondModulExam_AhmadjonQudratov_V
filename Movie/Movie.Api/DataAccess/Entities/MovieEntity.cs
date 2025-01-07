namespace Movie.Api.DataAccess.Entities;

public class MovieEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Director { get; set; }

    public int DurationMinutes { get; set; }

    public double Rating { get; set; }

    public long BoxOfficeEarnings { get; set; }

    public DateTime ReleaceDate { get; set; }
}
