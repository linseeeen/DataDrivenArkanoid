using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private int childNumber;
    private int instanceNumber = 0;

    // Update is called once per frame
    void Update()
    {
        childNumber = transform.childCount;
    }
    
}
