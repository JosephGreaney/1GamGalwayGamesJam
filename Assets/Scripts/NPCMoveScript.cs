using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoveScript : MonoBehaviour {

    public float distanceToStop;
    public float speed;
    public float maxSpeed;
    public Transform targetTransform;
    public List<Transform> nodeList;

    private Rigidbody2D rb;
    private bool moving;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
        // If there's any nodes in the path, move them towards the oldest node
        if (nodeList.Count > 0) {
            moveTowards(nodeList[0].position);
        }
	}

    public void moveTowards(Vector3 targetPosition) {
        if (Vector3.Distance(transform.position, targetPosition) > distanceToStop) {
            moving = true;

            // Face NPC towards the target position
            var dir = targetPosition - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Apply force towards the target position
            if (rb.velocity.magnitude < maxSpeed) {
                rb.AddRelativeForce(Vector2.right * speed);
            }
        } else {
            nodeList.RemoveAt(0);
            moving = false;
        }
    }

    public void addNodeToTheEndOfThePath(Transform node) {
        nodeList.Add(node);
    }

    public void addNodeToTheStartOfThePath(Transform node) {
        nodeList.Insert(0, node);
    }
}
