using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameEventListener : MonoBehaviour {

    [Tooltip("The Event this Listener will listen to.")]
    public GameEventReference gameEvent;

    [Tooltip("The Response to be invoked when the Event is raised.")]
    public UnityEvent response;


    private void OnEnable()
    {
        gameEvent.GameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.GameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }


}
