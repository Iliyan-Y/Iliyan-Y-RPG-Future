using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public GameObject player;
  private Vector3 offset = new Vector3(0, 5, -10);
  // Start is called before the first frame update


  // Update is called once per frame
  void LateUpdate()
  {
    float horizontalInput = Input.GetAxis("Horizontal");
    transform.position = player.transform.position + offset;
    transform.Rotate(new Vector3(0, Time.deltaTime * 80 * horizontalInput, 0));
  }
}
