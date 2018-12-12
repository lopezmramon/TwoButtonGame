public class ChangeScoreRequestEvent : CodeControl.Message
{
    public int change;

    public ChangeScoreRequestEvent(int change)
    {
        this.change = change;
    }
}
