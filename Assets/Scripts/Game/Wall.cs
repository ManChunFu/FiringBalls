using UnityEngine;
using UnityEngine.Assertions;

public class Wall : MonoBehaviour
{
    private AudioSource hitWallAudio;

    private void Awake()
    {
        hitWallAudio = GetComponent<AudioSource>();
        Assert.IsNotNull(hitWallAudio, "Failed to access Audoi Source component.");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
            hitWallAudio.Play();

    }
}
