using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogPickup : MonoBehaviour
{
    public bool keyHeld;
    public GameObject door;
    public GameObject dogKey;
    public GameObject key;
    public GameObject dog;

    Vector3 dogPosition;
    public float dogRotation;

    void Start()
    {
        dogKey.SetActive(false);
        key.SetActive(true);
        keyHeld = false;                
    }

    void OnTriggerStay(Collider col)
    {
        
        if (col.gameObject.tag == "Interactable" && Input.GetKey(KeyCode.M))
        {
            dogKey.SetActive(true);
            key.SetActive(false);
            keyHeld = true;
        }

        if (keyHeld == true && Input.GetKey(KeyCode.N) && dogRotation > 0)
        {
            key.transform.position = dogPosition + new Vector3(1.5f, 0, 0);
            dogKey.SetActive(false);
            key.SetActive(true);            
            keyHeld = false;
        }

        if (keyHeld == true && Input.GetKey(KeyCode.N) && dogRotation < 0)
        {
            key.transform.position = dogPosition + new Vector3(-1.5f, 0, 0);
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
        //if (col.gameObject.tag == "pressurePlate1")
        //{
        //    col.gameObject.GetComponent<pressurePlate>().NotInteracting();
            
        //}
    }

    void Update()
    {
        PositionTracker();
    }

    void PositionTracker()
    {
        dogPosition = dog.transform.position;
        dogRotation = dog.transform.rotation.y;        
    }
}
