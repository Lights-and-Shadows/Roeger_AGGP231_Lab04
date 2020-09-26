using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereHit : MonoBehaviour
{
    public WinCondition condition;

    // Let's add a little explosive force to spice things up a bit
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(10f, collision.transform.position, 0.4f);
            condition.isCollided = true;
        }

        if (collision.collider == condition.targetCol)
        {
            condition.isCollided = true;
            condition.targetHit = true;
        }
    }
}
