using UnityEngine;

public class FlippersController : MonoBehaviour
{
    public HingeJoint2D _leftFliperHinge;
    public HingeJoint2D _rightFliperHinge;

    private JointMotor2D _motor_left;
    private JointMotor2D _motor_right;

    void Start()
    {
        _motor_left = _leftFliperHinge.motor;
        _motor_right = _rightFliperHinge.motor;

        _motor_left.motorSpeed = 0f;
        _motor_right.motorSpeed = -200f;

        _leftFliperHinge.motor = _motor_left;
        _rightFliperHinge.motor = _motor_right;
    }

    void Update()
    {
        HandleInputs();
    }

    private void HandleInputs()
    {
        _motor_left.maxMotorTorque = 10000f;
        _motor_right.maxMotorTorque = 10000f;

        _leftFliperHinge.motor = _motor_left;
        _rightFliperHinge.motor = _motor_right;
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _motor_left.motorSpeed = -350;
            _leftFliperHinge.motor = _motor_left;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _motor_left.motorSpeed = 200f;
            _leftFliperHinge.motor = _motor_left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _motor_right.motorSpeed = 350;
            _rightFliperHinge.motor = _motor_right;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _motor_right.motorSpeed = -200;
            _rightFliperHinge.motor = _motor_right;
        }
    }
}