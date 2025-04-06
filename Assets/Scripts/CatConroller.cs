using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Collections;
using UnityEngine;

public class CatConroller : MonoBehaviour
{
    public Transform cameraTransform;

    public float distance;
    public float offsetRight; 
    public float offsetUp; 
    public float hoverHeight;  // Hover height (how much it moves up and down)
    public float hoverSpeed;     // Speed of the hover effect

    public OVRHand leftHand;   
    public OVRHand rightHand;   
    public float grabDistance = 0.2f;  // Distance from hand to object for grab detection
    public bool grabbedObject = false;

    public GameObject dictObject;
    DictationScript dictationScript;

    // public bool finishedSpeaking;
    public GameObject happy;
    public GameObject closedEyes;
    public GameObject openMouth;
    public string lastSpoken = "";
    public bool isTalking = false;


    void Start()
    {
        dictationScript = dictObject.GetComponent<DictationScript>();
    }

    void Update()
    {
        Vector3 newPosition = cameraTransform.position + cameraTransform.forward * distance;
        
        Vector3 offsetR = cameraTransform.right * offsetRight;
        Vector3 offsetU = cameraTransform.up * offsetUp; 
        newPosition += offsetR + offsetU;

        // floating effect (hover)
        newPosition.y += Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

        transform.position = newPosition;
        transform.LookAt(cameraTransform);

        TryGrab(leftHand, rightHand);

        if (grabbedObject && happy.activeSelf == true) {
            closedEyes.SetActive(true);
            happy.SetActive(false);
        }
        else if (!grabbedObject && happy.activeSelf == false) {
            closedEyes.SetActive(false);
            happy.SetActive(true);
        }

        if (!dictationScript.finishedSpeaking && dictationScript.spokenText != lastSpoken && !isTalking)
        {
            StartCoroutine(talkingMode());
        }

        lastSpoken = dictationScript.spokenText;
    }

    IEnumerator talkingMode()
    {
        isTalking = true;

        while (true)
        {
            openMouth.SetActive(!openMouth.activeSelf);
            yield return new WaitForSeconds(0.15f);
            
            if (dictationScript.finishedSpeaking)
            {
                isTalking = false;
                openMouth.SetActive(false);
                yield break;
            }
        }
    }


    void TryGrab(OVRHand lHand, OVRHand rHand)
    {
        if ((lHand.GetFingerIsPinching(OVRHand.HandFinger.Index) || rHand.GetFingerIsPinching(OVRHand.HandFinger.Index)) && grabbedObject == false)
        {
            Vector3 lHandPosition = lHand.transform.position;
            Vector3 rHandPosition = rHand.transform.position;
            
            if (Vector3.Distance(lHandPosition, transform.position) < 1 || Vector3.Distance(rHandPosition, transform.position) < 1)
            {
                grabbedObject = true;
            }
        }
        else if (!(lHand.GetFingerIsPinching(OVRHand.HandFinger.Index) || rHand.GetFingerIsPinching(OVRHand.HandFinger.Index) && grabbedObject == true))
        {
            ReleaseObject();
        }
    }

    // Release the grabbed object
    void ReleaseObject()
    {
        if (grabbedObject == true)
        {
            grabbedObject = false;
        }
    }
}

