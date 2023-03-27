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

    Enemy enemy = new Enemy(3);

    public AudioClip Hurt;

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
        AudioSource ac = GetComponent<AudioSource>();

        if (other.tag == "Weapon" && wp.isAttacking)
        {
            enemy.health--;
            ac.PlayOneShot(Hurt);

            if (enemy.health > 0)
            {
                anim.SetTrigger("damaged");
                anim.SetBool("idle_normal", false);
                anim.SetBool("idle_combat", true);
            }

            if (enemy.health <= 0)
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
