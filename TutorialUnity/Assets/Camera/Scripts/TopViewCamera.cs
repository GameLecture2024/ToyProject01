using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopViewCamera : MonoBehaviour
{
    Vector3 offset;
    [SerializeField] Transform playerTr;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTr.position;  //  �÷��̾ ī�޶� ���� ����� ũ�� �÷��̾� ���ϸ� => ī�޶� ��ġ
    }

    // PlayerController Update���� �̵� ��Ű��, LateUpdate ī�޶� ������ �ش�.
    void LateUpdate()
    {
        transform.position = playerTr.position + offset;  // ī�޶��� ��ġ = �÷��̾ �̵��� ��ġ + ī�޶�� �÷��̾ �����Ǿ���� ����� �Ÿ�

        offset = transform.position - playerTr.position;  // �÷��̾ �̵��Կ� ���� ��ȭ�� offset�� �ٽ� �������ش�.
    }
}
