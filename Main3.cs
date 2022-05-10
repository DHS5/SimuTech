using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main3 : MonoBehaviour
{
    public static Main3 Instance;

    public Canvas canvas;

    public Sprite checkmark;
    public Sprite led;
    public Sprite aff7seg;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Création des inputs
        LogicalToggle tg0 = new LogicalToggle("tg0", 0, 150, checkmark, canvas);
        LogicalToggle tg1 = new LogicalToggle("tg1", 100, 50, checkmark, canvas);
        LogicalToggle tg2 = new LogicalToggle("tg2", 100, -50, checkmark, canvas);
        LogicalToggle tg3 = new LogicalToggle("tg3", 0, -150, checkmark, canvas);
        LogicalToggle tg4 = new LogicalToggle("tg4", -100, -50, checkmark, canvas);
        LogicalToggle tg5 = new LogicalToggle("tg5", -100, 50, checkmark, canvas);
        LogicalToggle tg6 = new LogicalToggle("tg6", -100, 0, checkmark, canvas);

        // Création des outputs
        Afficheur7seg a7s = new Afficheur7seg("7seg", -110, -100, aff7seg, canvas);

        // Association des sources
        a7s.led[0].AddSource(tg0);
        a7s.led[1].AddSource(tg1);
        a7s.led[2].AddSource(tg2);
        a7s.led[3].AddSource(tg3);
        a7s.led[4].AddSource(tg4);
        a7s.led[5].AddSource(tg5);
        a7s.led[6].AddSource(tg6);
    }
}
