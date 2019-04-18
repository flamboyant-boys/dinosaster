using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameEventReference  {

    [SerializeField]
    bool useSOGameEvent = true;
    [SerializeField]
    GameEvent soGameEvent;
    [SerializeField]
    MonoBehaviour gameEventFromMono;

    public IGameEvent GameEvent
    {
        get
        {
            if(useSOGameEvent == true)
            {
                return soGameEvent;
            }
            else
            {
                if(gameEventFromMono.GetComponent<IMonoEvent>() != null)
                {
                    return gameEventFromMono.GetComponent<IMonoEvent>().GetGameEvent;
                }
                else
                {
                    throw new Exception("Given MonoBehaviour needs to inherit from " + typeof(IMonoEvent) + " and have a Event assigned to it!");
                }
            }
        }
    }


}
