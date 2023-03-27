using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerma : Interactable
{
    void UpdateObject()
    {
        SceneManagement.WinScreen();
    }

    public override string GetDescription()
    {
        return "Press [E] to romance.";
    }

    public override void Interact()
    {
        UpdateObject();
    }
}
