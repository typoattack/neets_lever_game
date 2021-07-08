using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviorSequential : MonoBehaviour
{
    ButtonController buttonController;

    public int childNumber = 0;
    public int childInFront = 0;
    public int childTwoInFront = 0;
    public int childBehind = 0;
    public int childTwoBehind = 0;

    private int totalNumberOfChildren = 0;

    public int behavior = 0;
    private int totalNumberOfBehaviors = 5;

    public bool firstButtonPush = true;

    // Start is called before the first frame update
    void Start()
    {
        buttonController = GameObject.Find("ButtonHolder").GetComponent<ButtonController>();
        totalNumberOfChildren = buttonController.numButtons;
        behavior = Random.Range(1, totalNumberOfBehaviors);
    }

    // Update is called once per frame
    void Update()
    {
        if (childNumber + 1 >= totalNumberOfChildren) childInFront = 0;
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
        behavior = Random.Range(1, totalNumberOfBehaviors);
        firstButtonPush = true;
        childNumber = 0;
    }

    public void onPush()
    {
        switch (behavior)
        {
            default: // do nothing
                break;
            case 1: // toggle blocks in the right direction
                press(childNumber);
                if (!firstButtonPush) press(childBehind);
                else firstButtonPush = false;
                increment();
                break;
            case 2: // toggle blocks in the left direction
                press(childNumber);
                if (!firstButtonPush) press(childInFront);
                else firstButtonPush = false;
                decrement();
                break;
            case 3: // toggle blocks in front of and behind button in the right direction
                press(childBehind);
                press(childInFront);
                if (!firstButtonPush)
                {
                    press(childNumber);
                    press(childTwoBehind);
                }
                else firstButtonPush = false;
                increment();
                break;
            case 4: // toggle blocks in front of and behind button in the left direction
                press(childBehind);
                press(childInFront);
                if (!firstButtonPush)
                {
                    press(childNumber);
                    press(childTwoInFront);
                }
                else firstButtonPush = false;
                decrement();
                break;
        }
    }

    void press(int positionToChange)
    {
        buttonController.updatePositions(positionToChange);
    }

    void increment()
    {
        childNumber++;
        if (childNumber >= totalNumberOfChildren) childNumber = 0;
    }

    void decrement()
    {
        childNumber--;
        if (childNumber < 0) childNumber = totalNumberOfChildren - 1;
    }
}
