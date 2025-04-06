using UnityEngine;

public class CatText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform mainCam;
    Transform unit;
    Transform worldSpaceCanvas;

    RectTransform rect;

    public Transform catTransform;

    public Vector3 offset;
    void Start()
    {
        mainCam = Camera.main.transform;
        unit = transform.parent;
        worldSpaceCanvas = GameObject.FindObjectOfType<Canvas>().transform;
        rect = gameObject.GetComponent<RectTransform>();

        transform.SetParent(worldSpaceCanvas);
        
        // rect.position = catTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);
        transform.position = unit.position + offset;

        transform.position = catTransform.position;     
        // rect.position = catTransform.position;
    }
}
