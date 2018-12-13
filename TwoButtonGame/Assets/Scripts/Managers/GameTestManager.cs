using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTestManager : MonoBehaviour
{

    private void Start()
    {
        DispatchTilesRequestEvent();
    }

    private void DispatchTilesRequestEvent()
    {
        CodeControl.Message.Send(new TilesRequestEvent(null, 89, 90, 100, 4));
    }
}
