using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
    private AudioSource _pickUpSound;

    private void Awake()
    {
        _pickUpSound = GetComponent<AudioSource>();
    }

    public void Dispose()
    {
        StartCoroutine(PlaySoundWithDelay());
    }

    private IEnumerator PlaySoundWithDelay()
    {
        _pickUpSound.Play();

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(_pickUpSound.clip.length);

        Destroy(gameObject);
    }
}
