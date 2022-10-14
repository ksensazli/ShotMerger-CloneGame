using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class playerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _slideSpeed;
    [SerializeField] private float _lerpSpeed;
    private Vector3 _forwardMoveAmount;
    private touchInput _touchInput;
    private float _xPos;
    private bool _isStart;
    private bool _isEnd;


    private void OnEnable()
    {
        gameManager.onStart += startGame;
        gameManager.onEnd += endGame;
        _touchInput = GetComponent<touchInput>();
    }

    private void OnDisable()
    {
        gameManager.onStart -= startGame;
        gameManager.onEnd -= endGame;
    }

    private void startGame()
    {
        _isStart = true;
    }

    private void endGame()
    {
        _isEnd = true;
    }

    private void FixedUpdate()
    {
        if (!_isStart)
        {
            return;
        }

        movePlayer();
    }

    private void movePlayer()
    {
        _forwardMoveAmount = Vector3.forward * _forwardSpeed;
        Vector3 targetPosition = _rigidBody.transform.position + _forwardMoveAmount;

        if (Input.GetMouseButton(0))
        {
            targetPosition.x = 0;
            targetPosition.x = _touchInput.DragAmountX * _slideSpeed;
        }

        _xPos = Mathf.Clamp(targetPosition.x, -3.5f, 3.5f);

        Vector3 targetPositionLerp = new Vector3(Mathf.Lerp(_rigidBody.position.x, _xPos, Time.fixedDeltaTime * _lerpSpeed),
        Mathf.Lerp(_rigidBody.position.y, targetPosition.y, Time.fixedDeltaTime * _lerpSpeed),
        Mathf.Lerp(_rigidBody.position.z, targetPosition.z, Time.fixedDeltaTime * _lerpSpeed));

        _rigidBody.MovePosition(targetPositionLerp);
    }

    private void onCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            Vector3 obstacleForce = new Vector3(0,0,-10);
            _rigidBody.AddForce(obstacleForce);
            DOVirtual.DelayedCall(1f, ()=>_rigidBody.velocity = Vector3.zero);
        }
    }
}
