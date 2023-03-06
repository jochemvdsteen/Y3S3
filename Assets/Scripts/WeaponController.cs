using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject Axe;

    [SerializeField] private bool canAttack = true;
    [SerializeField] private float AttackCooldown = 1.0f;

    public bool isAttacking = false;

    private Animator anim;
    public AudioClip AxeAttackSound;

    private void Start()
    {
        anim = Axe.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(canAttack)
            {
                AxeAttack();
            }
        }
    }

    public void AxeAttack()
    {
        isAttacking = true;
        canAttack = false;
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(AxeAttackSound);
        anim.SetTrigger("Swing");
        StartCoroutine(ResetSwingCooldown());   
    }

    IEnumerator ResetSwingCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        canAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }
}
