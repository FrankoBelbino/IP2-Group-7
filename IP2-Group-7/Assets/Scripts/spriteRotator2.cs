using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteRotator2 : MonoBehaviour
{
    public GameObject dog;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dog.transform.eulerAngles = new Vector3(0, -90, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dog.transform.eulerAngles = new Vector3(0, 90, 0);
        }

    }
}
