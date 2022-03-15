using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //https://www.youtube.com/watch?v=b8YUfee_pzc
    //03:19:36



    public static GameManager m_instance;

    private void Awake()
    {
        if (GameManager.m_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        m_instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Ressources
    public List<Sprite> m_playerSprites;
    public List<Sprite> m_weaponSprites;
    public List<int>    m_weaponPrices;
    public List<int>    m_xpTable;

    //References
    public Player player;
    // public Weapon weapon;
    public FloatingTextManager m_floatingTextManager;

    //Logic
    public int m_pesos;
    public int m_experience;


    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        m_floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }


    public void SaveState()
    {
        //Send all saved data to a single string s, data separated with | (alt + 124)
        string s = "";
        s += "0" + "|";
        s += m_pesos.ToString() + "|";
        s += m_experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {

        if(!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        //Read the single string s and use the GetString.Split() method with chatracter | (alt + 124) to separate in the data sting array
        //eg.
        //string s = "A|B|C" in SaveState will be
        //string[] data = ["A", "B", "C"] in LoadState
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //change skin pref
        m_pesos = int.Parse(data[1]);
        m_experience = int.Parse(data[2]);
        //change weapon level


        Debug.Log("Load State");
    }

}
