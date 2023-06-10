namespace Domain.Spaces;

public record struct Coordinate(int I, int J)
{
    public Coordinate ShiftedTo(Coordinate other)
    {
        return new Coordinate(I + other.I, J + other.J);
    }
}