using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private void FixedUpdate()
    {
        m_moveHorizontal = Input.GetAxisRaw("Horizontal");
        m_moveVertical = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(m_moveHorizontal, m_moveVertical, 0));
    }
}
