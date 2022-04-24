using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplexer : LogicalDoor
{
    [Tooltip("Whether the multiplexer will return a null value or a high-impedance value (-1) if no sources are active")]
    public bool safe;
    
    public Multiplexer(string _name, int _posX, int _posY, bool _safe) : base(_name, _posX, _posY)
    {
        safe = _safe;
        maxSources = 1;
        InitSources();
    }

    public override void AddSource(LogicalComponent s, int sourceNumber)
    {
        if (sourceNumber == maxSources)
        {
            maxSources++;
            sources.Add(null);
            entries.Add(safe ? 0 : -1);
        }

        base.AddSource(s, sourceNumber);
    }

    protected override void Calculate()
    {
        int activeSources = 0;
        int entryIndex = -1;
        for (int i = 0; i < maxSources; i++)
        {
            if (entries[i] != -1)
            {
                activeSources++;
                entryIndex = i;
            }
        }

        Debug.Assert(activeSources <= 1, "Several sources active on component " + name + "\nActive sources number : " + activeSources + ";");

        // If a source is active, exit = source's exit
        if (activeSources == 1) exit = entries[entryIndex];

        // If no sources are active, exit = 0 if the multiplexer is safe and -1 if it's not
        else if (safe) exit = 0;
        else exit = -1;
        
        base.Calculate();
    }
}
