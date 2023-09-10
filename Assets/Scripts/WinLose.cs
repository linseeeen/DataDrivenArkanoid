using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ball", menuName = "Arkanoid/WinLose", order = 4)]
public class WinLose : ScriptableObject
{
    public string winLose;
    public int Points = 0;
    
}
