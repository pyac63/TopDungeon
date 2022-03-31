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
        if (GameManager.m_instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    //Update the character informations
    public void UpdateMenu()
    {
        //Weapon
        m_WeaponSprite.sprite = GameManager.m_instance.m_weaponSprites[GameManager.m_instance.m_weapon.m_weaponLevel];
        m_upgradeCostText.text = GameManager.m_instance.m_weaponPrices[GameManager.m_instance.m_weapon.m_weaponLevel].ToString();

        //Meta
        m_levelText.text = "NOT IMPLEMENTED YET";
        m_hitpointText.text = GameManager.m_instance.player.m_hitPoint.ToString();
        m_pesosText.text = GameManager.m_instance.m_pesos.ToString();

        //Xp Bar
        m_xpText.text = "NOT IMPLEMENTED YET";
        m_xpBar.localScale = new Vector3(0.5f, 0f, 0f);
    }
}
