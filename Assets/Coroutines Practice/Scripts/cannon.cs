using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    public GameObject shotpoint;
    public GameObject cannonball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            shoot(5);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Steadyshot(6, 0.5f));

        }

    }
    public void shoot(int numberofballs)
    {
        for (int i = 0; i < numberofballs; i++)
        {
            Instantiate(cannonball, transform.position, transform.rotation);
        }
    }
    IEnumerator Steadyshot(int numberofballs, float delay)
    {
        for (int i = 0;i < numberofballs; i++)
        {
            Instantiate(cannonball, transform.position, transform.rotation);
            yield return new WaitForSeconds(delay);
        }
    }
}
