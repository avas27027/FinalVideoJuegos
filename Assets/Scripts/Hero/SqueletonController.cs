using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SqueletonController : MonoBehaviour
{
    public GameObject proyectil;
    public Transform mProyectilPoint;
    public float proyectilForce;
    public float tiempoDisparo;
    public bool Arquero;
    public float speed;

    //public float rotationSpeed;
    //public float visionDistance;

    public float hitBox;

    

    public bool trigerCol = false;
    public Transform objColTra;
    private bool derecha = true;
    private bool onCollide = false;
    //public float rotation = 0;
    //public Vector2 hitVect;
    public PlayerActions mPlayerActions;
    public State<SqueletonController> IdleState {get; private set;}
    public State<SqueletonController> GuardState { get; private set;}
    public State<SqueletonController> AttackState { get; private set; }

    public StateMachine<SqueletonController> mSM = new StateMachine<SqueletonController>();
    // Start is called before the first frame update
    private void Awake()
    {
        mPlayerActions = new PlayerActions();
    }

    void Start()
    {
        IdleState = new IdleState(this, mSM);
        GuardState = new GuardState(this, mSM);
        AttackState = new AttackState(this, mSM);
        mSM.Start(GuardState);

    }

    // Update is called once per frame
    void Update()
    {
        mSM.GetCurrentState().OnHandleInput();
        mSM.GetCurrentState().OnLogicUpdate();
    }

    private void FixedUpdate()
    {
        mSM.GetCurrentState().OnPhisicsUpdate();
    }

    public void Disparar()
    {
        
        GameObject obj = Instantiate(proyectil, mProyectilPoint.position, Quaternion.identity);
        //obj.GetComponent<proyectilController>().noCollide = gameObject.name;
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(objColTra.transform.position * proyectilForce, ForceMode2D.Impulse);
        if(transform.position.x - objColTra.position.x > 0 && derecha)
        {
            transform.Rotate(Vector2.up, 180f);
            derecha = false;
        }
        else if (transform.position.x - objColTra.position.x < 0 && !derecha)
        {
            transform.Rotate(Vector2.up, 180f);
            derecha = true;
        }

        //obj.transform.parent = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onCollide = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (mSM.GetCurrentState() == GuardState && !collision.gameObject.CompareTag("Proyectil"))
        {
            objColTra = collision.gameObject.transform;
            trigerCol = true;
        }
    }

    public bool GetTrigerCol()
    {
        return trigerCol;
    }
    public void SetTrigerCol(bool trigerCol)
    {
        this.trigerCol = trigerCol;
    }
    
    public bool GetOnCollide()
    {
        return onCollide;
    }

    public void SetOnCollide(bool onCollide)
    {
        this.onCollide = onCollide;
    }
}
