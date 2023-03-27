using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool isOpen = false;
    [SerializeField] private bool canInteract = true;

    public AudioClip DoorCreak;
    public AudioClip DoorClose;

    private void Start()
    {
        myDoor = GetComponentInParent<Animator>();
    }

    void UpdateObject()
    {
        AudioSource ac = GetComponentInParent<AudioSource>();

        if(isOpen == true)
        {
            Debug.Log("Open door");
            StartCoroutine(Cooldown());
            ac.PlayOneShot(DoorCreak);
            myDoor.Play("DoorOpen", 0, 0.0f);
        }
        if(isOpen == false)
        {
            Debug.Log("Close door");
            StartCoroutine(Cooldown());
            StartCoroutine(CloseSound());
            ac.PlayOneShot(DoorCreak);
            myDoor.Play("DoorClose", 0, 0.0f);
        }
    }

    public override string GetDescription()
    {
        if (canInteract)
        {
            if (isOpen) return "Press [E] to close.";
            return "Press [E] to open.";
        }
        return"";
    }

    public override void Interact()
    {
        if (canInteract)
        {
            isOpen = !isOpen;
            UpdateObject();
        } 
    }

    IEnumerator Cooldown()
    {
        canInteract = false;
        yield return new WaitForSeconds(1f);
        canInteract = true;
    }

    IEnumerator CloseSound()
    {
        yield return new WaitForSeconds(0.7f);
        AudioSource ac = GetComponentInParent<AudioSource>();
        ac.PlayOneShot(DoorClose);
    }
}