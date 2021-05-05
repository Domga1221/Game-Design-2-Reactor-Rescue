using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "MovementDirections")]
public class EnemyDirections : ScriptableObject
{
    public enum Direction
    {
        UP,
        RIGHT,
        LEFT,
        DOWN,
        TURN_UP,
        TURN_RIGHT,
        TURN_LEFT,
        TURN_DOWN
    }

    public Direction[] directions;

}
