using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6;
    public GameObject PlayerPivot;      //�÷��̾� �ٶ󺸴� ������ �˱����ؼ�
    public Camera viewCamera;           //���� ī�޶� �޾ƿ��� Camera ������Ʈ
    public Vector3 velocity;            //�̵� �ӵ� ��
    public ProjectileController projectileController;
    void Start()
    {
        viewCamera = Camera.main;       //��ũ��Ʈ�� ���۵ɶ� ī�޶� �޾ƿ´�.
    }

    void Update()
    {   
        //ȭ�鿡�� -> ���� 3D ���� ��ǥ�� �̾Ƴ���.
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));

        //������ǥ�� ĳ���ͺ��� ���� ������쿡�� ���� ó�ٺ��� ������ ���� y�� ���� �����ش�.
        Vector3 targetPosition = new Vector3(mousePos.x, transform.position.y, mousePos.z);

        //�Ǻ��� �ش� Ÿ���� ���� �Ѵ�.
        PlayerPivot.transform.LookAt(targetPosition, Vector3.up);

        //����Ű�� ���ؼ� �̵� ���Ͱ��� �����Ѵ�.
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            projectileController.FireProjectile();
        }
    }

    private void FixedUpdate()
    {   
        //�̵� ���Ͱ��� Rigidbody �������� �����Ͽ� ĳ���͸� �̵� ��Ų��.
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + velocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}