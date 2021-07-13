using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControllerLR : MonoBehaviour
{
    GameController gameController;
    ButtonController buttonController;
    public int[] cubePositions;
    public int[] buttonValues;
    public int[] testArray;

    public int numCubes = 0;
    public GameObject[] cubeArray;
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        numCubes = gameController.numButtons;

        buttonController = GameObject.Find("ButtonHolder").GetComponent<ButtonController>();

        cubePositions = new int[numCubes];
        testArray = new int[numCubes];
        buttonValues = new int[numCubes];
        cubeArray = new GameObject[numCubes];

        for (int i = 0; i < numCubes; i++)
        {
            buttonValues[i] = buttonController.buttonValues[i];
            cubeArray[i] = gameObject.transform.GetChild(i).gameObject;
            cubePositions[i] = buttonValues[i];
            moveCube(i, buttonValues[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numCubes; i++)
        {
            buttonValues[i] = buttonController.buttonValues[i];
            testArray[i] = buttonController.testArray[i];

            if (cubePositions[i] != buttonValues[i])
            {
                moveCube(i, buttonValues[i]);
            }

            if (cubePositions[i] == testArray[i])
            {
                cubeArray[i].gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }
            else
            {
                cubeArray[i].gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
        }


    }

    void moveCube(int button, int newPosition)
    {
        cubePositions[button] = newPosition;
        if (button < numCubes / 2)
        {
            cubeArray[button].gameObject.GetComponent<CubeMoverLR>().target = -(cubePositions[button] + 1);
        }
        else
        {
            cubeArray[button].gameObject.GetComponent<CubeMoverLR>().target = (cubePositions[button] + 1);
        }
    }

}
