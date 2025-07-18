using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [Tooltip("Scales translation thruster impulse")]
    [Range(0, 1)]
    public float translationSensitivity;

    [Tooltip("Scales rotation thruster impulse")]
    [Range(0, 1)]
    public float rotationSensitivity;

    [Header("Thrusters Max Impulse")]
    [Header("Translation Thrusters")]
    [SerializeField]
    float ForwardsThrusterImpulse = 10000f;

    [SerializeField]
    float BackwardsThrusterImpulse = 10000f;

    [SerializeField]
    float RightThrusterImpulse = 10000f;

    [SerializeField]
    float LeftThrusterImpulse = 10000f;

    [SerializeField]
    float UpThrusterImpulse = 10000f;

    [SerializeField]
    float DownThrusterImpulse = 10000f;


    [Header("Rotation Thrusters")]
    [SerializeField]
    float PitchTorqueImpulse = 10000f;

    [SerializeField]
    float RollTorqueImpulse = 10000f;

    [SerializeField]
    float YawTorqueImpulse = 10000f;


    //Impulse applied on the craft on each axis
    Vector3 ImpulseForwardsBackwards, ImpulseUpDown, ImpulseRightLeft;





    [Header("Miscellaneous")]

    [SerializeField]
    [Tooltip("Total mass of the spacecraft")]
    float CraftMass = 1000;


    [SerializeField]
    [Tooltip("Slows down the translation of the craft. THERE IS NO DRAG IN SPACE")]
    float TranslationDrag;

    [SerializeField]
    [Tooltip("Slows down the translation of the craft. THERE IS NO DRAG IN SPACE")]
    float RotationDrag;






    Rigidbody rb;


    //every component of the input. This should probably be some kind of array
    float InputForwards, InputBackwards, InputUp, InputDown, InputRight, InputLeft, InputRoll, InputPitch, InputYaw;



    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.drag = TranslationDrag;
        rb.angularDrag = RotationDrag;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            moveForwards();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            moveBackwards();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            translateUp();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            translateDown();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            translateLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            translateRight();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            rollLeft();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            rollRight();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pitchUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pitchDown();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            yawRight();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            yawLeft();
        }
    }

    private void FixedUpdate()
    {
        rb.mass = CraftMass;


        //Translation
        //Calculates the impulse on each axis
        //Forwards and backwards (local Z axis)
        ImpulseForwardsBackwards = ForwardsThrusterImpulse * InputForwards * transform.forward - BackwardsThrusterImpulse * InputBackwards * transform.forward;

        //Up and down (local Y axis)
        ImpulseUpDown = UpThrusterImpulse * InputUp * transform.up - DownThrusterImpulse * InputDown * transform.up;

        //Left and right (local X axis)
        ImpulseRightLeft = RightThrusterImpulse * InputRight * transform.right - LeftThrusterImpulse * InputLeft * transform.right;

        //print("FB" + ForceForwardsBackwards);

        //Adds the total impulse to the spacecraft
        rb.AddForce(translationSensitivity * (ImpulseForwardsBackwards + ImpulseUpDown + ImpulseRightLeft), ForceMode.Impulse);


        //Rotation
        //Calculates the torque around each axis, adds them together, and applies them. Uses impulses.
        rb.AddTorque(rotationSensitivity * (-RollTorqueImpulse * InputRoll * transform.forward + -PitchTorqueImpulse * InputPitch * transform.right + YawTorqueImpulse * InputYaw * transform.up), ForceMode.Impulse);

        //Reset axes to 0 after physics calculation
        InputForwards = 0;
        InputBackwards = 0;
        InputUp = 0;
        InputDown = 0;
        InputRight = 0;
        InputLeft = 0;
        InputRoll = 0;
        InputPitch = 0;
        InputYaw = 0;


    }

    public void moveForwards()
    {
        InputForwards = 1;
    }

    public void moveBackwards()
    {
        InputBackwards = 1;
    }

    public void translateUp()
    {
        InputUp = 1;
    }

    public void translateDown()
    {
        InputDown = 1;
    }

    public void translateRight()
    {
        InputRight = 1;
    }

    public void translateLeft()
    {
        InputLeft = 1;
    }


    //TODO: input for each axis is 0 when both keys are pressed on the same frame
    public void rollRight()
    {
        InputRoll = 1;
    }

    public void rollLeft()
    {
        InputRoll = -1;
    }

    public void pitchUp()
    {
        InputPitch = 1;
    }

    public void pitchDown()
    {
        InputPitch = -1;
    }

    public void yawRight()
    {
        InputYaw = 1;
    }

    public void yawLeft()
    {
        InputYaw = -1;
    }
}
