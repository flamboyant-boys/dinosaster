using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleStageManager : StateManager<CircleStage>
{
    public override void SetState(CircleStage circleStage)
    {
        base.SetState(circleStage);

        RaiseGameStateEvent(circleStage);
    }

    private void RaiseGameStateEvent(CircleStage gameState)
    {
        gameState.RaiseCorrespondingEvent();
    }
}
