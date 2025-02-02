using UnityEngine;

public class GroundedChecker : MonoBehaviour
{
    private readonly string Ground = nameof(Ground);

    public bool IsGrounded { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Ground)
            IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Ground)
            IsGrounded = false;
    }
}
