using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ball", menuName = "Arkanoid/PowerUp/PaddelPowerUp", order = 2)]
public class PaddelPowerUp : PowerUp
{
    public GameObject Paddel;
    public Vector2 scale = new Vector2(1,1);
    public int amount;

    private void OnEnable()
    {
        Player.OnPowerUp += ScalePaddel;
    }

    private void OnDisable()
    {
        Player.OnPowerUp -= ScalePaddel;
    }

    private void ScalePaddel(object sender, Player.OnPowerUpEventArgs e)
    {
        string powerUp = e.EnabledPowerUp;
        if(Name == powerUp)
        {
            GameObject paddel = e.paddel;
            SpriteRenderer spriteRenderer = paddel.GetComponent<SpriteRenderer>();
            CapsuleCollider2D col = paddel.GetComponent<CapsuleCollider2D>();
            col.size = scale;
            spriteRenderer.size = scale;
            Debug.Log("Scaling paddel: " + Name);
        }
    }
}
