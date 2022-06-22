using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraController : MonoBehaviour
{

  public GameObject ThirdPersonCamera;
  void Start()
  {
    CinemachineCore.GetInputAxis = GetAxisCustom;
  }


  void Update()
  {
    CameraZoom();
  }

  public float GetAxisCustom(string axisName)
  {
    if (axisName == "Mouse X")
    {


      if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
      {
        return UnityEngine.Input.GetAxis("Mouse X");
      }
      else
      {
        return 0;
      }
    }
    else if (axisName == "Mouse Y")
    {
      if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
      {
        return UnityEngine.Input.GetAxis("Mouse Y");
      }
      else
      {
        return 0;
      }
    }
    return UnityEngine.Input.GetAxis(axisName);
  }


  void CameraZoom()
  {
    CinemachineFreeLook VCamControl = ThirdPersonCamera.GetComponent<CinemachineFreeLook>();

    if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
    {
      //wheel goes up
      if (VCamControl.m_Orbits[1].m_Radius <= 80) return;

      VCamControl.m_Orbits[0].m_Radius -= 3;
      VCamControl.m_Orbits[1].m_Radius -= 3;
      VCamControl.m_Orbits[2].m_Radius -= 3;
    }
    else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
    {
      if (VCamControl.m_Orbits[1].m_Radius >= 280) return;
      //wheel goes down
      VCamControl.m_Orbits[0].m_Radius += 3;
      VCamControl.m_Orbits[1].m_Radius += 3;
      VCamControl.m_Orbits[2].m_Radius += 3;
    }

  }
}
