using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
    private AudioSource _pickUpSound;
    private WaitForSeconds _delay;

    private void Awake()
    {
        _pickUpSound = GetComponent<AudioSource>();
    }

    public void Dispose()
    {
        _delay = new WaitForSeconds(_pickUpSound.clip.length);

        StartCoroutine(PlaySoundWithDelay());
    }

    private IEnumerator PlaySoundWithDelay()
    {
        _pickUpSound.Play();

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return _delay;

        gameObject.SetActive(false);
    }
}
