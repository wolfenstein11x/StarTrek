using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorgAimer : MonoBehaviour
{
    public GameObject ObjectToFollow;
    public float rotateBufferMin = -0.5f;
    public float rotateBufferMax = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<ShipHealth>().isAlive) { return; }

        AimY();
        ShootAtPlayer();
    }

    public void ShootAtPlayer()
    {
        if (Mathf.Abs(transform.position.y - ObjectToFollow.transform.position.y) < 2.0f)
        {
            GetComponent<BorgShooting>().CountDownAndFire();
        }
    }

    private float GetAngleY()
    {
        Vector3 distXYZ = ObjectToFollow.transform.position - transform.position;
        float xDist = distXYZ.x;
        float yDist = distXYZ.y;
        float zDist = distXYZ.z;
        float angle = Mathf.Atan2(xDist, zDist);
        float angle_degrees = angle * Mathf.Rad2Deg;
        
        angle_degrees += 180f;

        float randomBuffer = Random.Range(rotateBufferMin, rotateBufferMax);
        angle_degrees += randomBuffer;
       
        //Debug.Log("Y Rotation: " + angle_degrees + " degrees");
        return angle_degrees;
    }


    // GetAngleX doesn't work yet
    private float GetAngleX()
    {
        Vector3 distXYZ = ObjectToFollow.transform.position - transform.position;
        float xDist = distXYZ.x;
        float yDist = distXYZ.y;
        float zDist = distXYZ.z;
        float angle = Mathf.Atan2(yDist, zDist);
        float angle_degrees = angle * Mathf.Rad2Deg;

        angle_degrees = 180 - angle_degrees;

        //Debug.Log("X Rotation: " + angle_degrees + " degrees");
        return angle_degrees;
    }

    private void AimX()
    {
        Vector3 rotateVector = new Vector3(GetAngleX(), 0f, 0f);
        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, rotateVector, Time.deltaTime);
    }

    private void AimY()
    {
        Vector3 rotateVector = new Vector3(0f, GetAngleY(), 0f);
        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, rotateVector, Time.deltaTime);
    }

    


}
