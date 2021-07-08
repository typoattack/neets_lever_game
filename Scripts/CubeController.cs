using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    ButtonController buttons;
    public int[] cubePositions = { 0, 0, 0, 0, 0 };
    public int[] buttonValues = new int[5];

    public int numCubes = 5;
    public GameObject[] cubeArray;
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.Find("ButtonHolder").GetComponent<ButtonController>();
        buttonValues = buttons.buttonValues;
        cubeArray = new GameObject[numCubes];
        /*
        for (int i = 0; i < numSelectors; i++)
        {
            GameObject newCube = Instantiate(selector, new Vector3(0, 2*i, 0), Quaternion.identity) as GameObject;
            newCube.transform.localScale = Vector3.one;
            cubeArray[i] = newCube;
        }
        */
        for (int i = 0; i < numCubes; i++)
        {
            cubeArray[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        buttonValues = buttons.buttonValues;
        for (int i = 0; i < cubePositions.Length; i++)
        {
            //Debug.Log(i + " " + cubePositions[i]);
            if (cubePositions[i] != buttonValues[i])
            {
                //cubePositions[i] = buttons.cubePositions[i];
                //Debug.Log("activate moveCube for button " + i);
                moveCube(i, buttonValues[i]);
            }
        }
        
        
    }
    
    void moveCube(int button, int newPosition)
    {
        //Debug.Log("CubeController button: " + button + " value: " + cubePositions[button]);
        //cubeArray[button].target = cubePositions[button];
        cubePositions[button] = newPosition;
        gameObject.transform.GetChild(button).GetComponent<CubeMover>().target = cubePositions[button];
    }
    
}