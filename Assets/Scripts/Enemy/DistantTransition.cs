using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistantTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
        {
            NeadTransit = true;
        }
    }
}
