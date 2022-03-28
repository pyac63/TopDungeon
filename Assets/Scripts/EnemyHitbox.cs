using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    //DAmage
    public int m_damageEnemyHitbox = 1;
    public float m_pushForceEnemyHitbox = 4.5f;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.CompareTag("Fighter") && collider.name == "Player")
        {
            //Create new damage object before sending it to the fighter we hit
            Damage dmg = new Damage 
            {
                m_damageAmount = m_damageEnemyHitbox,
                m_origin = transform.position,
                m_damagePushForce = m_pushForceEnemyHitbox
            };

            collider.SendMessage("ReceiveDamage", dmg);
        }
    }
}
