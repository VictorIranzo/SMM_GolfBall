
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using System.Linq;

public class DataController
{
    private static readonly string gameDataFileName = "data.xml";

    public static void AddScore(Score s) {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        XmlDocument xmlDoc = new XmlDocument();

        if (!File.Exists(filePath))
        {
            XmlNode docNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(docNode);

            XmlNode productsNode = xmlDoc.CreateElement("scores");
            xmlDoc.AppendChild(productsNode);

            xmlDoc.Save(filePath);
        }
        else
        {
            xmlDoc.Load(filePath);
        }

        XmlNode listScores = xmlDoc.SelectSingleNode("/scores");

        XmlNode scoreNode = xmlDoc.CreateElement("score");

        XmlNode userNode = xmlDoc.CreateElement("user");
        userNode.InnerText = s.playerNick;
        scoreNode.AppendChild(userNode);

        XmlNode pointsNode = xmlDoc.CreateElement("points");
        pointsNode.InnerText = s.points.ToString();
        scoreNode.AppendChild(pointsNode);

        listScores.AppendChild(scoreNode);

        xmlDoc.Save(filePath);

    }

    public static List<Score> GetScores()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (!File.Exists(filePath))
        {
            return new List<Score>();
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);

        XmlNodeList listScores = xmlDoc.SelectNodes("//score");
        IEnumerable<XmlNode> scoresNodes = listScores.Cast<XmlNode>();

        List<Score> scores = new List<Score>();
        foreach (XmlNode node in scoresNodes) {
            scores.Add(Score.Deserialize(node));
        }

        return scores.OrderByDescending(n => n.points).Take(3).ToList();
    }
}
