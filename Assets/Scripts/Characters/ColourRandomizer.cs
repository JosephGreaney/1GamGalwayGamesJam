using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class ColourRandomizer : MonoBehaviour
{
    [SerializeField] private Color[] colours;
    private SpriteRenderer rend;
    
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Randomize();
    }

    public void Randomize()
    {
        rend.color = colours[Random.Range(0, colours.Length)];
    }
}
