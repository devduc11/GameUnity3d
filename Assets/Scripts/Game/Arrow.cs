using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int idCheck;
    public double reward;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Circle")
        {
            Circle circle = other.GetComponent<Circle>();
            // print(circle.reward);
            reward = circle.reward;
        }
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "Circle")
    //     {
    //         reward = 0;
    //     }
    // }
}
