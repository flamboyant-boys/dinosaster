using UnityEngine;
using System.Collections.Generic;


public class StateManager<T> : ScriptableObject {

    public List<T> possibleStates = new List<T>();
    [SerializeField]
    protected T currentState;

    public T CurrentState
    {
        get
        {
            return currentState;
        }
    }

    public virtual void SetState(T state)
    {
        if (possibleStates.Contains(state))
            currentState = state;
        else
        {
            Debug.Log("", this);
            throw new System.Exception("Can not set State, " + this.ToString() + " is missing the " + state.ToString() + " State.");
        }

    }

    private void OnEnable()
    {
        if (currentState == null && possibleStates.Count != 0)
            currentState = possibleStates[0];
            
    }




}
