using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class AlignBodyWithOVR : MonoBehaviour
{
    [Header("XRI Essentials")]
    private GameObject leftController;
    private GameObject rightController;
    private GameObject camera;

    [Header("Avatar Parts")]
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject head;

    [Header("Required Fields")]
    public PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        leftController = GameObject.FindGameObjectWithTag("LeftController");

        if(leftController != null)
            Debug.Log("CONTROLLER LEFT");
        
        rightController = GameObject.FindGameObjectWithTag("RightController");

        if (rightController != null)
            Debug.Log("CONTROLLER RIGHT");

        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            head.transform.position = camera.transform.position;
            head.transform.rotation = camera.transform.rotation;

            leftHand.transform.position = leftController.transform.position;
            leftHand.transform.rotation = leftController.transform.rotation;

            rightHand.transform.position = rightController.transform.position;
            rightHand.transform.rotation = rightController.transform.rotation;
        }
        

    }
}
