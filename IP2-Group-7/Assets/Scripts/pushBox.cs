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
        Debug.Log(col.gameObject.name);
        if (col.gameObject == Dog && isDashing == true)
        {
            gameObject.transform.position = new Vector3(-11.08f, 1.54f, -0.355f);
        }
    }
}
