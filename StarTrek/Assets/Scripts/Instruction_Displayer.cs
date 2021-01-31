using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction_Displayer : MonoBehaviour
{
    [SerializeField] GameObject[] Instructions;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject ReferencePoint;
    [SerializeField] int visibleTime = 5;

    bool inBorgMessageRange;
    bool inPylonRange;

    bool pylonInstructionPlayed = false;
    bool weakspotInstructionPlayed = false;
    bool borgDestroyedInstructionPlayed = false;
    bool borgMessagePlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        DeactivateAllInstructions();
        StartCoroutine(FlashInstruction(0, 2, 3));
    }

    // Update is called once per frame
    void Update()
    {
        CheckRanges();
        PylonInstruction();
        BorgMessage();
    }
    public void CheckRanges()
    {
        Vector3 distXYZ = Player.transform.position - ReferencePoint.transform.position;
        float zDist = Mathf.Abs(distXYZ.z);
       
        if (zDist <= 550f)
        {
            inBorgMessageRange = true;
        }

        else
        {
            inBorgMessageRange = false;
        }

        if (zDist <= 200f)
        {
            inPylonRange = true;
        }

        else
        {
            inPylonRange = false;
        }
    }

    private void DeactivateAllInstructions()
    {
        foreach (GameObject instruction in Instructions)
        {
            instruction.SetActive(false);
        }
    }


    IEnumerator FlashInstruction(int idx, int waitTime, int visibleTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instructions[idx].SetActive(true);
        StartCoroutine(DeactivateInstruction(idx, visibleTime));
    }


    IEnumerator DeactivateInstruction(int idx, int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instructions[idx].SetActive(false);
    }

    
    private void PylonInstruction()
    {
        if (inPylonRange && !pylonInstructionPlayed)
        {
            StartCoroutine(FlashInstruction(1, 1, visibleTime));
            pylonInstructionPlayed = true;
        }
    }

    public void WeakspotDetectedInstruction()
    {
        StartCoroutine(FlashInstruction(2, 1, visibleTime));
    }

    public void BorgDestroyedInstruction()
    {
        StartCoroutine(FlashInstruction(3, 1, visibleTime));
    }

    private void BorgMessage()
    {
        if (inBorgMessageRange && !borgMessagePlayed)
        {
            StartCoroutine(FlashInstruction(4, 1, visibleTime));
            borgMessagePlayed = true;
        }
    }

    


}
