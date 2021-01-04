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

        MoveShip();
        RotateShip();
        BobShip();
    }

    private void MoveShip()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0f, moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }

    private void RotateShip()
    {
      
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, -rotateSpeed * Time.deltaTime, 0f);
        }
    }
            
    private void BobShip()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, -moveSpeed * Time.deltaTime, 0f);
        }
    }

    private void DeathMotion()
    {
        transform.Rotate(0f, 0f, deathMotionSpeed * Time.deltaTime);
    }
}
