using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Anim");
        anim.SetTrigger("Hit 0");
        Destroy(gameObject, 0.5f);
    }
}
