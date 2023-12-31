using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp", menuName = "Arkanoid/PowerUp", order = 2)]
public class PowerUp : ScriptableObject
{
    [Tooltip("Name of the powerup.+")]
    public string Name;
}
