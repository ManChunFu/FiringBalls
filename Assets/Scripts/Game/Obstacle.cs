using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _obstacleID; // 0 = back and forward, 1 = up and down, 2 = left and right
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _endPosition;
    private float _speed = 5f;
    private bool _isMovingForward;
    private bool _isMovingDown;
    private bool _isMovingLeft;

    private void Start()
    {
        _isMovingForward = false;
        _isMovingDown = false;
        _isMovingLeft = false;
    }
    private void FixedUpdate()
    {
        if (_obstacleID == 0)
            MoveBackNForward();

        if (_obstacleID == 1)
            MoveUpNDown();

        if (_obstacleID == 2)
            MoveLeftNRight();
    }

    #region Obstacle Movement

    private void MoveBackNForward()
    {
        if (transform.position.z <= _startPosition.z)
            _isMovingForward = true;
        else if (transform.position.z > _endPosition.z)
            _isMovingForward = false;

        if (_isMovingForward)
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        else
            transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }

    private void MoveUpNDown()
    {
        if (transform.position.y >= _startPosition.y)
            _isMovingDown = true;
        else if (transform.position.y < _endPosition.y)
            _isMovingDown = false;

        if (_isMovingDown)
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        else
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    private void  MoveLeftNRight()
    {
        if (transform.position.x >= _startPosition.x)
            _isMovingLeft = true;
        else if (transform.position.x < _endPosition.x)
            _isMovingLeft = false;

        if (_isMovingLeft)
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        else
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
    #endregion Obstacle Movement

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
            Destroy(collision.gameObject);

    }

   
}
