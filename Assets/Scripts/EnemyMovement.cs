using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject pointAObject;
    public GameObject pointBObject;
    public float speed = 1;
    public float waitTime = 5;
    private bool isWaiting = false;
    private float waitTimer = 0;

    void Update()
    {
        if (!isWaiting)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, pointBObject.transform.position, step);

            if (transform.position == pointBObject.transform.position)
            {
                isWaiting = true;
                waitTimer = waitTime;
            }
        }
        else
        {
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
            }
            else
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;

                GameObject temp = pointAObject;
                pointAObject = pointBObject;
                pointBObject = temp;

                isWaiting = false;
            }
        }
    }
}