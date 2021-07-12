using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviors : MonoBehaviour
{
    GameController gameController;
    ButtonController buttonController;
    
    public int childNumber = 0;
    public int childInFront = 0;
    public int childTwoInFront = 0;
    public int childBehind = 0;
    public int childTwoBehind = 0;

    public int totalNumberOfChildren = 0;

    public int behavior = 0;
    private int totalNumberOfBehaviors = 6;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        totalNumberOfChildren = gameController.numButtons;
        buttonController = GameObject.Find("ButtonHolder").GetComponent<ButtonController>();
        if (totalNumberOfChildren == 3) behavior = Random.Range(1, 3);
        else behavior = Random.Range(1, totalNumberOfBehaviors);
    }

    // Update is called once per frame
    void Update()
    {
        if (childNumber + 1 >= totalNumberOfChildren) childInFront = childNumber + 1 - totalNumberOfChildren;
        else childInFront = childNumber + 1;

        if (childNumber + 2 >= totalNumberOfChildren) childTwoInFront = childNumber + 2 - totalNumberOfChildren;
        else childTwoInFront = childNumber + 2;

        if (childNumber - 1 < 0) childBehind = totalNumberOfChildren - 1;
        else childBehind = childNumber - 1;

        if (childNumber - 2 < 0) childTwoBehind = childNumber - 2 + totalNumberOfChildren;
        else childTwoBehind = childNumber - 2;
    }

    public void GetNewBehaviors()
    {
        if (totalNumberOfChildren == 3) behavior = Random.Range(1, 3);
        else behavior = Random.Range(1, totalNumberOfBehaviors);
    }

    public void onPush()
    {
        switch (behavior)
        {
            default: // do nothing
                break;
            case 1: // toggle block above button
                press(childNumber);
                break;
            case 2: // toggle blocks in front of and behind button
                press(childBehind);
                press(childInFront);
                break;
            case 3: // toggle blocks above, in front of, and behind button
                press(childNumber);
                press(childBehind);
                press(childInFront);
                break;
            case 4: // toggle blocks two in front of and two behind button
                press(childTwoInFront);
                press(childTwoBehind);
                break;
            case 5: // toggle blocks above, two in front of, and two behind button
                press(childNumber);
                press(childTwoInFront);
                press(childTwoBehind);
                break;
        }
    }

    void press(int positionToChange)
    {
        buttonController.updatePositions(positionToChange);
    }
}
