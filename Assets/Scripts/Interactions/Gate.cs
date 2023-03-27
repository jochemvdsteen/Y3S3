using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gate : Interactable
{
    [SerializeField] private Animator myGate = null;

    [SerializeField] private bool isOpen = false;
    [SerializeField] private bool canInteract = true;

    public AudioClip GateOpen;
    public TMP_Text Message;

    private void Start()
    {
        myGate = GetComponentInParent<Animator>();
        Message.text = "Please help";
    }

    void UpdateObject()
    {
        AudioSource ac = GetComponentInParent<AudioSource>();

        if(isOpen == true)
        {
            Debug.Log("Open door");
            ac.PlayOneShot(GateOpen);
            StartCoroutine(Open());
            myGate.Play("GateOpen", 0, 0.0f);
        }
    }

    public override string GetDescription()
    {
        if (canInteract)
        {
            if (PlayerMovement.hasKey)
            {
                if (isOpen) return "Press [E] to close.";
                return "Press [E] to open.";
            }
            if (!PlayerMovement.hasKey)
            {
                if (isOpen) return "Hello";
                return "Need key.";
            }
        }
        return "";
    }

    public override void Interact()
    {
        if (canInteract && PlayerMovement.hasKey)
        {
            isOpen = !isOpen;
            UpdateObject();
        } 
    }

    IEnumerator Open()
    {
        canInteract = false;
        Message.text = "Thank you my hero";
        yield return new WaitForSeconds(0.5f);
    }
}