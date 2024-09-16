using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModalBehaviour : MonoBehaviour
{
    private bool _isActive = false;
    public string headerText = "Header Text";
    public Dictionary<string, GameObject> menuItem;
    public bool showCancelButton = true;
    public bool showApplyButton = true;

    public UnityEngine.Events.UnityAction cancelCallback;
    public UnityEngine.Events.UnityAction applyCallback;

    // Property for isActive with logic triggered on value change
    public bool IsActive
    {
        get { return _isActive; }
        set
        {
            if (_isActive != value) // Detect if isActive was toggled
            {
                _isActive = value;
                OnIsActiveToggled(_isActive); // Call method when toggled
            }
        }
    }

    // Called when isActive changes
    private void OnIsActiveToggled(bool active)
    {
        Debug.Log("OnIsActiveToggled called with value: " + active); // For debugging purposes
        if (active)
        {
            // Enable modal and setup UI when active is true
            gameObject.SetActive(true);
            GameObject.Find("Header").GetComponentInChildren<TextMeshProUGUI>().SetText(headerText);

            // Show or hide apply/cancel buttons
            GameObject.Find("Apply").SetActive(showApplyButton);
            GameObject.Find("Cancel").SetActive(showCancelButton);

            // Add event listeners to buttons
            Button applyButton = GameObject.Find("Apply").GetComponent<Button>();
            Button cancelButton = GameObject.Find("Cancel").GetComponent<Button>();

            applyButton.onClick.AddListener(Apply);
            applyButton.onClick.AddListener(applyCallback);
            cancelButton.onClick.AddListener(Cancel);
            cancelButton.onClick.AddListener(cancelCallback);
        }
        else
        {
            // Hide modal when active is false
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        gameObject.SetActive(_isActive);
        IsActive = _isActive;
    }

    public void Cancel()
    {
        IsActive = false;
    }

    public void Apply()
    {
        IsActive = false;
    }
}
