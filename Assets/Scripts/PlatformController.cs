using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Rigidbody platformRB;
    public Transform[] platformPositions;
    public float platformSpeed;

    private int actualPosition = 0;
    private int nextPosition = 1;

    public bool moveToTheNext = true;
    public float waitTime;

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (moveToTheNext)
        {
            StopCoroutine(WaitForMove()); // Stop any ongoing waiting coroutine
            platformRB.MovePosition(Vector3.MoveTowards(platformRB.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
        }

        if (Vector3.Distance(platformRB.position, platformPositions[nextPosition].position) <= 0.1f)
        {
            StartCoroutine(WaitForMove()); // Start waiting coroutine
            actualPosition = nextPosition;
            nextPosition = (nextPosition + 1) % platformPositions.Length; // Use modulo for looping
        }
    }

    IEnumerator WaitForMove()
    {
        moveToTheNext = false;
        yield return new WaitForSeconds(waitTime);
        moveToTheNext = true;
    }
}
