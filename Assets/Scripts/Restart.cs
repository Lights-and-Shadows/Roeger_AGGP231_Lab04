using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public TiltControls tilter;
    public SphereCheck checker;
    public GameObject sphere;

    public Button button;

    void Start()
    { 
        button.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        tilter.currentRot = Vector3.zero;

    }
}
