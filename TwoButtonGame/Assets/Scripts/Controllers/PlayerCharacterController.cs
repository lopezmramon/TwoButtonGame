using System;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public int playerID;

    private void Awake()
    {
        CodeControl.Message.AddListener<ChangePlayerLaneRequestEvent>(OnPlayerLaneChangeRequested);
    }

    private void OnPlayerLaneChangeRequested(ChangePlayerLaneRequestEvent obj)
    {
        if (playerID == obj.playerID)
        {
            ChangeLane(obj.destination);
        }
    }

    private void ChangeLane(Vector3 destination)
    {
        transform.position = destination;
    }
}
