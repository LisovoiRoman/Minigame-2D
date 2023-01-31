using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Player Target { get; set; }

    public void Enter(Player target)
    {
        Target = target;
        enabled = true;

        foreach(var transition in _transitions)
        {
            transition.enabled = true;
            transition.Init(Target);
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeadTransit)
                return transition.TargetState;
        }

        return null;
    }

    public void Exit()
    {
        if (enabled == true)
            foreach (var transition in _transitions)
                transition.enabled = true;
        enabled = false;     
    }
}
