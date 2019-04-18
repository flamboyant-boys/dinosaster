using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "The Game State Manager", menuName = "State System/Managers/Game State Manager")]
public class GameStateManager : StateManager<GameState>
{
    public override void SetState(GameState gameState)
    {
        base.SetState(gameState);

        RaiseGameStateEvent(gameState);
    }

    private void RaiseGameStateEvent(GameState gameState)
    {
        gameState.RaiseCorrespondingEvent();
    }

}
