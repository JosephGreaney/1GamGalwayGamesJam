using UnityEngine;
[RequireComponent (typeof(Animator))]
public class TrapTrigger : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>() != null)
        {
            anim.SetTrigger("Activate");
        }
    }
}
