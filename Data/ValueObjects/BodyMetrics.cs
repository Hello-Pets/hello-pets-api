namespace HelloPets.Data.ValueObjects;

public class BodyMetrics : ValueObject, IEquatable<BodyMetrics>
{
    public decimal Height { get; private set; } = 0.0m;
    public decimal Length { get; private set; } = 0.0m;
    public decimal Weight { get; private set; } = 0.0m;

    public BodyMetrics(decimal height, decimal length, decimal weight)
    {
        Validate(height,length,weight);

        Height = height;
        Length = length;
        Weight = weight;
    }

    public BodyMetrics() {}

    private void Validate(decimal height, decimal length, decimal weight)
    {
        if(height < 0.0m || height > 4.00m) throw new ArgumentException("Pet height must be between 0 and 4 meters");

        if(length < 0.0m || length > 9.00m) throw new ArgumentException("Pet length must be between 0 and 9 meters");

        if(weight < 0.0m || weight > 800.0m) throw new ArgumentException("Pet weight must be between 0 and 800 kilograms");

    }

    public override int GetHashCode() => (Height + Length + Weight).GetHashCode();

    public bool Equals(BodyMetrics? bodyMetrics) => Height == bodyMetrics?.Height && Length == bodyMetrics.Length && Weight == bodyMetrics.Weight;
}