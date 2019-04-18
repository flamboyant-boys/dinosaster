using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Circle Stage", menuName = "State System/States/Circle Stage")]
public class CircleStage : BaseState
{
    [SerializeField] float circleRadius = 100;
    [SerializeField] float morphTime = 20;
    [SerializeField] float idleTime = 10;

}
