using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*요약:사용하기 위해서는 이 컴포넌트가 들어간 오브젝트의 태그를 player로 지정한다. 현재는 엠프티 안에 prefab가 있지만
 * 차후 수정 예정*/
public class PlayerMove : MonoBehaviour
{
    public GameObject thisObject;
    public float moveSpeed = 100.0f;
    private Rigidbody charRigidbody;
    public bool isAtk = false;


    public Animator playerAnimations;

    // Start is called before the first frame update
    void Start()
    {
        charRigidbody = GetComponent<Rigidbody>();
        thisObject = GameObject.FindWithTag("Player");
        playerAnimations = thisObject.transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving() 
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        playerAnimations.SetFloat("Walk", hAxis);

        if (hAxis > 0) { transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0)); }
        else if (hAxis<0) { transform.rotation = Quaternion.Euler(new Vector3(0,0,0)); }
        
        Debug.Log(hAxis);

        if (hAxis == 0 && vAxis == 0) return;
        Vector3 inputDir = new Vector3(hAxis*moveSpeed, 0, vAxis*moveSpeed);

        charRigidbody.velocity = inputDir;
    }
    void Attack()
    {
        //play an attack animation
        //detect enemies in range of attack
        //damage them

    }
    void AnimationController()
    {
        
    }
}
