using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject self;

    private void Start()
    {
        StartCoroutine(KillSelf());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(self);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Destroy(self);
    }

    IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(2f);
        Destroy(self);
    }
}
