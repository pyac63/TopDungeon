using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage structure
    public int m_damagePoint = 1;
    public float m_pushForce = 5.0f;

    // Upgrade structure
    public int m_weaponLevel = 0;
    private SpriteRenderer m_weaponSprite;

    // Swing structure
    private Animator m_anim;
    private float m_cooldown = 0.5f;
    private float m_lastSwing;


    protected override void Start()
    {
        base.Start();
        m_weaponSprite = GetComponent<SpriteRenderer>();
        m_anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - m_lastSwing > m_cooldown)
            {
                m_lastSwing = Time.time;
                Swing();
            }
        }

    }

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.CompareTag("Fighter"))
        {
            if (collider.name =="Player")
            {
                return;
            }

            //Create a new damage object, then send it to the fighter hit
            Damage dmg = new Damage { m_damageAmount = m_damagePoint, m_origin = transform.position, m_damagePushForce = m_pushForce };

            collider.SendMessage("ReceiveDamage", dmg);

            Debug.Log(collider.name);
        }        
    }

    private void Swing()
    {
        m_anim.SetTrigger("Swing");
    }





}
