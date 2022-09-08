namespace semiOne;

public class CoordinateData
{
    public double Latitude { get; }
    public double Longitude { get; }
    public double Elevation { get; }
    public string LatitudeDirection { get; }
    public string LongitudeDirection { get; }

    public CoordinateData(double latitude, 
        double longitude, double elevation, 
        string latitudeDirection, string longitudeDirection)
    {
        Latitude = latitude;
        Longitude = longitude;
        Elevation = elevation;
        LatitudeDirection = latitudeDirection;
        LongitudeDirection = longitudeDirection;
    }

    public CoordinateData()
    {
        var random = new Random();
        Latitude = random.Next(0, 91);
        Longitude = random.Next(0, 181);
        Elevation = random.Next(0, 8000);
        LatitudeDirection = random.Next(0, 1) == 0 ? "North" : "South";
        LongitudeDirection = random.Next(0, 1) == 0 ? "Western" : "Eastern";
    }
}