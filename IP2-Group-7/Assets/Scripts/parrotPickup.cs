using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parrotPickup : MonoBehaviour
{
    public GameObject parrotKey;
    public GameObject key;
    public GameObject parrot;

    Vector3 parrotPosition;

    public bool keyHeld;

    void Start()
    {
        parrotKey.SetActive(false);
        key.SetActive(true);
        keyHeld = false;
        
    }

    void Update()
    {
        PositionTracker();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Interactable" && Input.GetKey(KeyCode.E))
        {
            parrotKey.SetActive(true);
            key.SetActive(false);
            keyHeld = true;
        }

        if (keyHeld == true && Input.GetKey(KeyCode.F))
        {
            key.transform.position = parrotPosition + new Vector3(1, 0, 0);
            parrotKey.SetActive(false);
            key.SetActive(true);            
            keyHeld = false;            
        }
    }

    void PositionTracker() 
    {
        parrotPosition = parrot.transform.position;

    }
}
