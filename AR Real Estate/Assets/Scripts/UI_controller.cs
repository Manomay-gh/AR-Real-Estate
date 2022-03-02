using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class UI_controller : MonoBehaviour
{
    public GameObject resetButton;
    public GameObject choosePanel;

    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;

    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        resetButton.SetActive(false);
        choosePanel.SetActive(true);
        aRRaycastManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
        aRPlaneManager = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();
        aRPlaneManager.enabled = false;
        aRRaycastManager.enabled = false;

        foreach(Button button in buttons)
        {
            button.onClick.AddListener(disablechoose);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Save.realobjectspawned==true)
        {
            resetButton.SetActive(true);
        }
        else
        {
            resetButton.SetActive(false);
        }

    }

    public void disablechoose()
    {
        choosePanel.SetActive(false);
        aRPlaneManager.enabled = true;
        aRRaycastManager.enabled = true;
    }
}
