using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{

    
   [SerializeField]float steeringSpeed = 1.0f;
   [SerializeField]float movementSpeed = 3.5f;

   [SerializeField]float boostSpeed = 10.0f;
   [SerializeField]float slowSpeed = 3.5f;
    void Start()
    {
       


    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steeringSpeed *Time.deltaTime  ;
        float steerAmount2 = Input.GetAxis("Vertical") * movementSpeed *Time.deltaTime ;
       
        transform.Rotate( 0, 0, -steerAmount);
        transform.Translate (0 , steerAmount2 , 0);

       
        }

    private void OnTriggerEnter2D(Collider2D other)

    {
        
        if (other.tag == "Boost")
            {
            Debug.Log("BOOOOSTTTTTT!!!!!!");
            movementSpeed = boostSpeed;
            boostSpeed = 5.0f;
            Destroy(other.gameObject, 0.2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        movementSpeed = slowSpeed;
        slowSpeed = 3.5f;
    }


}

