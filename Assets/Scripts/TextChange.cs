using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChange : MonoBehaviour
{
    public WinLose winLoseObj;

    public TMP_Text youLW;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(winLoseObj.winLose);
        youLW.text = winLoseObj.winLose;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
