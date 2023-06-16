using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 설정

    private Vector2 moveDirection; // 현재 이동 방향

    private void Update()
    {
        // WS 키 입력 감지
        float moveVertical = Input.GetAxis("Vertical");

        if (moveVertical > 0)
        {
            moveDirection = new Vector2(1, 1).normalized; // W를 누르면 오른쪽 위 대각선으로 이동
        }
        else if (moveVertical < 0)
        {
            moveDirection = new Vector2(1, -1).normalized; // S를 누르면 오른쪽 아래 대각선으로 이동
        }
        else if (moveVertical == 0)
        {
            moveDirection = new Vector2(1, -0).normalized; // S를 누르면 오른쪽 아래 대각선으로 이동
        }



        // 이동 방향과 속도를 결합하여 이동 벡터 계산
        Vector2 moveVector = moveDirection * moveSpeed * Time.deltaTime;

        // 이동 벡터를 현재 위치에 적용
        transform.Translate(moveVector);
    }
}