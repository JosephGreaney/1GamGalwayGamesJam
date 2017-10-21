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
            RotateCharacter(new Vector3(moveHorizontal, moveVertical, 0));

            rb2d.AddForce(movement * speed);
        }
    }

    private void RotateCharacter(Vector3 rotateDirection)
    {
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg - 90;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
    }
}
