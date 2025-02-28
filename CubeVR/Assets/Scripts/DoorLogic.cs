using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // Required for XR components

public class DoorLogic : MonoBehaviour
{
    public enum MovementAxis { Horizontal, Vertical }
    public MovementAxis axis = MovementAxis.Horizontal;
    public float maxSlideDistance = 1.5f;
    public float moveSmoothness = 5f;

    private Vector3 _initialPosition;
    private bool _isGrabbed;
    private Transform _controllerTransform; // Generic transform to handle both XR and OVR

    void Start() => _initialPosition = transform.position;

    // Updated method to accept XRBaseInteractor
    public void GrabStart(XRBaseInteractor interactor)
    {
        _isGrabbed = true;
        _controllerTransform = interactor.transform; // Get controller position
    }

    // Overload for OVRGrabber (Meta-specific)
    public void GrabStart(OVRGrabber grabber)
    {
        _isGrabbed = true;
        _controllerTransform = grabber.transform;
    }

    public void GrabEnd()
    {
        _isGrabbed = false;
        _controllerTransform = null;
    }

    void Update()
    {
        if (!_isGrabbed || _controllerTransform == null) return;

        Vector3 controllerPos = _controllerTransform.position;
        Vector3 targetPosition = _initialPosition;

        switch (axis)
        {
            case MovementAxis.Horizontal:
                targetPosition.x = Mathf.Clamp(
                    controllerPos.x,
                    _initialPosition.x - maxSlideDistance,
                    _initialPosition.x + maxSlideDistance
                );
                break;

            case MovementAxis.Vertical:
                targetPosition.y = Mathf.Clamp(
                    controllerPos.y,
                    _initialPosition.y - maxSlideDistance,
                    _initialPosition.y + maxSlideDistance
                );
                break;
        }

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            moveSmoothness * Time.deltaTime
        );
    }
}