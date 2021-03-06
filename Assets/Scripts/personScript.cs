using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Utils;

public class PersonScript : MonoBehaviour {


    private Character character;
    public float distanceToStop;
    public float speed;
    public float rotationSpeed;
    public float maxSpeed;
    public Transform targetTransform;
    public List<Transform> nodeList;
    private GameObject[] navNodes;
    private Dictionary<string, Transform> nodes = new Dictionary<string, Transform>();
    private string lastNode;

    private Rigidbody2D rb;
    private bool moving;

    private void Awake()
    {
        character = new Character();
        navNodes = GameObject.FindGameObjectsWithTag("NavNode");
        foreach (GameObject aNavNode in navNodes)
        {
            nodes.Add(aNavNode.name, aNavNode.transform);
            if (aNavNode.transform.position == this.transform.position)
                lastNode = aNavNode.name;
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moving = false;
    }

    void Update()
    {
        // If there's any nodes in the path, move them towards the oldest node
        if (nodeList.Count > 0)
        {
            MoveTowards(nodeList[0].position);
        }
    }

    public void MoveTowards(Vector3 targetPosition)
    {
        if (Vector3.Distance(transform.position, targetPosition) > distanceToStop)
        {
            moving = true;

            // Face NPC towards the target position
            var dir = targetPosition - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Apply force towards the target position
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddRelativeForce(Vector2.right * speed);
            }
        }
        else
        {
            nodeList.RemoveAt(0);
            moving = false;
        }
    }

    private void RotateCharacter(Vector3 rotateDirection)
    {
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg - 90;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void AddNodeToTheEndOfThePath(Transform node)
    {
        nodeList.Add(node);
    }

    public void AddNodeToTheStartOfThePath(Transform node)
    {
        nodeList.Insert(0, node);
    }

    /*public void GoTo(string pathName)
    {
        character.
    }*/
}
