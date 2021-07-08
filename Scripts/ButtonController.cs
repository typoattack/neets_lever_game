using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public int buttonPressed = 0;
    public int[] buttonValues = { 0, 0, 0, 0, 0 };

    private int[] testArray = { 1, 1, 1, 1, 1 };
    private int[] resetArray = { 0, 0, 0, 0, 0 };

    public int numButtons = 5;
    public GameObject[] buttonArray;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<ButtonBehaviorSequential>().childNumber = 0;

        for (int i = 1; i < numButtons; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<ButtonBehaviors>().childNumber = i;
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
