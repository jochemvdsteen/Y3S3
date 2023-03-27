using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    void UpdateObject()
    {
        StartCoroutine(Grab());
    }

    public override string GetDescription()
    {
        return "Press [E] to grab.";
    }

    public override void Interact()
    {
        UpdateObject();
    }

    IEnumerator Grab()
    {
        PlayerMovement.hasKey = true;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
    }
}
