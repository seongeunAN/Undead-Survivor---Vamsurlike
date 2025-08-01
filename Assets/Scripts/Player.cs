using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public Vector2 inputvec;
    public float speed;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 nextvec = inputvec.normalized * speed * Time.fixedDeltaTime;
        /**
         * normalized : ���� ���� ũ�Ⱑ 1�� �ǵ��� ��ǥ�� ������ ��
         * fixedDeltaTime : ���� ������ �ϳ��� �Һ��� �ð�
         **/
        rb.MovePosition(rb.position + nextvec);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputvec.magnitude);
        /**
         * SetFloat ù��° ���� : �Ķ���� �̸�
         * SetFloat �ι�° ���� : �ݿ��� float��
         * magnitude : ������ ������ ũ��, �� ������ ����
         **/

        if (inputvec.x != 0)
        {
            sprite.flipX = inputvec.x < 0;
        }
    }

    void OnMove(InputValue value)
    {
        inputvec = value.Get<Vector2>();
    }

}
