using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public KeyCode keyCode;
    public PlayerState playerState;
    public State state;

    // 하위 상태 머신을 위한 클래스 생성
    public bool isFinished {
        get => state == State.Finish ? true : false;
    }

    // 모든 머신에 공통적으로 접근해야 한다.
    // 접근제한자 protected : 외부 객체 접근 X, 해당 클래스를 상속받은 자식객체만 접근 가능. 
    protected PlayerStateMachineManager manager;
    protected PlayerAnimator playerAnimator;
    protected float delay;
    protected float delayTimer;

    // awake에서 초기화해야 함. 그런데 자식 객체에서 awake할 수 도 있을 것이다. 
    // 그러면 자식 객체는 오버라이드해서 써야 할 것이다. 

    protected virtual void Awake()
    {
        manager = GetComponent<PlayerStateMachineManager>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }
    // 오버라이드를 위해 virtual 붙이기
    public virtual bool isExecuteOK()
    {
        return true;
    }

    public virtual void Execute() {
        state = State.Prepare;
    }

    // 매니저가 UpdateState를 돌리게 만들자.
    public virtual PlayerState UpdateState()
    {
        PlayerState nextState = playerState;

        // state 머신을 돌리는 부분 
        switch (state) {
            case State.Idle:
                break;
            case State.Prepare:
                state++;
                break;
            case State.OnDelay:
                state++;
                break;
            case State.Casting:
                state++;
                break;
            case State.OnAction:
                state++;
                break;
            case State.Finish:
                // set nextState to change to the other state
                break;
            default:
                break;
        }
        return nextState;
    }
    public virtual void FixedUpdateState() {

        switch (state)
        {
            case State.Idle:
                break;
            case State.Prepare:
                break;
            case State.OnDelay:
                break;
            case State.Casting:
                break;
            case State.OnAction:
                break;
            case State.Finish:
                break;
            default:
                break;
        }

    }

    public virtual void ForceStop()
    {
        state = State.Idle;
    }

    public enum State {
        Idle,
        Prepare,
        OnDelay,
        Casting,
        OnAction,
        Finish,
    }



}

