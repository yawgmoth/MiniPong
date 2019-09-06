using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dy = ball.position.y - transform.position.y;
        if (dy > 0 && transform.position.y < 6)
        {
            transform.Translate(0, 6 * Time.deltaTime, 0);
        }

        if (dy < 0 && transform.position.y > -6)
        {
            transform.Translate(0, -6 * Time.deltaTime, 0);
        }
    }
}
