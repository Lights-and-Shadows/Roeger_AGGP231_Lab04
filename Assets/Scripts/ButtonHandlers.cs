using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHandlers : MonoBehaviour
{

    public Button toggle;

    public GameObject session;

    public TextMeshProUGUI toggleText;

    public bool isPlaneFinderActive;
    // Start is called before the first frame update
    void Start()
    {
        isPlaneFinderActive = true;

        toggle.onClick.AddListener(TogglePlaneFinder);
    }

    public void TogglePlaneFinder()
    {
        if (isPlaneFinderActive)
            isPlaneFinderActive = false;
        else
            isPlaneFinderActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaneFinderActive)
        {
            session.GetComponent<MakeAppearOnPlane>().enabled = true;
            toggleText.text = "Plane Finder On";
        }
        else
        {
            session.GetComponent<MakeAppearOnPlane>().enabled = false;
            toggleText.text = "Plane Finder Off";
        }
    }
}
