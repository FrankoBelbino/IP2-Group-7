using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogPickup : MonoBehaviour
{
    public bool keyHeld;
    public GameObject door;
    public GameObject dogKey;
    public GameObject key;

    void Start()
    {
        dogKey.SetActive(false);
        key.SetActive(true);
        keyHeld = false;                
    }

    void OnTriggerStay(Collider col)
    {
        print(col.name);
        if (col.gameObject.tag == "Interactable" && Input.GetKey(KeyCode.M))
        {
            dogKey.SetActive(true);
            key.SetActive(false);
            keyHeld = true;
        }

        if (keyHeld == true && Input.GetKey(KeyCode.N))
        {
            dogKey.SetActive(false);
            key.SetActive(true);            
            keyHeld = false;
        }

        if (col.gameObject.tag == "door" && keyHeld == true)
        {            
            dogKey.SetActive(false);
            door.SetActive(false);
        }

        if (col.gameObject.tag == "pressurePlate1")
        {
            col.gameObject.GetComponent<pressurePlate>().Interacting();
           
        }        
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "pressurePlate1")
        {
            col.gameObject.GetComponent<pressurePlate>().NotInteracting();
            
        }
    }

    void Update()
    {
        
    }
}
