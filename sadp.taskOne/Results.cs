namespace sadp.taskOne;

public struct Results
{
    public readonly double Time;
    public readonly int ArraySize;

    public Results(double time, int arraySize)
    {
        Time = time;
        ArraySize = arraySize;
    }
}