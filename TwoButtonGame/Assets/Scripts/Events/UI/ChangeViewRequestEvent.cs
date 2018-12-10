public class ChangeViewRequestEvent : CodeControl.Message
{
    public View view;

    public ChangeViewRequestEvent(View view)
    {
        this.view = view;
    }
}
