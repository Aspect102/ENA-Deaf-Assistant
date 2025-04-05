using Oculus.Voice.Dictation;
using UnityEngine;

public class DictationScript : MonoBehaviour
{
    AppDictationExperience appDictationExperience;

    void Awake()
    {
        appDictationExperience = GetComponent<AppDictationExperience>();
        appDictationExperience.DictationEvents.OnPartialTranscription.AddListener((transcription) =>
        {
            Debug.Log(transcription);
        });

        appDictationExperience.DictationEvents.OnFullTranscription.AddListener((transcription) =>
        {
            Debug.Log(transcription);
        });

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        appDictationExperience.Activate();
    }

    public void HandlePartialTranscription(string transcript)
    {
        Debug.Log(transcript);
    }

}
