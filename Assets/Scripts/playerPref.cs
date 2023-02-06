using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPref
{
    public float speed;
    public float jumpforce;
    public int jumpCount;

    public playerPref(float spd,float jumpF, int jumpC)
    {
        this.speed = spd;
        this.jumpforce = jumpF;
        this.jumpCount = jumpC;
    }
}