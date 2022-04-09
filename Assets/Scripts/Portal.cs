using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Переход между уровнями 
/// </summary>
public class Portal : Collidable
{

    public string[] sceneNames;

    protected override void OnCollide(Collider2D col)
    {
        //GameManager.instance.ShowText();
        if (col.name == "Player") {
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(sceneName);
        }
    }
}
