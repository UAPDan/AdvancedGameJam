using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStick : MonoBehaviour
{
    public float timer;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0, timer, 0);

        if(timer > 360)
        {
            timer = 0;
        }

    }
}
