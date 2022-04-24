using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalDoor : LogicalComponent
{
    private int totalSources = 0;
    
    public LogicalDoor(string _name, int _posX, int _posY) : base(_name, _posX, _posY) { }




    public override void OnValueChange()
    {
        Debug.Log(this + " : value changed");
        // Browse on the targets and actualize them
        foreach (LogicalComponent LC in targets)
        {
            Debug.Log(name + " : target = " + LC.name);
            LC.Actualization();
        }
    }

    protected override void Calculate()
    {
        Debug.Log(name + " : exit = " + exit);
        OnValueChange();
    }

    public override void Actualization()
    {
        if (totalSources == maxSources)
        {
            for (int i = 0; i < maxSources; i++)
            {
                entries[i] = sources[i].exit;
                Debug.Log(name + " : entry " + i + " = " + entries[i]);
            }

            Calculate();
        }
    }

    public override void AddSource(LogicalComponent s, int sourceNumber)
    {
        if (!targets.Contains(s) && sourceNumber < maxSources)
        {
            // Add a source to the door and increment totalSources if the source was previously null
            if (sources[sourceNumber] == null) totalSources++;
            sources[sourceNumber] = s;
            entries[sourceNumber] = s.exit;
            // Add the door as the source's target
            s.targets.Add(this);

            Debug.Log(name + " : source " + sourceNumber + " = " + s.name);

            // Actualise the door's exit value
            Actualization();
        }

        else
        { 
            Debug.Assert(targets.Contains(s), "Can't have a target as a source");
            Debug.Assert(sourceNumber > maxSources, "Source Number > Maximum Sources Number");
        }
    }
}
