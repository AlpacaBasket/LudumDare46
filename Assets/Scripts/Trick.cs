using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trick : MonoBehaviour
{

    private int points;
    private string displayname;

    public void setPoints(int i)
    {
        this.points = i;
    }

    public int getPoints()
    {
        return this.points;
    }

    public void setname(string s)
    {
        this.displayname = s;
    }

    public string getname()
    {
        return this.displayname;
    }

}
