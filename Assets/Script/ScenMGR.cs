using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenMGR : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
