using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = " ScriptableObjects/Ability/ShootAbility")]
public class ShootAbility : Ability
{
    [SerializeField] private GameObject _fireball;

    public override void Use(PlayerMovement player)
    {
        Instantiate(_fireball, player.transform.position, player.transform.rotation);
    }
}
