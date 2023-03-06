using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody _rb;

    [SerializeField] public static int hp = 3;

    // anims are called: idle_normal, idle_combat, dead, attack_short, move_forward, move_forward fast, damaged

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetBool("idle_normal", true);
    }

    public static void Damaged()
    {
        if(hp)
    }
}
