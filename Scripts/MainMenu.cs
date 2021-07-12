using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public int numButtons;

    // Start is called before the first frame update
    void Start()
    {
        numButtons = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void game3()
    {
        numButtons = 3;
    }

    public void game5()
    {
        numButtons = 5;
    }

    public void game7()
    {
        numButtons = 7;
    }
}
