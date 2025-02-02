using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineTouch : MonoBehaviour
{
    public CinemachineFreeLook cineCam;
    public TouchField touchField;
    public float sensX = .5f;
    public float sensY = .5f;

    // Update is called once per frame
    void Update()
    {
        cineCam.m_XAxis.Value += touchField.touchDist.x * 200 * sensX * Time.deltaTime;
        cineCam.m_YAxis.Value -= touchField.touchDist.y * sensY * Time.deltaTime;
    }
}
