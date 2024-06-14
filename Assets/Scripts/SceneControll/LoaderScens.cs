using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScens : MonoBehaviour
{
    public void LoadScene(int countScene)
    {
        SceneManager.LoadScene(countScene);
    }

    public void Restart()
    {
        var NumberScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(NumberScene);
    }

    public void NextScene()
    {
        var NumberScene = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(NumberScene++);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
