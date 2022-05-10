using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalNOT : LogicalDoor
{
    public LogicalNOT(string _name, int _posX, int _posY) : base(_name, _posX, _posY)
    {
        maxSources = 1;
        InitSources();
    }

    protected override void Calculate()
    {
        // Exits return the contrary of entry
        exit = (entries[0] == 1) ? 0 : 1;

        // Keep this line at the end to call the base method
        base.Calculate();
    }

    public override void AddSource(LogicalComponent s, int sourceNumber = 0)
    {
        base.AddSource(s, sourceNumber);
    }
}
