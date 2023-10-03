using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonControl : MonoBehaviour
{
    public Button firstButton;
    public Button secondButton;

    private void Start()
    {
        // Attach click event listeners to the buttons.
        firstButton.onClick.AddListener(DisableFirstButton);
        secondButton.onClick.AddListener(EnableFirstButton);
    }

    public void DisableFirstButton()
    {
        // Disable the first button.
        firstButton.interactable = false;
    }

    public void EnableFirstButton()
    {
        // Enable the first button.
        firstButton.interactable = true;
    }
}