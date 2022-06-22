using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  public CharacterController controller;
  public Transform cam;
  float verticalInput;
  float horizontalInput;
  float speed = 25;
  float smoothAngleTime = 0.1f;
  float turnSmoothVelocity;
  float targetAngle;


  // Start is called before the first frame update


  // Update is called once per frame
  void Update()
  {

    horizontalInput = Input.GetAxisRaw("Horizontal");
    verticalInput = Input.GetAxisRaw("Vertical");


    Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

    //Debug.Log(direction);


    if (direction.magnitude >= 0.1f)
    {

      targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

      float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothAngleTime);

      transform.rotation = Quaternion.Euler(0f, angle, 0f);

      Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

      controller.Move(moveDir * speed * Time.deltaTime);
    }


  }

}
