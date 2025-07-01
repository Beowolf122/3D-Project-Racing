using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Player;
    public Rigidbody RB;
    public float acceleration=6f;
    public float strafeAccel = 12f;
    public float brakeSpeed = 4f;
    public float maxspeed = 20f;
    public float rotationSpeed=.25f;

    float desiredX;

    [Header("velocities")]
    public Vector3 playerInputForce;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
        RB.maxLinearVelocity = maxspeed;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Steering left/right. Might change into rotation of object+transform forward..?"
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, rotationSpeed, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -rotationSpeed, 0));
        }

        //applies force in local space (transforms the locals "force" (direction) before applying in world space
        Vector3 targetDir = transform.forward.normalized;
        
        if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        {
            //RB.AddForce(2*targetDir * acceleration);
            //add torque..?
            //RB.AddRelativeForce(strafeAccel,0,-2); //latter number slows forward movement.
            Debug.DrawRay(transform.position, RB.linearVelocity * acceleration, Color.green);
        }
        else if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D)) {
            //RB.AddForce(2 * targetDir * acceleration);
            //add torque..?
            //RB.AddRelativeForce(-strafeAccel, 0, -2);
            Debug.DrawRay(transform.position, RB.linearVelocity * acceleration, Color.green);
        }
        //Breaks for the car
        else if (Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.DownArrow))
        {
            //RB.linearVelocity -= targetDir;
            RB.linearDamping = brakeSpeed;
            //RB.angularDamping = 10;
        }
 //car should continually accelerate
            Debug.DrawRay(transform.position, targetDir * acceleration, Color.magenta);
            Debug.DrawRay(transform.position, transform.forward * acceleration, Color.black);
            Debug.DrawRay(transform.position, Vector3.up, Color.green);
            Debug.DrawRay(transform.position, Vector3.right, Color.red);
            RB.AddForce(targetDir * acceleration);
            RB.linearDamping = 0; 



        // a way to check the directions+ other stuff
        //Debug.DrawRay(transform.position + Vector3.up, targetDir, Color.black);
        //Debug.DrawRay(transform.position, -transform.right, Color.magenta);

        

    }
}
