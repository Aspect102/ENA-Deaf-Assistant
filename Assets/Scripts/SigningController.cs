using UnityEngine;

public class SigningController : MonoBehaviour
{
    public GameObject Poses;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSigning()
    {
        Poses.SetActive(true);
    }

    public void AppendSign(string sign)
    {
        
    }

    public void StopSigning()
    {
        Poses.SetActive(false);
    }
}
