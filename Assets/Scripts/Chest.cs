using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectible
{

    public Sprite m_emptyChest;
    public int m_pesosAmount = 5;

    protected override void OnCollect()
    {
        if (!m_collected)
        {
            m_collected = true;
            GetComponent<SpriteRenderer>().sprite = m_emptyChest;
            GameManager.m_instance.m_pesos += m_pesosAmount;
            GameManager.m_instance.ShowText("+" + m_pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }
    }
}
