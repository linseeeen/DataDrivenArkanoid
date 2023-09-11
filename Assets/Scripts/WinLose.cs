using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ball", menuName = "Arkanoid/WinLose", order = 4)]
public class WinLose : ScriptableObject
{
    [NonSerialized]public string winLose = "test";
    [NonSerialized]public int Points = 0;
    
}
