using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "The Circle Stage Manager", menuName = "State System/Managers/Circle Stage Manager")]
public class CircleStageManager : StateManager<CircleStage>
{
    int stageIndex = 0;

    private void OnEnable()
    {
        stageIndex = 0;
        SetState(possibleStates[stageIndex]);
    }

    public void setNextStage()
    {
        if (stageIndex + 1 < possibleStates.Count)
            SetState(possibleStates[++stageIndex]);

    }

    public void setPreviousStage()
    {
        if (stageIndex - 1 > 0)
            SetState(possibleStates[--stageIndex]);
    }


    public override void SetState(CircleStage circleStage)
    {
        base.SetState(circleStage);
        Debug.Log(circleStage);
        RaiseGameStateEvent(circleStage);
    }

    private void RaiseGameStateEvent(CircleStage gameState)
    {
        gameState.RaiseCorrespondingEvent();
    }
}
