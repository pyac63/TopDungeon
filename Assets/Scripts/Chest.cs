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
            Debug.Log("Grant " + m_pesosAmount + " pesos !");
        }
    }
}
