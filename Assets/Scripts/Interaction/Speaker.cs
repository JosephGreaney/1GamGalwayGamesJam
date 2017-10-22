using UnityEngine;

[RequireComponent (typeof (Animator))]
public class Speaker : MonoBehaviour, Interaction
{
    private Animator anim;
    private AudioSource aud;
    private bool highlighted;
    private bool activated;
    [SerializeField] private NPCSpawner npcSpawner;

    private void Start()
    {
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        activated = true;
    }

    public void Toggle()
    {
        if (activated)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    public void TurnOn()
    {
        activated = true;
        anim.SetBool("Activated", true);
        aud.volume = 1;
    }

    public void TurnOff()
    {
        activated = false;
        anim.SetBool("Activated", false);
        npcSpawner.GetAnimeGuy().GetComponent<NPCMoveScript>().GoTo("wardroab");
        aud.volume = 0;
    }

    public bool GetHighlighted()
    {
        return highlighted;
    }

    public void SetHighlighted(bool highlighted)
    {
        this.highlighted = highlighted;
    }

    public void DoActionNow(GameObject caller)
    {
        if (highlighted)
        {
            Toggle();
        }
    }
}
