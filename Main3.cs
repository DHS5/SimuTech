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
        
    }
}
