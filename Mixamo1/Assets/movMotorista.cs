using System.Collections;
using System.Collections.Generic;
using System.IO;

using Unity.VisualScripting;
using UnityEngine;

public class movPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController player;

    private Animator animator;
    public float speed = 3.0f;

    public new Transform camera;

    public float gravity=-9.8f;

    void Start()
    {
        player = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        bool isRunning = Input.GetButton("Fire1");
        animator.SetBool("isRunning", isRunning);

        Vector3 movement = Vector3.zero;

        if (hor != 0 || ver !=0 ){
            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = camera.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward*ver + right*hor;
            direction.Normalize();

            movement = direction * speed * Time.deltaTime;

            animator.SetFloat("PosX", hor);
            animator.SetFloat("PosY", ver);
            
        }

        if(Input.GetButtonDown("Jump")){ animator.SetTrigger("Saltar"); }
        if(Input.GetButtonDown("Fire3")){ animator.SetTrigger("Atacar"); }
        if(Input.GetButtonDown("Fire2")){ animator.SetTrigger("Saludar"); }
        if(Input.GetButtonDown("Cancel")){ animator.SetTrigger("Bailar"); }
        if(Input.GetButtonDown("Submit")){ animator.SetTrigger("Aplaudir"); }
        if(Input.GetButtonDown("j")){ animator.SetTrigger("Enfado"); }

        movement.y = gravity*Time.deltaTime;
        player.Move(movement);

    }
}
