using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coinBag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _coinBag++;
            coin.Dispose();
        }
    }
}