using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float velocity;
    float moveHorizontal;
    float moveVertical;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveHorizontal = 0.0f;
        moveVertical = 0.0f;
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            Vector3 vectorToTarget = new Vector3(movement.x, movement.y, 0);
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

            rb2d.AddForce(movement * speed);
        }
    }
}
