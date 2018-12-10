public class GameEndedEvent : CodeControl.Message
{
    public bool victory;

    public GameEndedEvent(bool victory)
    {
        this.victory = victory;
    }
}
