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
         * normalized : 벡터 값의 크기가 1이 되도록 좌표가 조정된 값
         * fixedDeltaTime : 물리 프레임 하나가 소비한 시간
         **/
        rb.MovePosition(rb.position + nextvec);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputvec.magnitude);
        /**
         * SetFloat 첫번째 인자 : 파라미터 이름
         * SetFloat 두번째 인자 : 반영할 float값
         * magnitude : 벡터의 순수한 크기, 즉 벡터의 길이
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
