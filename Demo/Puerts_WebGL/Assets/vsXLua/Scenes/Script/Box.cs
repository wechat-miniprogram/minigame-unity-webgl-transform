using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private static readonly float boxSpeed = 0.2f;
    private static readonly float destroyRange = 0.5f;
    private static readonly float boxRange = 24f;

    public static int TotalBoxCount = 0;
    
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        TotalBoxCount++;
        
        var randomX = Random.Range(-boxRange / 2, boxRange / 2) + target.position.x;
        var randomZ = Random.Range(-boxRange / 2, boxRange / 2) + target.position.z;
        transform.position = new Vector3(
            randomX,
            0.2f,
            randomZ
        );
        Vector3 delta = target.transform.position - transform.position;
        transform.position = transform.position - delta.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = target.transform.position - transform.position;
        if (delta.magnitude < destroyRange)
        {
            Destroy(gameObject);
            TotalBoxCount--;
            return;
        } 
 
        transform.position += delta.normalized * (Time.deltaTime * boxSpeed);
        transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
    }
}
