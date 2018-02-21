public class Score
{
    private string playerNick { get; set; }
    private int points { get; set; }

    public Score(string playerNick, int points)
    {
        this.playerNick = playerNick;
        this.points = points;    
    }

    public override string ToString()
    {
        return this.playerNick + "\t\t\t\t\t\t\t\t\t\t\t" + this.points;
    }
}
