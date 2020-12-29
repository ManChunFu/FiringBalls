using UnityEngine;
using UnityEngine.Assertions;

public class Aiming : MonoBehaviour
{
    #region Gun Rotation Variables
    private float _rotationSensitivty = 1.5f;
    private float _maxRotateAngle = 25f;
    private float _minRotationAngle = 335f;
    #endregion Gun Rotation Variables

    #region Shooting Ball Variables
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private GameObject _firePoint;
    [SerializeField] private GameObject _launchedBallContainer;
    private float _shootForce = 1500f;
    private float _startTime, _endTime;
    private float _pressedDuration;
    //Cannon cool down varaiable
    private float _fireRate = 0.15f;
    private float _canFire = -1;
    #endregion Shooting Ball Variables

    private AudioSource shootAudio;

    private UIManager _uiManager;
    private int _ballCount;
    private GameManager _gameManager;

    private void Awake()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Assert.IsNotNull(_uiManager, "Failed to access UIManager script.");

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        Assert.IsNotNull(_gameManager, "Failed to access GameManager script.");

        shootAudio = GetComponent<AudioSource>();
        Assert.IsNotNull(shootAudio, "Failed to access Audoi Source component.");
    }
    private void Start()
    {
        _startTime = 0;
        _endTime = 0;
        _ballCount = 1000;
    }
    private void Update()
    {
        if (_gameManager.IsPuase)
            return;

        GunRotation();

        if (Input.GetMouseButtonDown(0))
            _startTime = Time.time;

        if (Input.GetMouseButtonUp(0) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate; //cool down system
            ShootBall();
        }
    }

    private void GunRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * _rotationSensitivty;

        if (newRotation.y < _maxRotateAngle || newRotation.y > _minRotationAngle)
            transform.localEulerAngles = newRotation;
    }

    private void ShootBall()
    {
        //_canFire = Time.time + _fireRate; //cool down system
        _endTime = Time.time;
        _pressedDuration = 1 + (_endTime - _startTime);
        shootAudio.Play();
        GameObject newBall = Instantiate(_ballPrefab, _firePoint.transform.position, Quaternion.identity);

        _ballCount--;
        _uiManager.LaunchedBallUpdate(_ballCount);

        if (_ballCount < 0)
        {
            _uiManager.ActiavetOutOfBallPanel();
            _gameManager.LoadGameOverScene();
        }

        newBall.transform.parent = _launchedBallContainer.transform;
        Rigidbody newBallRb = newBall.GetComponent<Rigidbody>();
        Assert.IsNotNull(newBallRb, "Failed to access Rigibody on the Ball");
        newBallRb.AddForce(_firePoint.transform.forward * _shootForce * _pressedDuration);

        _startTime = 0f;
        _endTime = 0f;

    }
}
