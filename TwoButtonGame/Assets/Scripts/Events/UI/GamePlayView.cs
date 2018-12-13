using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayView : MonoBehaviour {

    private void Awake()
    {
        CodeControl.Message.AddListener<GameCountdownRequestEvent>(OnGameCountDownRequested);
    }

    private void OnGameCountDownRequested(GameCountdownRequestEvent obj)
    {
        Debug.Log("count down");
    }
}
