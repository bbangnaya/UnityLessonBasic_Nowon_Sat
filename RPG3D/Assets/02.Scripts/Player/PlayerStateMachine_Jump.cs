using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine_Jump : PlayerStateMachine
{
    [SerializeField] private float jumpForce;
    [SerializeField] LayerMask groundLayer;
    private GroundSensor groundSensor;
    private Rigidbody rb;
    private CapsuleCollider col;
    private float jumpDownAnimationTime;
    private bool onJumpDown;

    // PlayerStateMachine를 상속받으므로 그냥 awake가 아니다. 
    protected override void Awake()
    {
        base.Awake();
        groundSensor = GetComponentInChildren<GroundSensor>();
        rb = GetComponent<Rigidbody>();
        delay = 0.1f;
        // jumpDownAnimationTime = playerAnimator.GetClipTime("Jump_Down");
        // animator의 awake보다 여기 awake가 먼저 호출됨
        // 따라서 start에서 호출되어야 함.
    }
    private void Start() {
        jumpDownAnimationTime = playerAnimator.GetClipTime("Jump_Down");
    }


    public override bool isExecuteOK()
    {        
        return groundSensor.isOn;
    }

    public override PlayerState UpdateState() {
        PlayerState nextState = playerState;

        // state 머신을 돌리는 부분 
        switch (state) 
        {
            case State.Idle:
                break;
            case State.Prepare:
                playerAnimator.SetTrigger("DoJump");
                delayTimer = delay;
                state++;
                break;
            case State.OnDelay:
                if (delayTimer < 0) {
                    state++;
                }
                delayTimer -= Time.deltaTime;
                break;
            case State.Casting:
                // 본격 점프 타임. 발이 땅에서 떨어져야 시작
                if (groundSensor.isOn == false)
                    state++;
                break;
            case State.OnAction:
                // 하강중에 지면과의 거리를 재서
                // JumpDown aniamtion 실행 시간에 맞춰서 animation 재생

                if (onJumpDown == false &&
                    Physics.Raycast(rb.position,
                                    Vector3.down,
                                    out RaycastHit hit,
                                    100.0f
                                    )) 
                {
                    Debug.DrawRay(rb.position, Vector3.down * 100.0f, Color.red);
                    float vY = rb.velocity.y;
                    float VSquare = vY * vY;
                    float distance = vY - hit.point.y;
                    float gravity = -9.81f;
                    float remainTime = ( 2 * vY + Mathf.Sqrt(VSquare - 4 * gravity * 2 * distance) )
                                     / ( 2 * gravity );
                    if (remainTime < 0) {
                        remainTime = ( 2 * vY - Mathf.Sqrt(VSquare - 4 * gravity * 2 * distance) )
                                     / ( 2 * gravity );
                    }

                    if (remainTime <= jumpDownAnimationTime) 
                    {
                        playerAnimator.SetTrigger("DoJumpDown");
                        onJumpDown = true;
                    }
                }
                else if(onJumpDown == false)
                {
                    playerAnimator.SetTrigger("DoFalling");
                }

                else
                {
                    Debug.DrawRay(rb.position, Vector3.down * 100.0f, Color.green);
                }

                // downJump 가 끝나면 현재 state machine 완료
                if (onJumpDown &&
                    groundSensor.isOn &&
                    playerAnimator.IsClipPlaying("Jump_Down") == false) 
                {
                    state++;
                }
                break;
            case State.Finish:
                // set nextState to change to the other state
                nextState = PlayerState.Move;
                onJumpDown = false;
                break;
            default:
                break;
        }
        return nextState;
    }

    public override void FixedUpdateState()
    {
        switch (state) {
            case State.Idle:
                break;
            case State.Prepare:
                break;
            case State.OnDelay:
                break;
            case State.Casting:
                if (groundSensor.isOn)
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                break;
            case State.OnAction:
                break;
            case State.Finish:
                break;
            default:
                break;
        }

    }

}
