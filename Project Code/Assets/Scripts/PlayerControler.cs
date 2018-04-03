using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(ConfigurableJoint))]
public class PlayerControler : MonoBehaviour {

    public bool MouseKeys = true;
    public bool XboxOneMini = false;

    private string controlRotationX;
    private string controlRotationY;

    private string MKMouseX = "Mouse X";
    private string MKMouseY = "Mouse Y";

    private string XOMouseX = "RightAnalogX";
    private string XOMouseY = "RightAnalogY";

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 3f;

	[SerializeField]
	private float thrusterForce = 10f;

	[Header("Spring Settings:")]
	//[SerializeField]
	//private JointDriveMode jointMode = JointDriveMode.Position;
	[SerializeField]
	private float jointSpring = 20f;
	[SerializeField]
	private float jointMaxForce = 40f;

	private PlayerMotor motor;
	private ConfigurableJoint joint;

	void Start()
	{
		motor = GetComponent<PlayerMotor> ();
		joint = GetComponent<ConfigurableJoint> ();
		SetJointSettings (jointSpring);

        if(MouseKeys)
        {
            XboxOneMini = false;
            controlRotationX = MKMouseX;
            controlRotationY = MKMouseY;
        }
        else if(XboxOneMini)
        {
            MouseKeys = false;
            controlRotationX = XOMouseX;
            controlRotationY = XOMouseY;
        }
	}

	void Update()
	{
		// Calculate movement
		float _xMov = Input.GetAxis("Horizontal");
		float _yMov = Input.GetAxis("Vertical");

		Vector3 _moveHorizontal = transform.right * _xMov;
		Vector3 _moveVertical = transform.forward * _yMov;

		// Final mov vector
		Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

		// Apply mov
		motor.Move(_velocity);

		// Calc rot as 3D vector // For turning
        float _yRot = Input.GetAxis(controlRotationX);
		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;

		// Apply rotation
		motor.Rotate(_rotation);

		// Calc cam rot
        float _xRot = Input.GetAxis(controlRotationY);

		float _cameraRotationX = _xRot * lookSensitivity;

		// Apply rotation
		motor.RotateCamera(_cameraRotationX);

		// Calc thruster
		Vector3 _thrusterForce = Vector3.zero;

		if (Input.GetButton ("Jump")) {
			_thrusterForce = Vector3.up * thrusterForce;
			SetJointSettings (0f);
		} else {
			SetJointSettings (jointSpring);
		}

		// Apply thruster
		motor.ApplyThruster(_thrusterForce);
	}

	private void SetJointSettings(float _jointSpring)
	{
		joint.yDrive = new JointDrive 
		{
			positionSpring = _jointSpring, 
			maximumForce = jointMaxForce 
		};
	}
}