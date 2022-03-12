using UnityEngine;

public class Portal : Collidable
{
    public string[] m_sceneNames;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            string sceneName = m_sceneNames[Random.Range(0, m_sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
