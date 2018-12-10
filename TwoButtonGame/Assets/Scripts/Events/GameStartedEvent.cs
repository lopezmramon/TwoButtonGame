public class GameStartedEvent : CodeControl.Message
{
    public string levelName;
    public string playerName;

    public GameStartedEvent(string levelName, string playerName)
    {
        this.levelName = levelName;
        this.playerName = playerName;
    }
}
