using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicalLED : LogicalExit
{
    private Color one = new Color(255, 0, 0);
    private Color zero = new Color(255, 255, 255);

    public GameObject led;

    private Image image;

    public LogicalLED(string _name, int _posX, int _posY, Sprite _sprite) : base(_name, _posX, _posY)
    {
        // Creates a LED (image)
        DefaultControls.Resources uiResources = new DefaultControls.Resources();
        led = DefaultControls.CreateImage(uiResources);
        // Sets its position and name
        led.transform.SetParent(Main.Instance.canvas.transform);
        led.transform.localPosition = new Vector2(posX, posY);
        led.name = name;
        image = led.GetComponentInChildren<Image>();
        image.sprite = _sprite;
        image.color = zero;
    }

    public override void OnValueChange()
    {
        // Change the color of the LED according to the exit value
        image.color = exit == 1 ? one : zero;
    }
}
