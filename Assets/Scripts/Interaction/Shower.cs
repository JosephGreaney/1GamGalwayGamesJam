using UnityEngine;

public class Shower : MonoBehaviour, Interaction
{
    [SerializeField] private GameObject particles;
    private AudioSource audio;
    private bool highlighted;
    private bool activated;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
        activated = false;
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
        particles.SetActive(true);
        audio.volume = 0.4f;
    }

    public void TurnOff()
    {
        activated = false;
        particles.SetActive(false);
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
            Toggle();
        }
    }
}
