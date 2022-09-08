namespace semiOne;

public struct TimeManager
{
    //TODO: change milliseconds from double to long
    private double _startTime;
    private double _endTime;

    public override string ToString()
    {
        return $"{GetExecutionTime()} seconds elapsed since the start of the execution";
    }

    public double GetExecutionTime() => (_endTime - _startTime)/1000.0;
    
    public void SetStartTime()
    {
        _startTime = GetCurrentTimeInSeconds();
    }
    
    public void SetEndTime()
    {
        _endTime = GetCurrentTimeInSeconds();
    }

    private static double GetCurrentTimeInSeconds()
    {
        return Convert.ToDouble(DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds);
    }

}