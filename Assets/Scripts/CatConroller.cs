using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
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

    public GameObject happy;
    public GameObject closedEyes;
    
    
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

        Debug.Log(dictationScript.spokenText);
    }


    void TryGrab(OVRHand lHand, OVRHand rHand)
    {
        Debug.Log("ajsdnakdj");
        if ((lHand.GetFingerIsPinching(OVRHand.HandFinger.Index) || rHand.GetFingerIsPinching(OVRHand.HandFinger.Index)) && grabbedObject == false)
        {
            RaycastHit hit1;
            Vector3 lHandPosition = lHand.transform.position;

            RaycastHit hit2 = new RaycastHit();
            Vector3 rHandPosition = rHand.transform.position;

            if (Physics.Raycast(lHandPosition, lHand.transform.forward, out hit1, grabDistance) || Physics.Raycast(rHandPosition, rHand.transform.forward, out hit2, grabDistance))
            {
                if (hit1.collider.CompareTag("Grabbable") || hit2.collider.CompareTag("Grabbable"))
                {
                    grabbedObject = true;
                }
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

