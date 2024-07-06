using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LoaderScens : MonoBehaviour
{
    

    public void LoadScene(int countScene)
    {
        SceneManager.LoadScene(countScene);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        var NumberScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(NumberScene);
    }

    public void NextScene()
    {
        var NumberScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(NumberScene + 1);
    }

    public void UnlockLevel()
    {
        LockSystem.UnlockLevel[SceneManager.GetActiveScene().buildIndex - 2] = true;
        LockSystem.Save();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        YandexGame.ReviewShow(YandexGame.EnvironmentData.reviewCanShow);
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
