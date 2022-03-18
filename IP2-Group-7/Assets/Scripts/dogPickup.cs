using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogPickup : MonoBehaviour
{
    public bool keyHeld;
    public GameObject door;

    void Start()
    {
        keyHeld = false;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Interactable" && Input.GetKey(KeyCode.M))
        {            
            keyHeld = true;
        }

        if (col.gameObject.tag == "door" && keyHeld == true)
        {
            print("monster made me less tired");
            door.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
