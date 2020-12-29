using UnityEngine;
using UnityEngine.Assertions;

public class ShootingCannon : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _force = 500f;
    private float _speed = 5f;

    private float _visibleLevel = -10f;
    private Camera _camera;
    private GameManager _gameManager;
    private UIManager _uiManager;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rigidbody, "Failed to find Rigibody component.");

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        Assert.IsNotNull(_gameManager, "Failed to access GameManager script.");

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Assert.IsNotNull(_uiManager, "Failed to access UIManager script.");

    }
    private void Update()
    {
        CannonContorller();

        if (transform.position.y < _visibleLevel)
        {
            Destroy(gameObject, 2f);
            _uiManager.ActivateCannonFellPanel();
            _gameManager.LoadGameOverScene();
        }
    }

    private void CannonContorller()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        
        _rigidbody.AddForce(inputHorizontal * _force *  _speed * Time.deltaTime, 0f, 0f);
    }

    




}
