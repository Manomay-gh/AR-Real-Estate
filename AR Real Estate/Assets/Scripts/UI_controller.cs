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


    public GameObject HomeButton;

    public GameObject cameraar;

    Raycasting raycasting ;
    // Start is called before the first frame update
    void Start()
    {
        cameraar = Camera.main.gameObject;
        cameraar.SetActive(false);
        raycasting = FindObjectOfType<Raycasting>();

        

        resetButton.SetActive(false);
        choosePanel.SetActive(true);
        aRRaycastManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
        aRPlaneManager = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();
        aRPlaneManager.enabled = false;
        aRRaycastManager.enabled = false;

        foreach(Button button in buttons)
        {
            button.onClick.AddListener(delegate { disablechoose(button); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Save.realobjectspawned==true)
        {
            resetButton.SetActive(true);
            HomeButton.SetActive(false);
        }
        else
        {
            resetButton.SetActive(false);
            HomeButton.SetActive(true);
        }

    }

    public void disablechoose(Button button)
    {
        choosePanel.SetActive(false);
        aRPlaneManager.enabled = true;
        aRRaycastManager.enabled = true;

        raycasting.assetno = int.Parse(button.gameObject.name);
        cameraar.SetActive(true);

    }


    public void EnableChoose()
    {
        choosePanel.SetActive(true);
        aRPlaneManager.enabled = false;
        aRRaycastManager.enabled = false;
        cameraar.SetActive(false);
    }
}
