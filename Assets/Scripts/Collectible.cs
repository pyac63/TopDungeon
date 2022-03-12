using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Collidable
{
    protected bool m_collected;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        m_collected = true;
    }
}
