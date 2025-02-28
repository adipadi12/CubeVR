using UnityEngine;
using UnityEngine.XR;

public class DoorGrabbable : OVRGrabbable
{
     [SerializeField] private DoorLogic doorLogic; // Assign your DoorLogic script

    protected override void Start()
    {
        base.Start();
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        doorLogic.GrabStart(hand);
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        doorLogic.GrabEnd();
    }
}