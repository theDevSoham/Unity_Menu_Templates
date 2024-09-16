using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    private AudioSource menuAudio;
    private Toggle audioToggle;
    private TextMeshProUGUI toggleText;

    private void Start()
    {
        audioToggle = GetComponentInChildren<Toggle>();
        toggleText = audioToggle.gameObject.GetComponentInChildren<TextMeshProUGUI>();

        menuAudio = GameObject.Find("Menu Music").GetComponent<AudioSource>();

        if (audioToggle != null)
        {
            audioToggle.onValueChanged.AddListener(MenuChangeAction);
        }
        else
        {
            Debug.Log($"Audio toggle with {audioToggle.name} not found");
        }
    }

    private void MenuChangeAction(bool state)
    {
        if (state)
        {
            menuAudio.UnPause();
            toggleText.SetText("On");
        }
        else
        {
            menuAudio.Pause();
            toggleText.SetText("Off");
        }
    }
}
