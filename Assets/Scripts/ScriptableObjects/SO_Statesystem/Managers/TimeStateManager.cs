using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "The Time State Manager", menuName = "State System/Managers/Time State Manager")]
public class TimeStateManager : StateManager<TimeState> {

    public override void SetState(TimeState time_state)
    {
        base.SetState(time_state);

        SetTimescale(time_state);
        RaiseTimeStateEvent(time_state);
    }

    void SetTimescale(TimeState time_state)
    {
        Time.timeScale = time_state.stateTimescale;
    }

    void RaiseTimeStateEvent(TimeState time_state)
    {
        time_state.RaiseCorrespondingEvent();
    }
}
