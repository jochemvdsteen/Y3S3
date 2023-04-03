using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = " ScriptableObjects/Ability/SwingAbility")]
public class SwingAbility : Ability
{
    public override void Use(PlayerMovement player)
    {
        player.weaponController.AxeAttack();
    }
}
