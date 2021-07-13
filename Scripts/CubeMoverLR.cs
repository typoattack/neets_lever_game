using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoverLR : MonoBehaviour
{
    private float speed;
    private Vector2 destination;
    public int target;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        destination = new Vector2(target, transform.position.y);
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, destination, step);
    }
}
