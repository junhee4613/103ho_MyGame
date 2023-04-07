using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public Vector3 launchDirection;         //발사 방향

    private void FixedUpdate()
    {
        float moveamount = 3 * Time.fixedDeltaTime;             //이동속도 설정
        transform.Translate(launchDirection * moveamount);      //Translate로 이동
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Object")           //Tag 값이 오브젝트 인 경우
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Monster")           //Tag 값이 Monster 인 경우
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Monster>().Damaged(1);
        }
    }
}
