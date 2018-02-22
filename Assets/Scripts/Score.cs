using System;
using System.Xml;

public class Score
{
    public string playerNick { get; set; }
    public int points { get; set; }

    public Score(string playerNick, int points)
    {
        this.playerNick = playerNick;
        this.points = points;    
    }

    public Score()
    {
    }

    public override string ToString()
    {
        return this.playerNick + "\t" + this.points;
    }

    internal static Score Deserialize(XmlNode node)
    {
        Score score = new Score();
        score.playerNick = node.SelectSingleNode("user").InnerText;
        score.points = int.Parse(node.SelectSingleNode("points").InnerText);

        return score;

    }
}
