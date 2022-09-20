namespace semiOne;

public class InsertionMethods
{
    public CoordinateData[] AlgorithmOne(int arrayLength)
    {
        var array = Array.Empty<CoordinateData>();
        for (var i = 0; i < arrayLength; i++)
        {
            array = array.Append(new CoordinateData()).ToArray();
        }

        return array;
    }

    /*
    public CoordinateData[] AlgorithmTwo(int arrayLength)
    {
        var array = Array.Empty<CoordinateData>();
        var random = new Random();
        for (var i = 0; i < 2; i++)
        {
            array = array.Append(new CoordinateData()).ToArray();
        }
        
        for (var i = 0; i < arrayLength; i++)
        {
            array.in  [random.Next(1, arrayLength)]
            array = array.Append(new CoordinateData()).ToArray();
        }

        return array;
    }
    */
    
    public CoordinateData[] AlgorithmThree(int arrayLength)
    {
        var ar = new int[30];
        var array = Array.Empty<CoordinateData>();
        for (var i = 0; i < arrayLength; i++)
        {
            var tempArray = array;
            var newArray = new CoordinateData[1];
            newArray[0] = new CoordinateData();
            array = newArray.Concat(tempArray).ToArray();
        }

        return array;
    }
}