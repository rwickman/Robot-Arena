using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public float activationThreshold = 0.1f;


    private InputHelpers.Button teleportActivationButton;
    private XRRayInteractor rightRayInteractor;
    private XRRayInteractor leftRayInteractor;

    private void Start()
    {
        teleportActivationButton = rightTeleportRay.selectUsage;
        if (rightTeleportRay)
            rightRayInteractor = rightTeleportRay.gameObject.GetComponent<XRRayInteractor>();
        if (leftTeleportRay)
            leftRayInteractor = leftTeleportRay.gameObject.GetComponent<XRRayInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (leftTeleportRay)
        {
            bool isLeftActivated = CheckIfActivated(leftTeleportRay);
            leftRayInteractor.allowSelect = isLeftActivated;
            leftTeleportRay.gameObject.SetActive(isLeftActivated);
        }

        if (rightTeleportRay)
        {
            bool isRightActivated = CheckIfActivated(rightTeleportRay);
            rightRayInteractor.allowSelect = isRightActivated;
            rightTeleportRay.gameObject.SetActive(isRightActivated);
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
