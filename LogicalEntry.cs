using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalEntry : LogicalComponent
{
    public LogicalEntry(string _name, int _posX, int _posY) : base(_name, _posX, _posY)
    {

    }

    /// <summary>
    /// Called when the value of the entry changes
    /// </summary>
    public override void OnValueChange()
    {
        Debug.Log(this + " : value changed");
        // Browse on the targets and actualize them
        foreach (LogicalComponent LC in targets)
        {
            Debug.Log(this + " : target = " + LC);
            LC.Actualization();
        }
    }

    public override void AddSource(LogicalComponent s, int sourceNumber)
    {
        Debug.Log("Can't add source to an entry");
    }

    public override void Actualization()
    {
        Debug.Log("Can't actualize an entry");
    }

    protected override void Calculate()
    {
        Debug.Log("Can't calculate an entry");
    }
}
