namespace taskOne;

public class Simulation
{
    private readonly int _arraySize;
    private readonly int _algorithmType;
    
    public double ProcessSimulation()
    {
        var array = new CoordinateData[_arraySize];
        var count = 0;
        var random = new Random();
        
        var timeManager = new TimeManager();
        timeManager.SetStartTime();

        for (var i = 0; i < array.Length; i++)
        {
            var newElement = new CoordinateData();
            var insertionIndex = _algorithmType switch
            {
                1 => 0,
                2 => count,
                _ => random.Next(0, count)
            };

            for (var j = count; j > insertionIndex; j--)
            {
                array[j] = array[j - 1];
            }

            array[insertionIndex] = newElement;
            count++;
        }
        timeManager.SetEndTime();

        return timeManager.GetExecutionTime();
    }

    public Simulation(int arraySize, int algorithmType)
    {
        _arraySize = arraySize;
        _algorithmType = algorithmType;
    }
}