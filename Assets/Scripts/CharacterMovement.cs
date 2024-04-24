using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;


[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    private bool onGrounded;
    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] private Transform view;
    [SerializeField] private Animator animator;
    [SerializeField] private Rig rig;
    

    
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        if (animator.GetBool("Equipped"))
        {
            rig.weight = 1;
        }
        else
        {
            rig.weight = 0;
        }
    }

    [SerializeField] float rotationSpeed = 1.0f;
    void Update()
    {
        onGrounded = controller.isGrounded;
        if (onGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1);
        // to view space //move = view.rotation * move;
        move = Quaternion.Euler(0, view.rotation.y, 0) * move;
        
        controller.Move(move * Time.deltaTime * playerSpeed);


        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Equipped", !animator.GetBool("Equipped"));
            
            if (animator.GetBool("Equipped"))
            {
                rig.weight = 1;
            }
            else
            {
                rig.weight = 0;
            }
        }
        
        //Animation
        animator.SetFloat("Speed", move.magnitude * playerSpeed);
        animator.SetFloat("VelocityY", velocity.y);
        animator.SetBool("OnGround", onGrounded);

        if (move != Vector3.zero)
        {
            //gameObject.transform.forward = move;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * rotationSpeed);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && onGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * Physics.gravity.y);
        }

        

        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
    [SerializeField] float pushPower = 2.0f;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }
}
