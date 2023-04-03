using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = " ScriptableObjects/Ability/MagicAbility")]
public class MagicAbility : Ability
{
    public override void Use(PlayerMovement player)
    {
        player.weaponController.AxeMagic();
    }
}
