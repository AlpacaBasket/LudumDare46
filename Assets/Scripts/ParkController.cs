using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkController : MonoBehaviour
{

    public HUD hud;
    public SquirrelController player;

    private int popularity; // 0-100 maybe
    private List<GuestController> guests; // List of guests

    // Add spawn points

    // Start is called before the first frame update
    void Start()
    {
        popularity = 0; // Set default value just in case
        guests = new List<GuestController>();
    }

    // Update is called once per frame
    void Update()
    {
        hud.DisplayPopularity(popularity);
    }

    public void PerformedTrick(string trick)
    {
        
    }

    public int getPopularity()
    {
        return this.popularity;
    }

    public void setPopularity(int i)
    {
        this.popularity = i;
    }
}
