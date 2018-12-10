public class SFXRequestEvent : CodeControl.Message
{
    public string sfxName;

    public SFXRequestEvent(string sfxName)
    {
        this.sfxName = sfxName;
    }
}
