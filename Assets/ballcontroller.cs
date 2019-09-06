using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballcontroller : MonoBehaviour
{
    public Vector3 start;
    public Text score;
    public Text timer;
    public int lscore = 0;
    public int rscore = 0;

    public bool origcrazy = false;
    public bool crazy = false;
    public float lastcrazy = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        start = transform.position;
        Shoot();
    }

    void Shoot()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        StartCoroutine(DoShoot());
    }

    void UpdateScore()
    {
        score.text = lscore.ToString() + " - " + rscore.ToString();
    }

    IEnumerator DoShoot()
    {
        crazy = false;
        int time = 3;
        while (time > 0)
        {
            timer.text = time.ToString();
            yield return new WaitForSeconds(1);
            time -= 1;
        }
        timer.text = "";
        crazy = origcrazy;
        int sgn = 1;
        if (Random.value > 0.5) sgn = -1;
        GetComponent<Rigidbody>().AddRelativeForce(sgn*(400 + Random.value * 150), 350 + Random.value * 250, 0);
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        if (crazy && Time.time >= lastcrazy + 8)
        {
            GetComponent<Rigidbody>().velocity = -GetComponent<Rigidbody>().velocity;
            lastcrazy = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.L)) origcrazy = !origcrazy;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = start;
        if (other.gameObject.CompareTag("lwall"))
            rscore += 1;
        else
            lscore += 1;
        UpdateScore();
        Shoot();
    }
}
