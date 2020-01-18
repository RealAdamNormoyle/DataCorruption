using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 5;
    public Transform cameraPivot;
    RotationConstraint xRotation;
    public Animator armAnimator;
    // Start is called before the first frame update
    void Start()
    {
        xRotation = cameraPivot.GetComponent<RotationConstraint>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir += transform.forward;
        } else if (Input.GetKey(KeyCode.S))
        {
            dir -= transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir -= transform.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir += transform.right;
        }


        if (dir != Vector3.zero)
        {
            armAnimator.SetBool("Walking", true);
        }
        else
        {
            armAnimator.SetBool("Walking", false);
        }

        transform.position += (dir * movementSpeed) * Time.deltaTime;

        xRotation.weight = Mathf.Clamp(xRotation.weight + Input.GetAxis("Mouse Y") / 5, 0f, 1f);
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 10, 0));


        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }


    }

    void Fire()
    {
        armAnimator.SetTrigger("Shoot");
    }

    void Reload()
    {
        armAnimator.SetTrigger("Reload");

    }
}
