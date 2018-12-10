public class ScoreChangedEvent : CodeControl.Message
{
    public int score;

    public ScoreChangedEvent(int score)
    {
        this.score = score;
    }
}
