using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parrotPickup : MonoBehaviour
{
    public GameObject parrotKey;
    public GameObject key;
    public GameObject parrot;

    Vector3 parrotPosition;
    public float parrotRotation;

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

        if (keyHeld == true && Input.GetKey(KeyCode.F) && parrotRotation > 0)
        {
            key.transform.position = parrotPosition + new Vector3(1, 0, 0);
            parrotKey.SetActive(false);
            key.SetActive(true);
            keyHeld = false;
        }

        if (keyHeld == true && Input.GetKey(KeyCode.F) && parrotRotation < 0)
        {
            key.transform.position = parrotPosition + new Vector3(-1, 0, 0);
            parrotKey.SetActive(false);
            key.SetActive(true);
            keyHeld = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Interactable" && Input.GetKey(KeyCode.E))
        {
            parrotKey.SetActive(true);
            key.SetActive(false);
            keyHeld = true;
        }

        
    }

    void PositionTracker() 
    {
        parrotPosition = parrot.transform.position;
        parrotRotation = parrot.transform.rotation.y;
        
    }
}
