using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private GroundDetector groundDetector;
    public float jumpForce;
    public float moveSpeed = 3f;
    private float moveInputOffset = 0.1f;   // Update함수의 if문
    
    Vector2 move;
    
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

    private float jumpTime = 0.1f;
    private float jumpTimer;

    /*state = PlayerState.Idle;*/
    private void Awake(){
        // 초기화
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        groundDetector = GetComponent<GroundDetector>();
    }

    private void Update(){
        float h = Input.GetAxis("Horizontal");
        /*Debug.Log("h 값  = " + h);   // 오른쪽이 +1, 왼쪽이 -1이다. */
        // 방향전환
        if (h < 0) direction = -1;
        else if (h > 0) direction = 1;

        // 0.1이 입력되기 전까지는 움직이지 않게 역치조건을 만든다.
        if (Mathf.Abs(h) > moveInputOffset){
            move.x = h;
            if (state == PlayerState.Idle)
                /*state = PlayerState.Run;*/
                ChangePlayerState(PlayerState.Run);
        }
        else{
            move.x = 0;
            if (state == PlayerState.Run)
                /*state = PlayerState.Idle;*/
                ChangePlayerState(PlayerState.Idle);
        }

        if (Input.GetKeyDown(KeyCode.Space))        // LeftAlt
        {
            if(groundDetector.isDetected &&
                state!= PlayerState.Jump &&
                state != PlayerState.Fall)
            {
                /*state = PlayerState.Jump;
                jumpState = JumpState.Prepare;*/
                ChangePlayerState(PlayerState.Jump);

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
            default:
                break;
        }
        // 현재상태 바꿈
        state = newState;

        // 현재 상태 하위 머신 준비
        switch (state)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Run:
                break;
            case PlayerState.Jump:
                jumpState = JumpState.Prepare;
                break;
            case PlayerState.Fall:
                fallState = FallState.Prepare;
                break;
            default:
                break;
        }
    }

    private void UpdatePlayerState(){
        switch (state){
            case PlayerState.Idle:
                animator.Play("Idle");
                break;
            case PlayerState.Run:
                animator.Play("Run");
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
                break;
            case IdleState.Casting:
                break;
            case IdleState.OnAction:
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
                break;
            case RunState.Casting:
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
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpTimer = jumpTime;
                jumpState++;                // 다음 상태로 넘어간다.
                break;
            case JumpState.Casting:
                if (!groundDetector.isDetected)
                    jumpState++;
                else if (jumpTimer < 0)
                    ChangePlayerState(PlayerState.Idle);
                
                jumpTimer -= Time.deltaTime;
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



}
public enum RunState{
    Idle,
    Prepare,
    Casting,
    OnAction,
    Finish,
}

public enum IdleState{
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
    Fall
}
public enum JumpState{
    Idle,
    Prepare,
    Casting,
    OnAction,
    Finish,
}
public enum FallState{
    Idle,
    Prepare,
    Casting,
    OnAction,
    Finish,
}