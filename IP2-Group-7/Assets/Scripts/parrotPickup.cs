using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parrotPickup : MonoBehaviour
{        
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Interactable" && Input.GetKeyDown("e"))
        {
            print("im tired help me");
        }
    }
}
