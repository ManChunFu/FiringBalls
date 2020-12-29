using UnityEngine;

public class Ball : MonoBehaviour
{
    private float _visibleLevel = -3f;
    void Update()
    {
        if (transform.position.y < _visibleLevel)
            Destroy(gameObject);
    }
}
