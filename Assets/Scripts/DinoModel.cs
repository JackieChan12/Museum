using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class DataModel
{
    [SerializeField] public int idModel;
    [SerializeField] public Vector3 position;
    [SerializeField] public Quaternion rotatiion;
    [SerializeField] public int indexIdle;
    [SerializeField] public int turn;
    [SerializeField] public bool attack;

    public void SetData(Vector3 pos = new Vector3(), Quaternion ros = new Quaternion(), int index=0, int turnStatus=0, bool attackStatus = false)
    {
        position = pos; rotatiion = ros; indexIdle = index; turn = turnStatus; attack = attackStatus;
    }
    public void SetData(Vector3 pos = new Vector3(), Quaternion ros = new Quaternion())
    {
        position = pos; rotatiion = ros;
    }
    public void SetData(int index = 0, int turnStatus = 0, bool attackStatus = false)
    {
        indexIdle = index; turn = turnStatus; attack = attackStatus;
    }
}

public class DinoModel : MonoBehaviour
{
    [SerializeField] public DataModel dataModel = new DataModel();
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTransformModel(Vector3 pos = new Vector3(), Quaternion ros = new Quaternion())
    {
        transform.position = pos; transform.rotation = ros; 
        dataModel.SetData(transform.position, transform.rotation);
    }

    public void SetAnimationModel(int index = 0, int turnStatus = 0, bool attackStatus = false)
    {
        animator.SetBool("Attack", attackStatus);
        animator.SetInteger("Idle", index);
        animator.SetFloat("Turn", turnStatus);
        dataModel.SetData(index, turnStatus, attackStatus);
    }
}
