using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    //Text fields
    public Text m_levelText, m_hitpointText, m_pesosText, m_upgradeCostText, m_xpText;

    //Logic
    private int m_currentCharacterSelection = 0;
    public Image m_characterSelectionSprite;
    public Image m_WeaponSprite;
    public RectTransform m_xpBar;

    //Character Selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            m_currentCharacterSelection++;

            //if we went to far in the array
            if (m_currentCharacterSelection == GameManager.m_instance.m_playerSprites.Count)
            {
                m_currentCharacterSelection = 0;
            }
            OnSelectionChanged();
        }
        else
        {
            m_currentCharacterSelection--;

            //if we went to far in the array
            if (m_currentCharacterSelection < 0)
            {
                m_currentCharacterSelection = GameManager.m_instance.m_playerSprites.Count - 1;
            }
            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged()
    {
        m_characterSelectionSprite.sprite = GameManager.m_instance.m_playerSprites[m_currentCharacterSelection];
    }

    //Weapon Upgrade
    public void OnUpgradeClick()
    {

    }

    //Update the character informations

}
