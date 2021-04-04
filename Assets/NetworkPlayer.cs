using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("AssignBones", 2);

        XRRig rig = FindObjectOfType<XRRig>();
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView != null && photonView.IsMine)
        {
            rightHand.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            head.gameObject.SetActive(false);

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);
        }
    }

    void MapPosition(Transform target, Transform rigTransform) 
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }

    void AssignBones()
    {
        //Invoke("AssignBones", 2);
        head = GameObject.Find("Neck").transform;
        leftHand = GameObject.Find("LH").transform;
        rightHand = GameObject.Find("RH").transform;

        //leftHand.transform.Rotate(0, 90, 0);
        //rightHand.transform.Rotate(0, 90, 0);

        photonView = GetComponent<PhotonView>();
    }
}
