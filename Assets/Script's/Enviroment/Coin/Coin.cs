using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource _coinSound;
    private WaitForSeconds _sleep;
    private float _sleepTime = 1;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sleep = new WaitForSeconds(_sleepTime);
        _coinSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _coinSound.Play();

        StartCoroutine(Dispose());
    }

    private IEnumerator Dispose()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;

        Debug.Log("Work");

        yield return _sleep;

        Destroy(this);
    } 
}
