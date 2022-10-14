using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera firstVirtualCam;
    [SerializeField] private CinemachineVirtualCamera secondVirtualCam;

    private void OnEnable()
    {
        gameManager.onStart += startTheGame;
    }
    private void OnDisable()
    {
        gameManager.onEnd -= startTheGame;
    }

    private void startTheGame()
    {
        firstVirtualCam.enabled = false;
        secondVirtualCam.enabled = true;
    }
}
