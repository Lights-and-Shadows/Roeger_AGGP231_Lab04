using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Starter code grabbed from Unity Answers
// https://answers.unity.com/questions/44882282/unity3d-ball-not-being-thrown-on-swipe


public class DragSpheres : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;

    public Transform sphereTrans;
    public float moveSpeed = 5f;
    public WinCondition condition;

    public Transform targetBlock;

    public Rigidbody rb;

    private float startTime;
    private Vector3 startPos;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.SphereCast(ray, 0.1f, out hit))
                {
                    if (hit.collider.name == "Sphere")
                    {
                        sphereTrans = hit.transform;
                        startTime = Time.time;
                        startPos = touch.position;
                    }
                    else
                    {
                        sphereTrans = null;
                    }
                }
            }

            //if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            //{
            //    Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, -sphereTrans.position.z));
            //    //float rate = 1.0f / Vector3.Distance(sphereTrans.position, touchedPos) * moveSpeed;
            //    sphereTrans.position = touchedPos;
            //}

            if (touch.phase == TouchPhase.Ended)
            {

                Vector3 endPos = touch.position;
                float endTime = Time.time;

                startPos.z = -sphereTrans.position.z;
                endPos.z = -sphereTrans.position.z;

                // The positions for the touch
                startPos = Camera.main.ScreenToWorldPoint(startPos);
                endPos = Camera.main.ScreenToWorldPoint(endPos);

                float duration = endTime - startTime;

                Vector3 dir = endPos - startPos;

                float distance = dir.magnitude;

                dir.z = distance;

                float power = distance / duration;

                // Expected / desired values for power to better control our throws
                const float expectedMin = 70f;
                const float expectedMax = 80f;
                const float desiredMin = 21.5f;
                const float desiredMax = 26f;

                // Change power scale to 0 - 1
                power -= expectedMin;
                power /= expectedMax - expectedMin;

                // Clamp
                power = Mathf.Clamp01(power);

                // Change power
                power *= desiredMax - desiredMin;
                power += desiredMin;

                Vector3 velocity = (sphereTrans.rotation * dir).normalized * power;

                rb.AddForce(velocity, ForceMode.Impulse);
            }
        }
    }
}
