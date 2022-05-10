using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicalButton : LogicalEntry
{
    public LogicalButton(string _name, int _posX, int _posY, Canvas canvas) : base(_name, _posX, _posY)
    {
        // Creates a button
        DefaultControls.Resources uiResources = new DefaultControls.Resources();
        GameObject button = DefaultControls.CreateButton(uiResources);
        // Sets its position and name
        button.transform.SetParent(canvas.transform);
        button.transform.localPosition = new Vector2(posX, posY);
        button.name = name;
        button.GetComponentInChildren<Text>().text = name;
        // Gives the button the method to call on click
        button.GetComponent<Button>().onClick.AddListener(OnValueChange);
    }

    public override void OnValueChange()
    {
        // Creates a pulse
        exit = 1;
        base.OnValueChange();
        // Then puts back the exit to 0
        exit = 0;
        base.OnValueChange();
    }
}
