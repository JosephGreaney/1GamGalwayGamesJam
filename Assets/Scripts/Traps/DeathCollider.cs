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
}
