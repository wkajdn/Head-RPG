using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ����

    private Vector2 moveDirection; // ���� �̵� ����

    private void Update()
    {
        // WS Ű �Է� ����
        float moveVertical = Input.GetAxis("Vertical");

        if (moveVertical > 0)
        {
            moveDirection = new Vector2(1, 1).normalized; // W�� ������ ������ �� �밢������ �̵�
        }
        else if (moveVertical < 0)
        {
            moveDirection = new Vector2(1, -1).normalized; // S�� ������ ������ �Ʒ� �밢������ �̵�
        }
        else if (moveVertical == 0)
        {
            moveDirection = new Vector2(1, -0).normalized; // S�� ������ ������ �Ʒ� �밢������ �̵�
        }



        // �̵� ����� �ӵ��� �����Ͽ� �̵� ���� ���
        Vector2 moveVector = moveDirection * moveSpeed * Time.deltaTime;

        // �̵� ���͸� ���� ��ġ�� ����
        transform.Translate(moveVector);
    }
}