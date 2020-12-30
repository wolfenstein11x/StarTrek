using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorgMotion : MonoBehaviour
{
 
    [SerializeField] float rotateSpeed = 0.2f;
    [SerializeField] GameObject ShipToFollow;
    [SerializeField] float moveSpeedVertical = 10f;
    float verticalRange = 23f;

    // Start is called before the first frame update
    void Start()
    {
        
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        LevelWithPlayer();
    }

    private void LevelWithPlayer()
    {
        float yDiff =  ShipToFollow.transform.position.y - transform.position.y;

        if (Mathf.Abs(yDiff) < verticalRange) { return; }

        if (yDiff >= verticalRange)
        {
            transform.Translate(0f, moveSpeedVertical * Time.deltaTime, 0f);
        }

        else if (yDiff <= -verticalRange)
        {
            transform.Translate(0f, -moveSpeedVertical * Time.deltaTime, 0f);
        }
    }
}
