using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    private Transform camTrans;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        camTrans = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        camTrans.position = new Vector3(target.position.x - 0.52f, camTrans.position.y, target.position.z - 6.56f);
       // camTrans.rotation = Quaternion.Euler(new Vector3(14.5f, 0, 0));
        transform.LookAt(target);
    }
}
