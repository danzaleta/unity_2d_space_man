using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0.5f, 0.0f, -10.0f);
    [SerializeField] float dampingTime = 0.3f;
    [SerializeField] Vector3 velocity = Vector3.zero;



    void Awake()
    {
        //Application.targetFrameRate = 60;
    }
    // 
    void Start()
    {
        
    }

    void Update()
    {
        MoveCamera(true);
    }



    // Camera management methods
    //
    public void ResetCameraPosition()
    {
        MoveCamera(false);
    }
    //
    private void MoveCamera(bool smooth)
    {
        Vector3 destination = new Vector3(
            target.position.x - offset.x,
            offset.y,
            offset.z
            );
        if (smooth)
        {
            this.transform.position = Vector3.SmoothDamp(
                this.transform.position,
                destination,
                ref velocity,
                dampingTime
                );
        }
    }
    //
    // Camera management methods
}
