using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public Vector3 launchDirection;         //�߻� ����

    private void FixedUpdate()
    {
        float moveamount = 3 * Time.fixedDeltaTime;             //�̵��ӵ� ����
        transform.Translate(launchDirection * moveamount);      //Translate�� �̵�
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Object")           //Tag ���� ������Ʈ �� ���
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Monster")           //Tag ���� Monster �� ���
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Monster>().Damaged(1);
        }
    }
}
