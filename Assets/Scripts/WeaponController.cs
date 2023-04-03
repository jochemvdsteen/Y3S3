using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject Axe;
    public GameObject Shield;

    public GameObject Fireball;
    public Transform MagicSpawn;
    private float fireballSpeed = 25f;

    [SerializeField] private bool canAttack = true;
    [SerializeField] private float AttackCooldown = 1.0f;
    [SerializeField] private bool canBlock = true;

    public bool canUse
    {
        get => canAttack;
        private set => canAttack = value;
    }

    public bool isAttacking = false;
    public bool isBlocking = false;

    private Animator anim_Axe;
    private Animator anim_Shield;
    public AudioClip AxeAttackSound;

    private void Start()
    {
        anim_Axe = Axe.GetComponent<Animator>();
        anim_Shield = Shield.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            if(canBlock)
            {
                anim_Shield.SetBool("Blocking", true);
                isBlocking = true;
                canAttack = false;
            }
        }
        if(Input.GetMouseButtonUp(1))
        {
            anim_Shield.SetBool("Blocking", false);
            isBlocking = false;
            canAttack = true;
        }
    }

    public void AxeAttack()
    {
        isAttacking = true;
        canAttack = false;
        canBlock = false;
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(AxeAttackSound);
        anim_Axe.SetTrigger("Swing");
        StartCoroutine(ResetSwingCooldown());
    }

    public void AxeMagic()
    {
        isAttacking = true;
        canAttack = false;
        canBlock = false;
        anim_Axe.SetTrigger("Magic");
        StartCoroutine(FireballShoot());
        StartCoroutine(ResetSwingCooldown());
    }

    IEnumerator FireballShoot()
    {
        yield return new WaitForSeconds(0.5f);
        var projObj = Instantiate(Fireball, MagicSpawn.position, MagicSpawn.rotation) as GameObject;
        projObj.GetComponent<Rigidbody>().AddForce(transform.forward * 100 * fireballSpeed);
    }

    IEnumerator ResetSwingCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown - 0.8f);
        canBlock = true;
        yield return new WaitForSeconds(AttackCooldown - 0.2f);
        canAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }
}
