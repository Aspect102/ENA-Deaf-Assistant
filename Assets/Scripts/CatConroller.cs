using UnityEngine;

public class CatConroller : MonoBehaviour
{
    public Transform cameraTransform;
    public float distanceFromCamera = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 resultingPosition = cameraTransform.position + new Vector3(0.5f, 0f, 0.5f);// cameraTransform.forward * distanceFromCamera;
        transform.position = resultingPosition;        
    }
}

