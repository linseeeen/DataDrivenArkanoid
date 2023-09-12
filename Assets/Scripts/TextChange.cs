using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChange : MonoBehaviour
{
    [Tooltip("The winlose object")]
    public WinLose winLoseObj;

    [Tooltip("Text object that displays if the player won or lost.")]
    public TMP_Text youLW;
    [Tooltip("Text object that displays the players points")]
    public TMP_Text Points;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(winLoseObj.winLose);
        youLW.text = winLoseObj.winLose;
        Points.text = winLoseObj.Points.ToString();
    }
}
