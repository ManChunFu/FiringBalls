using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private Target _target;

    public Score score;

    //1 = game, 2 = game over
    private void Start()
    {
        Cursor.visible = true;
        _scoreText.text = "00";
    }

    private void Update()
    {
        _scoreText.text = score.score.ToString().PadLeft(2, '0');
    }
    public void ResumeScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

   
}
