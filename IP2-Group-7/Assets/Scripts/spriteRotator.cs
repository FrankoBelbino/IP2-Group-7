using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteRotator : MonoBehaviour
{
    public GameObject parrot;

    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            parrot.transform.eulerAngles = new Vector3(0, -90, 0);
        }

        if (Input.GetKeyDown("d"))
        {
            parrot.transform.eulerAngles = new Vector3(0, 90, 0);
        }        
    }
}
