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
    private float moveInputOffset = 0.1f;   // Update�Լ��� if��
    
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
        // �ʱ�ȭ
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        groundDetector = GetComponent<GroundDetector>();
    }

    private void Update(){
        float h = Input.GetAxis("Horizontal");
        /*Debug.Log("h ��  = " + h);   // �������� +1, ������ -1�̴�. */
        // ������ȯ
        if (h < 0) direction = -1;
        else if (h > 0) direction = 1;

        // 0.1�� �ԷµǱ� �������� �������� �ʰ� ��ġ������ �����.
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

            /*if (state != PlayerState.Jump && state != PlayerState.Fall) // �������� ����
            {   // �������ų� ������ ���¿��� ������ �Ұ��ϴ�. 
                // = state != �������� and ���ϻ��� �̸� �����Ѵ�. 
                // �̷��� ������ ���� 
                rb.velocity = new Vector2(rb.velocity.x, 0); // �ӵ� �ʱ�ȭ
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // �����¸�ŭ ����
                state = PlayerState.Jump;
            }*/
        }

        UpdatePlayerState(); // �ִϸ��̼ǰ� �����ϱ� ���� Animater�� �߰����ش�. 
    }

    private void FixedUpdate(){
        rb.position += new Vector2(move.x * moveSpeed, 0) * Time.fixedDeltaTime;
    }

    // ���� finish�϶� �ٲ��ִ� �Լ�
    public void ChangePlayerState(PlayerState newState) {
        // ���� �ҹ���
        // Ŭ����, �Լ����� ��� �빮�ڷ� ����. (�Ϲ��� ���, ������ ���̱�)
        if (state == newState) return;  // ���� ���°� ���� ���¿� ���ٸ� �׳� return.
        
        // �������� ���� �ӽ� �ʱ�ȭ
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
        // ������� �ٲ�
        state = newState;

        // ���� ���� ���� �ӽ� �غ�
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
                if (rb.velocity.y < 0)  // �������� ������ Fallȣ��
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
                jumpState++;                // ���� ���·� �Ѿ��.
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
                // ���¹ٲٱ�
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
                // �׶��� üũ
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