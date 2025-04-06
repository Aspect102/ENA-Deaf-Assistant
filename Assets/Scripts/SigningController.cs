using Meta.WitAi.TTS.Utilities;
using TMPro;
using UnityEngine;

public class SigningController : MonoBehaviour
{
    public GameObject Poses;
    public TextMeshProUGUI Textbox;
    public TextMeshProUGUI TextboxStatus;
    public TTSSpeaker tTSSpeaker;

    private void Awake()
    {

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSigning()
    {
        TextboxStatus.text = "Now: Signing";
        Textbox.text = "";
        Poses.SetActive(true);
    }

    public void AppendSign(string sign)
    {
        Textbox.text += sign;
    }

    public void StopSigning()
    {
        Poses.SetActive(false);
    }

    public void SpeakEvent()
    {
        tTSSpeaker.Speak(Textbox.text);                         
    }
}
