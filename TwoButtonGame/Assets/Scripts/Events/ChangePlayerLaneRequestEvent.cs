using UnityEngine;
public class ChangePlayerLaneRequestEvent : CodeControl.Message
{
    public Vector3 destination;
    public int playerID;
    public int lane;

    public ChangePlayerLaneRequestEvent(Vector3 destination, int playerID, int lane)
    {
        this.destination = destination;
        this.playerID = playerID;
        this.lane = lane;
    }
}
