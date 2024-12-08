using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheelCollider, frontRightWheelCollider, rearLeftWheelCollider, rearRightWheelCollider;
    //public Transform frontLeftWheelMesh, frontRightWheelMesh, rearLeftWheelMesh, rearRightWheelMesh;

    private float maxMotorForce = 12000f, brakeForce = 800f, maxSteerAngle = 30f;
    private float accelerationRate = 10f, idleDeceleration = 20f; 
    private float currentMotorForce = 0f, currentSpeed = 0f, currentSteerAngle, currentBrakeForce;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(-2f, 0.0f, 2f);

        Cursor.lockState = CursorLockMode.Locked;  // Verrouille la souris au centre de l'écran
        Cursor.visible = false;                    // Rends la souris invisible
    }

    void FixedUpdate()
    {
        HandleInput();
        //UpdateWheels();
    }

    private void HandleInput()
    {
        float verticalInput = Input.GetAxis("Vertical"); 
        float horizontalInput = Input.GetAxis("Horizontal"); 
        bool isBraking = Input.GetKey(KeyCode.Space); 

        currentSteerAngle = horizontalInput * maxSteerAngle; 
        currentBrakeForce = isBraking ? brakeForce : 0f;

        ApplySpeed(verticalInput); 
        ApplySteering();                   


    }

    private void ApplySpeed(float verticalInput)
    {


        if (verticalInput != 0)
        {

            float terrainAngle = GetTerrainAngle();
            float terrainFactor = Mathf.Lerp(1f, 8f, terrainAngle / 45f);

            currentMotorForce += 100 * terrainFactor;

            currentMotorForce = Mathf.Clamp(currentMotorForce, 0f, maxMotorForce);

            rearLeftWheelCollider.motorTorque = verticalInput * currentMotorForce;
            rearRightWheelCollider.motorTorque = verticalInput * currentMotorForce;

            float factor = 1f;
            if (verticalInput < 0)
            {
                factor *= 8f;
            }
            rb.velocity += transform.forward * 0.1f * verticalInput * factor;

            if (verticalInput < 0) 
            {
                if (rb.velocity.magnitude > 0.1f && rb.velocity.z > 0)
                {
                    //Debug.Log("Ralentissement");
                    currentMotorForce = 0.0f;

                    rearLeftWheelCollider.motorTorque = 0;
                    rearRightWheelCollider.motorTorque = 0;

                    float currentSpeed = rb.velocity.magnitude;
                    if (currentSpeed > 0.1f)
                    {
                        float targetTimeToStop = Mathf.Lerp(0.1f, 0.2f, currentSpeed / 30f);
                        float deceleration = currentSpeed / targetTimeToStop;

                        rb.velocity = Vector3.MoveTowards(rb.velocity, Vector3.zero, deceleration * Time.fixedDeltaTime);
                    }
                    else
                    {
                        rb.velocity = Vector3.zero;
                    }
                }
                else
                {
                    rearLeftWheelCollider.motorTorque = verticalInput * currentMotorForce;
                    rearRightWheelCollider.motorTorque = verticalInput * currentMotorForce;
                }
            }
        }
        else
        {
            currentMotorForce = 0.0f;


            rearLeftWheelCollider.motorTorque = 0;
            rearRightWheelCollider.motorTorque = 0;


            float currentSpeed = rb.velocity.magnitude;

            if (currentSpeed > 0.1f)
            {
                float targetTimeToStop = Mathf.Lerp(0.1f, 3f, currentSpeed / 30f); 

                float deceleration = currentSpeed / targetTimeToStop;

                rb.velocity = Vector3.MoveTowards(rb.velocity, Vector3.zero, deceleration * Time.fixedDeltaTime);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }

        }
    }

    private void ApplySteering()
    {
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        //UpdateWheelPosition(frontLeftWheelCollider, frontLeftWheelMesh);
        //UpdateWheelPosition(frontRightWheelCollider, frontRightWheelMesh);
        //UpdateWheelPosition(rearLeftWheelCollider, rearLeftWheelMesh);
        //UpdateWheelPosition(rearRightWheelCollider, rearRightWheelMesh);
    }

    private void UpdateWheelPosition(WheelCollider collider, Transform wheelMesh)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);
        wheelMesh.position = position;
        wheelMesh.rotation = rotation;
    }

    private float GetTerrainAngle()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            //Debug.Log(Vector3.Angle(hit.normal, Vector3.up));
            return Vector3.Angle(hit.normal, Vector3.up);  // Calculate the terrain angle
        }
        return 0f;
    }
}
