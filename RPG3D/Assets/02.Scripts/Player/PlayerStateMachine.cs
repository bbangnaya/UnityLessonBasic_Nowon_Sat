using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public KeyCode keyCode;
    public PlayerState playerState;
    public State state;

    // ���� ���� �ӽ��� ���� Ŭ���� ����
    public bool isFinished {
        get => state == State.Finish ? true : false;
    }

    // ��� �ӽſ� ���������� �����ؾ� �Ѵ�.
    // ���������� protected : �ܺ� ��ü ���� X, �ش� Ŭ������ ��ӹ��� �ڽİ�ü�� ���� ����. 
    protected PlayerStateMachineManager manager;
    protected PlayerAnimator playerAnimator;
    protected float delay;
    protected float delayTimer;

    // awake���� �ʱ�ȭ�ؾ� ��. �׷��� �ڽ� ��ü���� awake�� �� �� ���� ���̴�. 
    // �׷��� �ڽ� ��ü�� �������̵��ؼ� ��� �� ���̴�. 

    protected virtual void Awake()
    {
        manager = GetComponent<PlayerStateMachineManager>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }
    // �������̵带 ���� virtual ���̱�
    public virtual bool isExecuteOK()
    {
        return true;
    }

    public virtual void Execute() {
        state = State.Prepare;
    }

    // �Ŵ����� UpdateState�� ������ ������.
    public virtual PlayerState UpdateState()
    {
        PlayerState nextState = playerState;

        // state �ӽ��� ������ �κ� 
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

