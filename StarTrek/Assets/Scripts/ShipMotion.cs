using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMotion : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 
                            0f, 
                            moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

        RotateShip();
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
}
