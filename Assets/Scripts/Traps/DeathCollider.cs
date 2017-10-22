using UnityEngine;

public class DeathCollider : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if a character has been hit.
        if (collision.collider.GetComponent<Character>())
        {
            Character c = collision.collider.GetComponent<Character>();
            c.Kill();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if a character has been hit.
        if (collision.GetComponent<Character>())
        {
            Character c = collision.GetComponent<Character>();
            c.Kill();
        }
    }
}
