using UnityEngine;

public class PowerBox : MonoBehaviour, Interaction
{
    [SerializeField] private LivingRoomController lights;
    [SerializeField] private NPCSpawner npcSpawner;
    private bool highlighted;
    private bool activated;

    private void Start()
    {
        activated = false;
    }

    public void Toggle()
    {
        TurnOff();
    }

    public void TurnOn()
    {
        activated = true;
        lights.HasPower = true;
    }

    public void TurnOff()
    {
        activated = false;
        lights.HasPower = false;
        npcSpawner.GetFoodGuy().GetComponent<NPCMoveScript>().GoTo("road");
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
