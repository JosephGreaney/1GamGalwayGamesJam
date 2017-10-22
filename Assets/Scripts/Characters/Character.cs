using UnityEngine;

[RequireComponent (typeof (Animator))]
public class Character : MonoBehaviour
{
    private Animator anim;
    public bool IsDead { get; set; }
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        IsDead = false;
    }

    public void Kill()
    {
        if (!IsDead)
        {
            IsDead = true;
            anim.SetBool("IsDead", true);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
