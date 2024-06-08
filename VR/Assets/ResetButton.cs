using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetButton : MonoBehaviour
{
    private XRSimpleInteractable interactable;

    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        if (interactable == null)
        {
            Debug.LogError("XRSimpleInteractable component is missing.");
            return;
        }

        interactable.selectEntered.AddListener(OnButtonPressed);
    }

    public void OnButtonPressed(SelectEnterEventArgs args)
    {
        Console.WriteLine("YEEEEEEEEEEEE");
        GameManager.Instance.ResetGame();
    }

    private void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnButtonPressed);
        }
    }
}
