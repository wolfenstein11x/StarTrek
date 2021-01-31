using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction_Displayer : MonoBehaviour
{
    [SerializeField] GameObject[] Instructions;
    [SerializeField] GameObject Player;
    [SerializeField] Transform StartPoint;
    [SerializeField] Transform BorgReferencePoint;
    [SerializeField] Transform PylonReferencePoint;
    [SerializeField] int visibleTime = 5;

    private float borgMessageMarker;
    private float pylonMessageMarker;

    private Borg[] currentBorgCount;
    private int prevBorgCount;

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
        currentBorgCount = FindObjectsOfType<Borg>();
        prevBorgCount = currentBorgCount.Length;

        borgMessageMarker = Mathf.Abs(BorgReferencePoint.position.z);
        pylonMessageMarker = Mathf.Abs(PylonReferencePoint.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        CheckRanges();
        CheckBorgCount();
        PylonInstruction();
        BorgMessage();
    }

    private void CheckBorgCount()
    {
        currentBorgCount = FindObjectsOfType<Borg>();
        
        if (currentBorgCount.Length < prevBorgCount)
        {
            BorgDestroyedInstruction();
            prevBorgCount = currentBorgCount.Length;

        }
    }
    public void CheckRanges()
    {
        Vector3 distXYZ = Player.transform.position - StartPoint.position;
        float zDist = Mathf.Abs(distXYZ.z);
        
        if (zDist >= borgMessageMarker)
        {
            inBorgMessageRange = true;
        }

        else
        {
            inBorgMessageRange = false;
        }

        if (zDist >= pylonMessageMarker)
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
