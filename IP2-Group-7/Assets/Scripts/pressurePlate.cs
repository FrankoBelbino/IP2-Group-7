using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{

    public GameObject interactObject;
   
  

    public void Interacting()
    {
        interactObject.SetActive(false);
        
    }

    public void NotInteracting()
    {
        interactObject.SetActive(true);
       
    }
}
