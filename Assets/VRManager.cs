using UnityEngine;
using UnityEngine.XR.Management;

public class VRManager : MonoBehaviour
{
    public Camera camera2D;
    public GameObject xrOrigin;

    void Start()
    {
        bool xrActive = false;

        if (XRGeneralSettings.Instance != null &&
            XRGeneralSettings.Instance.Manager != null &&
            XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            xrActive = true;
        }

        EnableVR(xrActive);
    }

    void EnableVR(bool enable)
    {
        if (camera2D != null) camera2D.gameObject.SetActive(!enable);
        if (xrOrigin != null) xrOrigin.SetActive(enable);

        Debug.Log("VRManager: enableVR = " + enable);
    }
}
