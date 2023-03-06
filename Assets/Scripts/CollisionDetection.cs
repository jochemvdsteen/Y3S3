using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wp;
    //public GameObject HitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && wp.isAttacking)
        {
            Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("damaged");
            other.GetComponent<Animator>().SetBool("idle_normal", false);
            other.GetComponent<Animator>().SetBool("idle_combat", false);

            other.GetComponent<EnemyAnimator>()
            //Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }

}
