using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "The Circle Stage Manager", menuName = "State System/Managers/Circle Stage Manager")]
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
