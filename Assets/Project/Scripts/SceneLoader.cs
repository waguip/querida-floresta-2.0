using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadAuthMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void loadRegisterMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void loadScene1()
    {
        SceneManager.LoadScene(3);
    }
    public void loadScene2()
    {
        SceneManager.LoadScene(4);
    }

    public void loadScene3()
    {
        SceneManager.LoadScene(5);
    }

    private void loadPlayersForest()
    {
        SceneManager.LoadScene(6);
    }

    public void loadSceneSelection()
    {
        SceneManager.LoadScene(7);
    }

    public void loadCredits()
    {
        SceneManager.LoadScene(8);
    }

    public void loadStatisticsScreen()
    {
        SceneManager.LoadScene(9);
    }

    public void loadScene4()
    {
        SceneManager.LoadScene(10);
    }

    public void loadScene5()
    {
        SceneManager.LoadScene(11);
    }

    public void loadScene6()
    {
        SceneManager.LoadScene(12);
    }

    public void loadScene7()
    {
        SceneManager.LoadScene(13);
    }

    public void loadScene8()
    {
        SceneManager.LoadScene(14);
    }
    public void loadScene9()
    {
        SceneManager.LoadScene(15);
    }
    public void loadQuiz2()
    {
        SceneManager.LoadScene(16);
    }

    public void loadConnectFigures() {
        SceneManager.LoadScene(17);
    }

    public void loadCacoIntro()
    {
        SceneManager.LoadScene(18);
    }    
    
    public void quitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
