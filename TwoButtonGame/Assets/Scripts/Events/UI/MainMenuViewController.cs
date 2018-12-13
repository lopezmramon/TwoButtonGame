using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuViewController : MonoBehaviour {    

	private void DispatchGameCountDownEvent()
    {
        CodeControl.Message.Send(new GameCountdownRequestEvent());
    }
}
