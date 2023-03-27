using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerma : Interactable
{

    public GameObject fadeEffect;

    private void Start()
    {
        fadeEffect.SetActive(false);
    }

    void UpdateObject()
    {
        StartCoroutine(Fade());
    }

    public override string GetDescription()
    {
        return "Press [E] to romance.";
    }

    public override void Interact()
    {
        UpdateObject();
    }

    IEnumerator Fade()
    {
        fadeEffect.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManagement.WinScreen();
    }
}
