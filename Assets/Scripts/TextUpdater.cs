using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI loadingText;

    public void SetText(float progress)
    {
        loadingText.SetText($"{(progress * 100).ToString("N2")}%");
    }
}
