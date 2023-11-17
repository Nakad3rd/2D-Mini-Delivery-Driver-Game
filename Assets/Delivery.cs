using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour

{
    [SerializeField] float DestroyDelaySpeed = 1.0f;
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1 );
    [SerializeField] Color32 newPackageColor = new Color32 (1, 1 , 1, 1 );


    [SerializeField] float slowSpeed = 1.0f;
    [SerializeField] float boostSpeed = 1.0f;

    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    bool hasPackage;


    private void OnCollisionEnter2D (Collision2D other)

    {
        Debug.Log("Oops! The car has just collided");
    }

    private void OnTriggerEnter2D (Collider2D other)

    {

        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy (other.gameObject , DestroyDelaySpeed);
        }


        if (other.tag == "Customer" && hasPackage )
        {
            Debug.Log("Package delivered , take that W!");
            hasPackage = false;
            spriteRenderer.color = newPackageColor;
        }

        if (other.tag == "Boost")
        {
            boostSpeed = 50.2f;
        }

    }

}


