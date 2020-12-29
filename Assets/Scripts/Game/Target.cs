using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class Target : MonoBehaviour
{
    private float _xPos, _yPos;
    private int _hitCount;
    public Score score;

    private Renderer _renderer;
    private Color _happyColor;
    private Color _sadColor;
    private SpriteRenderer _mouth;
    [SerializeField] private Sprite _happyMouth;
    [SerializeField] private Sprite _sadMouth;

    private Animator _eyeAnim;
    private UIManager _uiManager;
    private AudioSource _audio;
    

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Assert.IsNotNull(_renderer, "Failed to find the Renderer on the target.");
        _happyColor = _renderer.material.color;
        _sadColor = Color.red;

        _mouth = transform.GetChild(2).GetComponent<SpriteRenderer>();
        Assert.IsNotNull(_mouth, "Failed to find Sprite Renderer on the mouth.");

        _eyeAnim = GetComponent<Animator>();
        Assert.IsNotNull(_eyeAnim, "Failed to find Animator on the target.");

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Assert.IsNotNull(_uiManager, "Failed to acces to UIManager script");

        _audio = GetComponent<AudioSource>();
        Assert.IsNotNull(_audio, "Failed to access Audio Source Component.");
    }

    private void Start()
    {
        _hitCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        _audio.Play();
        _hitCount++;
        score.score = _hitCount;
        _uiManager.UpdateScore(_hitCount);

        _eyeAnim.SetTrigger("GotHit");
        _renderer.material.color = _sadColor;
        _mouth.sprite = _sadMouth;
        StartCoroutine(ChangePosition());
    }

    private IEnumerator ChangePosition()
    {
        _xPos = Random.Range(-27f, 27f);
        _yPos = Random.Range(10f, 36f);
        yield return new WaitForSeconds(2f);
        transform.position = new Vector3(_xPos, _yPos, transform.position.z);
        _renderer.material.color = _happyColor;
        _mouth.sprite = _happyMouth;
    }
}
