using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Score _score;
    private UIManager _uiManager;
    public bool IsPuase = false;

    private void Awake()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Assert.IsNotNull(_uiManager, "Failed to access UIManager script.");
    }

    private void Start()
    {
        _score.score = 0;
        Cursor.visible = false;   
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            IsPuase = true;
            _uiManager.ActivatePausePanel();
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }
    public void ResuemGame()
    {
        IsPuase = false;
        Time.timeScale = 1;
        _uiManager.DeactivatePausePanel();
        Cursor.visible = false;
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(GameOverScene());
    }
    private IEnumerator GameOverScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(2);
    }
}
