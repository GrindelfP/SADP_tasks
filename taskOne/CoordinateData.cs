namespace taskOne;

public class CoordinateData
{
    private readonly double _latitude;
    private readonly double _longitude;
    private readonly double _elevation;
    private readonly string _latitudeDirection;
    private readonly string _longitudeDirection;
    
    public CoordinateData()
    {
        var random = new Random();
        _latitude = random.Next(0, 91);
        _longitude = random.Next(0, 181);
        _elevation = random.Next(0, 8000);
        _latitudeDirection = random.Next(0, 1) == 0 ? "North" : "South";
        _longitudeDirection = random.Next(0, 1) == 0 ? "Western" : "Eastern";
    }
}