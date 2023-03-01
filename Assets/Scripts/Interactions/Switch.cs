using UnityEngine;

public class Switch : Interactable
{

    public GameObject _object;
    public bool isOn;

    private void Start()
    {
        isOn = true;
        UpdateObject();
    }

    void UpdateObject()
    {
        if(isOn == true)
        {
            Debug.Log("Cage true");
            _object.SetActive(true);
        }
        if(isOn == false)
        {
            Debug.Log("Cage false");
            _object.SetActive(false);
        }
    }

    public override string GetDescription()
    {
        if (isOn) return "Press [E] to remove the cage.";
        return "Press [E] to put the cage back (dick move).";
    }

    public override void Interact()
    {
        isOn = !isOn;
        UpdateObject();
    }
}