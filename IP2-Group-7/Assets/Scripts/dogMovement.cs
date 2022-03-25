using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;

    Vector3 velocity;
    public float gravity = -5f;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    public bool isGrounded;

    public float dashTime;
    public float dashSpeed;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Vector3 zLock = transform.position;
        zLock.z = 0;
        transform.position = zLock;

        if (Input.GetKey(KeyCode.RightShift))
        {
            StartCoroutine(Dash());
        }

        IEnumerator Dash()
        {
            float timeChecker = Time.time;
        
            float x = Input.GetAxis("DogHorizontal");

            while (Time.time < timeChecker + dashTime)
            {
                Vector3 move = transform.right * x;
                controller.Move(move * dashSpeed * Time.deltaTime);                
                yield return null;
            }
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            velocity.y = 8f;            
        }



        float x = Input.GetAxis("DogHorizontal");

        Vector3 move = transform.right * x;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
