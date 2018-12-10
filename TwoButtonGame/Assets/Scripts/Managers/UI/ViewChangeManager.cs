using System;
using UnityEngine;
using UnityEngine.UI;
public class ViewChangeManager : MonoBehaviour
{
    public Button[] buttons; // para el view, se agregan los botones o en el Canvas
    public GameObject[] views;

    private void Awake()
    {
        CodeControl.Message.AddListener<ChangeViewRequestEvent>(OnViewChangeRequested);        
    }
   

    private void OnViewChangeRequested(ChangeViewRequestEvent obj)
    {
        throw new NotImplementedException();
    }

    private void ChangeView(View view)
    {
        //Code to change view, something like:
        DeactivateViews();
        switch (view)
        {
            case View.MainMenu:
                views[(int)view].SetActive(true);
                break;
        }
    }
    private void DeactivateViews()
    {
        //Deactivate views with a foreach
    }
    //Esto no va aca, es un ejemplo para tu ViewController
    private void SetupButtons()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() =>
            {
                DispatchChangeViewRequestEvent(View.MainMenu); // if this was the main menu button
            });
        }
    }

    private void DispatchChangeViewRequestEvent(View view)
    {
        CodeControl.Message.Send(new ChangeViewRequestEvent(view));
    }
}
