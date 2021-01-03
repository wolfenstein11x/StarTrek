using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMotion : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 50f;

    public float deathMotionSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<ShipHealth>().isAlive) 
        {
            DeathMotion();
            return; 
        }

        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 
                            0f, 
                            moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

        RotateShip();
        Bob();
    }

    private void RotateShip()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(-rotateSpeed * Time.deltaTime, 0f, 0f);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(rotateSpeed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, -rotateSpeed * Time.deltaTime, 0f);
        }
    }
            
    // delete Bob function
    private void Bob()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.H))
        {
            transform.Translate(0f, -moveSpeed * Time.deltaTime, 0f);
        }
    }

    private void DeathMotion()
    {
        transform.Rotate(0f, 0f, deathMotionSpeed * Time.deltaTime);
    }
}
