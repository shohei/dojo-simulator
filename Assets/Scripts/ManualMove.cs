using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Unity.Robotics.ROSTCPConnector;
// using RosMessageTypes.Geometryo;
// using Unity.Robotics.UrdfImporter.Control;


public class ManualMove : MonoBehaviour
{
    public GameObject wheel1;
    public GameObject wheel2;
    private ArticulationBody wA1;
    private ArticulationBody wA2;
    public float maxLinearSpeed = 2; //  m/s
    public float maxRotationalSpeed = 1;//
    public float wheelRadius = 0.033f; //meters
    public float trackWidth = 0.288f; // meters Distance between tyres
    public float forceLimit = 10;
    public float damping = 10;

    // private RotationDirection direction;

    // Start is called before the first frame update
    void Start()
    {
        wA1 = wheel1.GetComponent<ArticulationBody>();
        wA2 = wheel2.GetComponent<ArticulationBody>();
        SetParameters(wA1);
        SetParameters(wA2);
        Debug.Log("manualmove: "+wA1.GetInstanceID());
    }
    private void SetParameters(ArticulationBody joint)
    {
        ArticulationDrive drive = joint.xDrive;
        drive.forceLimit = forceLimit;
        drive.damping = damping;
        joint.xDrive = drive;
    }

    private float wheel1Rotation = 0;
    private float wheel2Rotation = 0;
    // Update is called once per frame
    private float prev_wheel1Rotation = 0;
    void FixedUpdate()
    {
        if (prev_wheel1Rotation!=wheel1Rotation){
            Debug.Log("changed: prev:"+prev_wheel1Rotation+", cur:"+wheel1Rotation);
            prev_wheel1Rotation = wheel1Rotation;
        }
        SetSpeed(wA1, wheel1Rotation);
        SetSpeed(wA2, wheel2Rotation);
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        wheel1Rotation = 0;
        wheel2Rotation = 0;
    }

    public void Forward()
    {
        wheel1Rotation = 0.99f;
        wheel2Rotation = 0.99f;
        StartCoroutine(ExecuteAfterTime(2));
    }

    void SetSpeed(ArticulationBody joint, float wheelSpeed = float.NaN)
    {
        ArticulationDrive drive = joint.xDrive;
        drive.targetVelocity = wheelSpeed;
        joint.xDrive = drive;
    }

}