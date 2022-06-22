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
  float smoothAngleTime = 1.8f;
  float turnSmoothVelocity;
  float turnSmoothVelocityVertical;
  float targetAngle;




  // Start is called before the first frame update


  // Update is called once per frame
  void Update()
  {

    horizontalInput = Input.GetAxisRaw("Horizontal");
    verticalInput = Input.GetAxisRaw("Vertical");


    transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
    transform.Rotate(Vector3.up * Time.deltaTime * speed * horizontalInput);



    if (Input.GetMouseButton(1))
    {
      Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
      if (direction.magnitude >= 0.1f)
      {

        targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

        float horizontalAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothAngleTime);

        float verticalAngle = Mathf.SmoothDampAngle(transform.eulerAngles.x, cam.eulerAngles.x, ref turnSmoothVelocityVertical, smoothAngleTime);


        transform.rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        controller.Move(moveDir * speed * Time.deltaTime);
      }
    }


  }

}
