﻿namespace semiOne;

public static class Program
{
    private static void Main()
    {
        var results = new List<List<Results>>();
        const int numberOfIterations = 7;
        for (var i = 0; i < numberOfIterations; i++)
        {
            results.Add(new List<Results>());
        }
        for (var sizeFactor = 0; sizeFactor < numberOfIterations; sizeFactor++)
        {
            var arraySize = (sizeFactor + 1) * 10000;
            for (var algorithmType = 1; algorithmType <= 3; algorithmType++)
            {
                var simulation = new Simulation(arraySize, algorithmType);
                results[sizeFactor].Add(new Results(simulation.ProcessSimulation(), arraySize));
            }
        }

        var streamWriter = new StreamWriter("results.txt", false);
        foreach (var result in results)
        {
            streamWriter.WriteLine($"{result[0].time},{result[0].arraySize},first\n");
            streamWriter.WriteLine($"{result[1].time},{result[1].arraySize},last\n");
            streamWriter.WriteLine($"{result[2].time},{result[2].arraySize},middle\n");
        }
        streamWriter.Close();
    }
}

