using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class CatConroller : MonoBehaviour
{
    public Transform cameraTransform;
    private HandGrabInteractor handGrab;

    public float distance;
    public float offsetRight; 
    public float offsetUp; 
    public float hoverHeight;  // Hover height (how much it moves up and down)
    public float hoverSpeed;     // Speed of the hover effect
    
    void Start()
    {
        
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

        
        // if (InteractorState.Select == handGrab.State) {
            
        // }
    }
}

