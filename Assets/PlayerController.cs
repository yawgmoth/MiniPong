using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0 && transform.position.y<6)
        {
            transform.Translate(0, 5 * Time.deltaTime, 0);
        }

        if (Input.GetAxis("Vertical") < 0 && transform.position.y > -6)
        {
            transform.Translate(0, -5 * Time.deltaTime, 0);
        }
    }
}
