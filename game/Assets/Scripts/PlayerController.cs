using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  public CharacterController controller;
  public Transform cam;
  float turningSpeed = 80;
  float verticalInput;
  float horizontalInput;
  float speed = 5;
  float smoothAngleTime = 0.1f;
  float turnSmoothVelocity;
  // Start is called before the first frame update


  // Update is called once per frame
  void Update()
  {

    horizontalInput = Input.GetAxisRaw("Horizontal");
    verticalInput = Input.GetAxisRaw("Vertical");


    Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

    if (direction.magnitude >= 0.1f)
    {
      float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

      float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothAngleTime);
      transform.rotation = Quaternion.Euler(90f, angle, 0f);

      Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

      controller.Move(moveDir.normalized * speed * Time.deltaTime);
    }

    // transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

    // transform.Rotate(Vector3.forward * Time.deltaTime * turningSpeed * horizontalInput);
  }

}
