using UnityEngine;

[RequireComponent (typeof (Animator))]
public class Speaker : MonoBehaviour, Interaction
{
    private Animator anim;
    private AudioSource audio;
    private bool highlighted;
    private bool activated;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        activated = true;
    }

    public void ToggleSpeaker()
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
        audio.volume = 1;
    }

    public void TurnOff()
    {
        activated = false;
        anim.SetBool("Activated", false);
        audio.volume = 0;
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
            ToggleSpeaker();
        }
    }
}
