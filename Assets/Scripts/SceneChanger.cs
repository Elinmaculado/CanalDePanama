using UnityEngine;
using UnityEngine.SceneManagement;

// Remember to add the desired scenes to build settings
public class SceneChanger : MonoBehaviour
{
    public string scene;
    public void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}