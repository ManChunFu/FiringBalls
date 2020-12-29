using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _ballCountText;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _cannonFellPanel;
    [SerializeField] private GameObject _outOfBallsPanel;

    private void Awake()
    {
        _pausePanel.SetActive(false);
        _cannonFellPanel.SetActive(false);
        _outOfBallsPanel.SetActive(false);
    }
    private void Start()
    {
        _scoreText.text = "00";
        _ballCountText.text = "1000";
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = score.ToString().PadLeft(2, '0');
    }

    public void LaunchedBallUpdate(int ballCount)
    {
        _ballCountText.text = ballCount.ToString().PadLeft(2, '0');
    }

    public void ActivatePausePanel()
    {
        _pausePanel.SetActive(true);
    }

    public void DeactivatePausePanel()
    {
        _pausePanel.SetActive(false);
    }

    public void ActivateCannonFellPanel()
    {
        _cannonFellPanel.SetActive(true);
    }

    
    public void ActiavetOutOfBallPanel()
    {
        _outOfBallsPanel.SetActive(true);
    }

    
}
