using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalExit : LogicalComponent
{
    public LogicalExit(string _name, int _posX, int _posY) : base(_name, _posX, _posY)
    {
        maxSources = 1;
        InitSources();
    }

    public override void OnValueChange() { }

    public override void Actualization()
    {
        exit = sources[0].exit;
        Debug.Log(name + " : exit = " + exit);

        OnValueChange();
    }

    /// <summary>
    /// Add a source to the exit
    /// </summary>
    /// <param name="s">Source</param>
    /// <param name="sourceNumber">0</param>
    public override void AddSource(LogicalComponent s, int sourceNumber = 0)
    {
        // Add the source to the exit
        sources[0] = s;
        // Add the exit as the source's target
        s.targets.Add(this);

        Debug.Log(name + " : source = " + s.name);

        // Actualise the exit value
        Actualization();
    }

    protected override void Calculate()
    {
        Debug.Log("Can't calculate an exit");
    }
}
