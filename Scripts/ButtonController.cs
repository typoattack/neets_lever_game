using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    GameController gameController;

    public int buttonPressed = 0;
    public int[] buttonValues;

    private int[] testArray;
    private int[] resetArray;

    public int numButtons = 0;
    public GameObject[] buttonArray;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        numButtons = gameController.numButtons;

        buttonValues = new int[numButtons];
        testArray = new int[numButtons];
        resetArray = new int[numButtons];

        buttonValues[0] = 0;
        testArray[0] = 1;
        resetArray[0] = 0;
        gameObject.transform.GetChild(0).GetComponent<ButtonBehaviorSequential>().childNumber = 0;

        for (int i = 1; i < numButtons; i++)
        {
            buttonValues[i] = 0;
            testArray[i] = 1;
            resetArray[i] = 0;
            gameObject.transform.GetChild(i).GetComponent<ButtonBehaviors>().childNumber = i;
            Debug.Log(buttonValues[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkForWin();
    }

    public void updatePositions(int button)
    {
        buttonValues[button]++;
        if (buttonValues[button] > 1) buttonValues[button] = 0;
    }

    void checkForWin()
    {
        for (int i = 0; i < buttonValues.Length; i++)
        {
            if (buttonValues[i] != testArray[i])
            {
                return;
            }
        }
        StartCoroutine(ResetButtons());
    }

    IEnumerator ResetButtons()
    {
        yield return new WaitForSeconds(1);
        Reset();
    }

    public void Reset()
    {
        for (int i = 0; i < buttonValues.Length; i++)
        {
            buttonValues[i] = resetArray[i];
        }

        gameObject.transform.GetChild(0).GetComponent<ButtonBehaviorSequential>().childNumber = 0;
        gameObject.transform.GetChild(0).GetComponent<ButtonBehaviorSequential>().firstButtonPush = true;

        for (int i = 1; i < numButtons; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<ButtonBehaviors>().childNumber = i;
        }
    }

    public void NewGame()
    {
        Reset();
        BroadcastMessage("GetNewBehaviors");
    }
}
