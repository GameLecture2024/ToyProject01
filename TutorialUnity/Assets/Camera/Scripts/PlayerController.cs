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
        [SerializeField] ThirdCamController thirdCam;        // 3��Ī ī�޶� ��Ʈ�ѷ��� �ִ� ���� ������Ʈ�� ���������� �Ѵ�.

        [SerializeField] float smoothRotation = 5f;               // ī�޶��� �ڿ������� ȸ���� ���� ����ġ
        Quaternion targetRotation;                           // Ű���� �Է��� ���� �ʾ��� �� ī�޶� �������� ȸ���ϱ� ���Ͽ� ȸ�� ������ �����ϴ� ����

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
            float moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical)); // Ű����� �����¿� Ű �Ѱ��� �Է��� �ϸ� 0���� ū ���� moveAmount�� �����Ѵ�.
                                                                                           // ���� ��ġ + �ӵ� * ���ӵ� = �̵� �Ÿ�
                                                                                           // �̵��Ÿ���ŭ (�� �����Ӹ��� �����Դϴ� * Time.deltaTime)=> �����Ӽ��� ������� ���� �ð��� ���� �Ÿ��� �����Դϴ�.

            Vector3 moveMent = thirdCam.camLookRotation * moveDir; // moveDir 0�� �� moveMent�� 0�� �ȴ�.

            if (moveAmount > 0)
            {
               targetRotation = Quaternion.LookRotation(moveMent);
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, smoothRotation * Time.deltaTime);
          

            cCon.Move(moveMent * moveSpeed * Time.deltaTime); 
        }       
    }

}