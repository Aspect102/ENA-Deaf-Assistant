using System;
using Oculus.Voice.Dictation;
using TMPro;
using UnityEngine;

public class DictationScript : MonoBehaviour
{
    AppDictationExperience appDictationExperience;
    public GameObject TextObject;
    public String spokenText;

    void Awake()
    {
        TextMeshProUGUI textbox = TextObject.GetComponent<TextMeshProUGUI>();
        appDictationExperience = GetComponent<AppDictationExperience>();
        appDictationExperience.DictationEvents.OnPartialTranscription.AddListener((transcription) =>
        {
            textbox.text = transcription;
        });

        appDictationExperience.DictationEvents.OnFullTranscription.AddListener((transcription) =>
        {
            textbox.text = transcription;
        });

        spokenText = textbox.text;
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

}
