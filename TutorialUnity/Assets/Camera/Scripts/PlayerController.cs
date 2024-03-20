using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraSetting
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private CharacterController cCon;

        // Start is called before the first frame update
        void Start()
        {
            cCon = GetComponent<CharacterController>();
        }

        // Update is called once per frame ��ǻ�Ͱ� ���� ���� frame�� ���� �����ǰ� Update�� ���� ȣ�� �˴ϴ�.
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveDir = new Vector3(horizontal, 0, vertical).normalized;

            // ���� ��ġ + �ӵ� * ���ӵ� = �̵� �Ÿ�
            // �̵��Ÿ���ŭ (�� �����Ӹ��� �����Դϴ� * Time.deltaTime)=> �����Ӽ��� ������� ���� �ð��� ���� �Ÿ��� �����Դϴ�.

            cCon.Move(moveDir * moveSpeed * Time.deltaTime); 

        }       
    }

}