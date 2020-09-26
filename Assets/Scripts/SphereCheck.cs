using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SphereCheck : MonoBehaviour
{
    Rigidbody rb;
    public Text gameText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.tag);
        if (other.transform.tag == "Obstacle")
        {
            gameText.text = "Ouch.";
        }
        else if (other.transform.tag == "Target")
        {
            gameText.text = "Nice job!";
        }
        else
        {
            gameText.text = "";
        }
    }
}
