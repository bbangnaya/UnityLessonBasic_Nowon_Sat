using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GroundDetector groundDetector;
    public bool invisiable;              // 무적
    public float jumpForce;
    public float moveSpeed = 3f;
    private float moveInputOffset = 0.1f;   // Update함수의 if문
    Vector2 move;
    bool isMoveable = true;

    int _direction;     // +1 : right, -1 : left
    public int direction
    {
        get { return _direction; }
        set {
            if (value < 0)
            {
                _direction = -1;
                transform.eulerAngles = new Vector3(0, 180f, 0);
            }
            else if (value > 0)
            {
                _direction = 1;
                transform.eulerAngles = Vector3.zero;
            }
        }
    }

    public PlayerState state;
    public IdleState idleState;
    public RunState runState;
    public JumpState jumpState;
    public FallState fallState;
    public AttackState attackState;
    public DashAttackState dashAttackState;
    public HurtState hurtState;
    public DieState dieState;

    [Header("애니메이션")]
    private Animator animator;
    private float animationTimer;
    private float attackTime;
    private float dashAttackTime;
    private float jumpCastingTime = 0.1f;
    private float jumpCastingTimer;
    private float hurtTime;
    private float dieTime;

    [Header("Physics")]
    public Vector2 attackBoxCastCenter;
    public Vector2 attackBoxCastSize;
    public float attackKnockbackForce;
    public float attackKnockbackTime;

    public LayerMask enemyLayer;

    /*state = PlayerState.Idle;*/
    private void Awake(){
        // 초기화
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        groundDetector = GetComponent<GroundDetector>();
        // ini
        attackTime = GetAnimationTime("Attack");
        dashAttackTime = GetAnimationTime("DashAttack");
        hurtTime = GetAnimationTime("Hurt");
        dieTime = GetAnimationTime("Die");

    }

    private void Update(){
        float h = Input.GetAxis("Horizontal");
        /*Debug.Log("h 값  = " + h);   // 오른쪽이 +1, 왼쪽이 -1이다. */
        // 방향전환
        if (h < 0) direction = -1;
        else if (h > 0) direction = 1;

        // 0.1이 입력되기 전까지는 움직이지 않게 역치조건을 만든다.
        if (isMoveable)
        {
            if (Mathf.Abs(h) > moveInputOffset)
            {

                move.x = h;
                if (state == PlayerState.Idle)
                    /*state = PlayerState.Run;*/
                    ChangePlayerState(PlayerState.Run);
            }
            else
            {
                move.x = 0;
                if (state == PlayerState.Run)
                    /*state = PlayerState.Idle;*/
                    ChangePlayerState(PlayerState.Idle);
            }
        }
        // 점프
        if (Input.GetKey(KeyCode.Space))        // LeftAlt
        {

            

            if(groundDetector.isDetected &&
                state!= PlayerState.Jump &&
                state != PlayerState.Fall)
            {
                /*state = PlayerState.Jump;
                jumpState = JumpState.Prepare;*/
                ChangePlayerState(PlayerState.Jump);


            }
            // crouchupdate머신 에서 점프하면 아래로 내려가는 알고리즘
            if (Input.GetKey(KeyCode.DownArrow))
            {
                groundDetector.IgnoreDetectedGround();
            }

            /*if (state != PlayerState.Jump && state != PlayerState.Fall) // 무한점프 방지
            {   // 떨어지거나 점프한 상태에선 점프가 불가하다. 
                // = state != 점프상태 and 낙하상태 이면 점프한다. 
                // 이렇게 명제의 대우로 
                rb.velocity = new Vector2(rb.velocity.x, 0); // 속도 초기화
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // 점프력만큼 점프
                state = PlayerState.Jump;
            }*/
        }
        // 공격 키
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (state != PlayerState.Attack &&
                state != PlayerState.DashAttack)
                ChangePlayerState(PlayerState.Attack);
        }

        // 대시공격키
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (state != PlayerState.Attack &&
                state != PlayerState.DashAttack)
                ChangePlayerState(PlayerState.DashAttack);
        }
        UpdatePlayerState(); // 애니메이션과 연결하기 위해 Animater를 추가해준다. 
    }

    private void FixedUpdate(){
        rb.position += new Vector2(move.x * moveSpeed, 0) * Time.fixedDeltaTime;
    }

    // 상태 finish일때 바꿔주는 함수
    public void ChangePlayerState(PlayerState newState) {
        // 변수 소문자
        // 클래스, 함수명은 모두 대문자로 시작. (암묵적 약속, 가독성 높이기)
        if (state == newState) return;  // 현재 상태가 다음 상태와 같다면 그냥 return.
        
        // 이전상태 하위 머신 초기화
        switch (state){
            case PlayerState.Idle:
                idleState = IdleState.Idle;
                break;
            case PlayerState.Run:
                runState = RunState.Idle;
                break;
            case PlayerState.Jump:
                jumpState = JumpState.Idle;
                break;
            case PlayerState.Fall:
                fallState = FallState.Idle;
                break;
            case PlayerState.Attack:
                attackState = AttackState.Idle;
                break;
            case PlayerState.DashAttack:
                dashAttackState = DashAttackState.Idle;
                break;
            default:
                break;
        }
        // 현재상태 바꿈
        state = newState;

        // 현재 상태 하위 머신 준비
        switch (state)
        {
            case PlayerState.Idle:
                idleState = IdleState.Prepare;
                break;
            case PlayerState.Run:
                runState= RunState.Prepare;
                break;
            case PlayerState.Jump:
                jumpState = JumpState.Prepare;
                break;
            case PlayerState.Fall:
                fallState = FallState.Prepare;
                break;
            case PlayerState.Attack:
                attackState = AttackState.Prepare;
                break;
            case PlayerState.DashAttack:
                dashAttackState = DashAttackState.Prepare;
                break;
            case PlayerState.Hurt:
                hurtState = HurtState.Prepare;
                break;
            case PlayerState.Die:
                dieState = DieState.Prepare;
                break;

            default:
                break;
        }

        if (newState != PlayerState.Fall)
            isMoveable = true;
    }


    private void UpdatePlayerState()
    {
        switch (state)
        {
            case PlayerState.Idle:
                UpdateIdleState();
                break;
            case PlayerState.Run:
                UpdateRunState();
                break;
            case PlayerState.Jump:
                UpdateJumpState();
                /*animator.Play("Jump");
                if (rb.velocity.y < 0)  // 떨어지고 있으면 Fall호출
                    state = PlayerState.Fall;*/
                break;
            case PlayerState.Fall:
                animator.Play("Fall");
                if (groundDetector.isDetected)
                    state = PlayerState.Idle;
                break;
            case PlayerState.Attack:
                UpdateAttackState();
                break;
            case PlayerState.Hurt:
                UpdateHurtState();
                break;
            case PlayerState.Die:
                UpdateDieState();
                break;
            default:
                break;
        }
    }
    private void UpdateIdleState()
    {
        switch (idleState)
        {
            case IdleState.Idle:
                break;
            case IdleState.Prepare:
                animator.Play("Idle");
                idleState++;
                break;
            case IdleState.Casting:
                idleState++;
                break;
            case IdleState.OnAction:
                // 아무것도 안함
                break;
            case IdleState.Finish:
                break;
            default:
                break;
        }

    }
    private void UpdateRunState()
    {
        switch (runState)
        {
            case RunState.Idle:
                break;
            case RunState.Prepare:
                animator.Play("Run");
                runState++;
                break;
            case RunState.Casting:
                runState++;
                break;
            case RunState.OnAction:
                break;
            case RunState.Finish:
                break;
            default:
                break;
        }
    }

    private void UpdateJumpState()
    {
        switch (jumpState)
        {
            case JumpState.Idle:
                break;
            case JumpState.Prepare:
                animator.Play("Jump");

                isMoveable = false;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpCastingTimer = jumpCastingTime;
                jumpState++;                // 다음 상태로 넘어간다.
                break;
            case JumpState.Casting:
                if (!groundDetector.isDetected)
                    jumpState++;
                else if (jumpCastingTimer < 0)
                    ChangePlayerState(PlayerState.Idle);
                
                jumpCastingTimer -= Time.deltaTime;
                break;
            case JumpState.OnAction:
                if (rb.velocity.y < 0)
                {
                    jumpState++; 
                    /*state = PlayerState.Fall;
                    jumpState = JumpState.Idle;*/
                }
                break;
            case JumpState.Finish:
                // 상태바꾸기
                ChangePlayerState(PlayerState.Fall);
                break;
            default:
                break;
        }
    }
    private void UpdateFallState()
    {
        switch (fallState)
        {
            case FallState.Idle:
                break;
            case FallState.Prepare:
                animator.Play("Fall");
                fallState++;
                break;
            case FallState.Casting:
                fallState++;
                break;
            case FallState.OnAction:
                // 그라운드 체크
                if (groundDetector.isDetected)
                    fallState++;
                break;
            case FallState.Finish:
                ChangePlayerState(PlayerState.Idle);
                break;
            default:
                break;
        }

    }

    private void UpdateAttackState()
    {

        switch (attackState)
        {
            case AttackState.Idle:
                break;
            case AttackState.Prepare:
                isMoveable = false;
                animator.Play("Attack");
                animationTimer = attackTime;
                attackState++;
                break;
            case AttackState.Casting:
                // 애니메이션을 프레임단위로 보고 공격타이밍을 attackTime으로 표현
                // 해당 코드는 attack 동작중 대략 중간쯤(0.55초)이어서
                // attackTime/2이라 적었다. 
                if (animationTimer < attackTime / 2)
                {
                    Vector2 tmpCenter = new Vector2(attackBoxCastCenter.x * direction,
                                                    attackBoxCastCenter.y)
                                                    + rb.position;

                    RaycastHit2D hit = Physics2D.BoxCast(tmpCenter,
                                                          attackBoxCastSize,
                                                          0,
                                                          Vector2.zero,
                                                          0,
                                                          enemyLayer);
                    if (hit.collider != null)
                    {
                        Debug.Log(hit.collider.gameObject);
                        hit.collider.GetComponent<EnemyController>().Knockback(new Vector2(direction, 0),
                                                                               attackKnockbackForce,
                                                                       attackKnockbackTime);

                    }

                    attackState++;
                }
                else
                    animationTimer -= Time.deltaTime;
                break;
            case AttackState.OnAction:
                if (animationTimer < 0)
                {
                    attackState++;
                }
                else
                    animationTimer -= Time.deltaTime;
                break;
            case AttackState.Finish:
                ChangePlayerState(PlayerState.Idle);
                break;
            default:
                break;
        }
    }

    private void UpdateDashAttackState()
    {
        switch (dashAttackState)
        {
            case DashAttackState.Idle:
                break;
            case DashAttackState.Prepare:
                isMoveable = false;
                animator.Play("DashAttack");
                animationTimer = dashAttackTime;
                dashAttackState++;
                break;
            case DashAttackState.Casting:
                if (animationTimer < dashAttackTime / 2)
                {
                    Vector2 tmpCenter = new Vector2(attackBoxCastCenter.x * direction,
                                                    attackBoxCastCenter.y)
                                                    + rb.position;

                    RaycastHit2D hit = Physics2D.BoxCast(tmpCenter,
                                                          attackBoxCastSize,
                                                          0,
                                                          Vector2.zero,
                                                          0,
                                                          enemyLayer);
                    if (hit.collider != null)
                    {
                        hit.collider.GetComponent<EnemyController>().Knockback(new Vector2(direction, 0),
                                                                               attackKnockbackForce,
                                                                               attackKnockbackTime);
                    }

                    dashAttackState++;
                }
                else
                    animationTimer -= Time.deltaTime;
                break;
            case DashAttackState.OnAction:
                if (animationTimer < 0)
                {
                    dashAttackState++;
                }
                else
                    animationTimer -= Time.deltaTime;
                break;
            case DashAttackState.Finish:
                ChangePlayerState(PlayerState.Idle);
                break;
            default:
                break;
        }
    }

    private void UpdateHurtState()
    {
        switch (hurtState)
        {
            case HurtState.Idle:
                break;
            case HurtState.Prepare:
                animator.Play("Hurt");
                animationTimer = hurtTime;      // 초기화
                hurtState++;
                break;
            case HurtState.Casting:
                animationTimer -= Time.deltaTime;
                hurtState++;
                break;
            case HurtState.OnAction:
                if (animationTimer < 0)
                    hurtState++;
                else
                    animationTimer -= Time.deltaTime;
                break;
            case HurtState.Finish:
                ChangePlayerState(PlayerState.Idle);      // 끝나면 원상복귀
                break;
            default:
                break;
        }


    }

    private void UpdateDieState()
    {
        switch (dieState)
        {
            case DieState.Idle:
                break;
            case DieState.Prepare:
                animator.Play("die");
                animationTimer = dieTime;
                dieState++;
                break;
            case DieState.Casting:
                dieState++;
                break;
            case DieState.OnAction:
                if (animationTimer < 0)
                    dieState++;
                else
                    animationTimer -= Time.deltaTime;
                break;
            case DieState.Finish:
                break;
            default:
                break;
        }
    }


    private float GetAnimationTime(string name)
    {
        float time = 0f;
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == name)
                time = ac.animationClips[i].length;
        }

        return time;
    }

    public void Knockback(Vector2 Vec, float time)
    {   // 플레이어가 공격하는 방향의 반대로 날아가야 하므로 
        // 플레이어의 공격을 호출해서 넉백방향을 넣어야 한다.
        if(invisiable == false && (
           state == PlayerState.Idle || 
           state == PlayerState.Run ||
           state == PlayerState.Jump ||
           state == PlayerState.Fall )) // 넉백 조건
        {
            invisiable = true;
            Invoke("InvisiableOff", 1f);
            rb.velocity = Vector2.zero;
            StartCoroutine(E_Knockback(Vec, time));
        }
    }

    IEnumerator E_Knockback(Vector2 dir, float time)
    {
        float timer = time;
        while (timer > 0)
        {
            rb.AddForce(dir, ForceMode2D.Force);
            timer -= Time.deltaTime;
            yield return null;  // 프레임 대기
        }
    }


    IEnumerator E_InvisibleOff()
    {
        yield return new WaitForSeconds(1f);
        invisiable = false;
    }

    void InvisiableOff()
    {
        invisiable = false;
    }


    private void OnDrawGizmos()
    {
        rb = GetComponent<Rigidbody2D>();
        Gizmos.color = Color.red;
        Vector2 tmpCenter = new Vector2(attackBoxCastCenter.x * direction, 
                                        attackBoxCastCenter.y) + rb.position;
        Gizmos.DrawWireCube(tmpCenter, attackBoxCastSize);

    }

    public enum RunState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }

    public enum IdleState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }
    public enum PlayerState
    {
        Idle,
        Run,
        Jump,
        Fall,
        Attack,
        DashAttack,
        Hurt,
        Die
    }

    public enum HurtState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }

    public enum DieState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }
    public enum JumpState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }
    public enum FallState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }

    public enum AttackState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }
    public enum DashAttackState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }

}
