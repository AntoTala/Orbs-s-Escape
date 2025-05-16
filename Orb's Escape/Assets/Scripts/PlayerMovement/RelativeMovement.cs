using UnityEngine;
using System.Collections;
[RequireComponent(typeof (CharacterController ))] 
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    private ControllerColliderHit _contact;
    public float pushForce = 6.0f;
    public float rotSpeed = 15.0f;
    public float moveSpeed = 6.0f;
    public float jumpSpeed= 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;
    private float vertSpeed;

    private CharacterController _charController;
    void Start()
    {
        vertSpeed = minFall;
        _charController=GetComponent<CharacterController>(); 
    }
    void Update()
    {
        bool hitGround = false;
        RaycastHit hit;

        // Controllo se sto cadendo e c'è qualcosa sotto
        if (vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check = (_charController.height + _charController.radius) / 1.9f;
            hitGround = hit.distance <= check;
        }

        Vector3 movement = Vector3.zero;

        // Input movimento orizzontale
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        if (horInput != 0 || vertInput != 0)
        {
            movement.x = horInput * moveSpeed;
            movement.z = vertInput * moveSpeed;
            movement = Vector3.ClampMagnitude(movement, moveSpeed);

           
            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;

            transform.rotation = Quaternion.LookRotation(movement);
        }

        if (hitGround)
        {
            
            if (Input.GetButtonDown("Jump"))
            {
                vertSpeed = jumpSpeed;
            }
            else
            {
                vertSpeed = minFall;
            }
        }
        else
        {
            
            if (_charController.isGrounded)
            {
                if (Vector3.Dot(movement, _contact.normal) < 0)
                {
                    
                    movement = _contact.normal * moveSpeed;
                }
                else
                {
                   
                    movement += _contact.normal * moveSpeed;
                }

                vertSpeed = minFall;
            }
            else
            {
             
                vertSpeed += gravity * 5 * Time.deltaTime;

                if (vertSpeed < terminalVelocity)
                {
                    vertSpeed = terminalVelocity;
                }
            }
        }

       
        movement.y = vertSpeed;

       
        movement *= Time.deltaTime;
        _charController.Move(movement);
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && !body.isKinematic)
        {
            body.linearVelocity = hit.moveDirection * pushForce;
        }
    }
}
