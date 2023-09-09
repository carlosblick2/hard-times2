using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFloor : MonoBehaviour
{
    public CharacterController Player;

    Vector3 groundPosition;
    Vector3 lastGroundPosition;
    string groundName;
    string lastGroundName;

    Quaternion actualRot;
    Quaternion lastRot;

    public Vector3 originOffset;
    public float factorDivision = 4.2f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (Player.isGrounded)
        {
            RaycastHit hit;

            // Cambiar el SphereCast a Raycast
            if (Physics.Raycast(transform.position + originOffset, -transform.up, out hit, Player.radius / factorDivision))
            {
                print("PASS");
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;

                actualRot = groundedIn.transform.rotation;

                if (groundPosition != lastGroundPosition && groundName == lastGroundName)
                {
                    transform.position += groundPosition - lastGroundPosition;
                }

                if (actualRot != lastRot && groundName == lastGroundName)
                {
                    Quaternion newRot = Quaternion.Euler(0, actualRot.eulerAngles.y - lastRot.eulerAngles.y, 0);
                    transform.RotateAround(groundedIn.transform.position, Vector3.up, newRot.eulerAngles.y);
                }

                lastGroundName = groundName;
                lastGroundPosition = groundPosition;
                lastRot = actualRot;
            }
        }
        else if (!Player.isGrounded)
        {
            lastGroundName = null;
            lastGroundPosition = Vector3.zero;
            lastRot = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + originOffset, Player.radius / factorDivision);
    }
}
