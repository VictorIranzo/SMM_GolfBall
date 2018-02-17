
using System.IO;
using UnityEngine;

public class DataController
{
    private static string gameDataFileName = "data.txt";

    public static void AddScore(Score s) {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }

        StreamWriter scoresFileStream = File.AppendText(filePath);

        scoresFileStream.WriteLine(s.ToString());
        scoresFileStream.Flush();
    }

    public static string GetScores()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (!File.Exists(filePath))
        {
            return "";
        }

        return File.ReadAllText(filePath);
    }
}
