using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushBox : MonoBehaviour
{
    public static bool isDashing;
    public GameObject Dog;

    void Start()
    {
        
    }

    void Update()
    {
        isDashing = dogMovement.isDashing;        
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject == Dog && isDashing == true)
        {
            transform.position = transform.position + new Vector3(10, 0, 0);
        }
    }
}
