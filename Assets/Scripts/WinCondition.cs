using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public Collider targetCol;
    private List<Collider> currentCollisions;
    public Text winText;
    public bool isCollided, targetHit;

    public void Start()
    {
        isCollided = false;
    }

    public void Update()
    {
        if (isCollided == true)
            StartCoroutine(CheckImpact());
    }

    private IEnumerator CheckImpact()
    {
        yield return new WaitForSeconds(2f);

        if (targetHit)
            winText.text = "Nice shot!";
        else
            winText.text = "So close...";

        yield return null;
    }

}
