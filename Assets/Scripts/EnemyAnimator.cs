using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody _rb;

    [SerializeField] public static int hp = 3;

    public GameObject self;
    public WeaponController wp;

    // anims are called: idle_normal, idle_combat, dead, attack_short, move_forward, move_forward fast, damaged

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetBool("idle_normal", true);
        self = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon" && wp.isAttacking)
        {
            hp--;

            if (hp > 0)
            {
                anim.SetTrigger("damaged");
                anim.SetBool("idle_normal", false);
                anim.SetBool("idle_combat", true);
            }

            if (hp <= 0)
            {
                StartCoroutine(Death());
            }

            //Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }

    IEnumerator Death()
    {
        anim.SetBool("dead", true);
        yield return new WaitForSeconds(5f);
        Destroy(self);
    }
}
