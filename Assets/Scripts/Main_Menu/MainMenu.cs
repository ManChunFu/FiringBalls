using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // 0 = main menu, 1 = game
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitScene()
    {
        //Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
