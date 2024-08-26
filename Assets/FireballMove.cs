using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMove : MonoBehaviour
{
    public float speed;
    public GameObject[] patrolPoints;
    public int whichPoint;
    public float distToPatrolPoint;

    // Start is called before the first frame update
    void Start()
    {
        whichPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[whichPoint].transform.position, Time.deltaTime * speed);

        distToPatrolPoint = Vector3.Distance(transform.position, patrolPoints[whichPoint].transform.position);

        if (distToPatrolPoint < 0.02f)
        {
            whichPoint++;

            if (whichPoint >= patrolPoints.Length)
            {
                whichPoint = 0;
            }
        }
    }
}
