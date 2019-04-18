using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : ScriptableObject
{
    [Multiline]
    public string description = "This is a state";
    public GameEvent correspondingEvent;

    public void RaiseCorrespondingEvent()
    {
        correspondingEvent.Raise();
    }

}
