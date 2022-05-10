using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicalToggle : LogicalEntry
{
    private GameObject toggle;


    public LogicalToggle(string _name, int _posX, int _posY, Sprite _sprite, Canvas canvas) : base(_name, _posX, _posY)
    {
        DefaultControls.Resources uiResources = new DefaultControls.Resources();
        uiResources.checkmark = _sprite;
        toggle = DefaultControls.CreateToggle(uiResources);
        toggle.transform.SetParent(canvas.transform);
        toggle.transform.localPosition = new Vector2(posX, posY);
        toggle.name = name;
        toggle.GetComponentInChildren<Text>().text = name;

        toggle.GetComponent<Toggle>().onValueChanged.AddListener(delegate { OnValueChange(); });
        OnValueChange();
    }

    public override void OnValueChange()
    {
        // Changes the exit value according to the toggle state
        exit = toggle.GetComponent<Toggle>().isOn ? 1 : 0;
        Debug.Log(this + " : " + (exit == 1 ? "On" : "Off"));

        // Calls the base method
        base.OnValueChange();
    }
}
