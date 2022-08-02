public record CustomerDto
{
    public string PhoneNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}