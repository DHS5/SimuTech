using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LogicalComponent
{
    public List<LogicalComponent> sources = new List<LogicalComponent>();

    /// <summary>
    /// Number of sources expected
    /// </summary>
    protected int maxSources;

    public List<LogicalComponent> targets = new List<LogicalComponent>();

    protected string name;
    protected int posX;
    protected int posY;


    public List<int> entries = new List<int>();
    public int exit = 0;

    public LogicalComponent(string _name, int _posX, int _posY)
    {
        name = _name;
        posX = _posX;
        posY = _posY;
    }

    /// <summary>
    /// Add a source to the Logical Component
    /// Note : if it already possesses a source, the former one is replaced
    /// </summary>
    /// <param name="s">New source</param>
    /// <param name="sourceNumber">Number of the new source</param>
    public virtual void AddSource(LogicalComponent s, int sourceNumber) { }

    protected void InitSources()
    {
        for (int i = 0; i < maxSources; i++) { sources.Add(null); entries.Add(0); }
    }

    /// <summary>
    /// Actualize the entry value of the component
    /// </summary>
    public virtual void Actualization() { }

    /// <summary>
    /// Calculate the new value of the exit
    /// </summary>
    protected virtual void Calculate() { }

    /// <summary>
    /// Called when the exit value is changed
    /// </summary>
    public virtual void OnValueChange()
    {
        Debug.Log(this + " : value changed");
        // Browse on the targets and actualize them
        foreach (LogicalComponent LC in targets)
        {
            Debug.Log(this + " : target = " + LC);
            LC.Actualization();
        }
    }
}
