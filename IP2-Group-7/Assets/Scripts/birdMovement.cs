using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class birdMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;

    Vector3 velocity;
    public float gravity = -5f;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    public bool isGrounded;

    public int maxStamina = 10;
    public int currentStamina;

    public Stamina staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        staminaBar.SetMaxStamina(maxStamina);
        StartCoroutine("StaminaRegen");
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;            
        }        

        if (Input.GetButtonDown("Jump") && currentStamina > 0)
        {
            velocity.y = 5f;
            takeStamina(1);
        }       
       
        
       
        float x = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);       
    }

    IEnumerator StaminaRegen()
    {
        for (; ; )
        {
            
            if (isGrounded == true)
            {
                yield return new WaitForSeconds(0.5f);
                gainStamina(1);
            }
        }
    }

    void takeStamina(int staminaLost)
    {
        currentStamina -= staminaLost;

        staminaBar.SetStamina(currentStamina);
    }

    void gainStamina(int staminaGain)
    {
        currentStamina += staminaGain;

        staminaBar.SetStamina(currentStamina);
    }
}
