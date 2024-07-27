
namespace Eclipse.Domain.Ships.Parts;

public record Part(Initiative Initiative, Computer Computer, Shield Shield, Hull Hull)
{
    public static readonly Part Empty = new(Initiative: 0, Computer: 0, Shield: 0, Hull: 0);
    
    public static Part operator +(Part a, Part b) => new(
        a.Initiative + b.Initiative,
        a.Computer + b.Computer,
        a.Shield + b.Shield,
        a.Hull + b.Hull
    );
}
