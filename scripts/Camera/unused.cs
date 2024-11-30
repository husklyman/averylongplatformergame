/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera maincam;
    public Collider2D maincamtrigger;

    public BoxCollider2D trigger1;
    public BoxCollider2D trigger2;
    public BoxCollider2D trigger3;

    public Cinemachine.CinemachineVirtualCamera camera1;
    public Cinemachine.CinemachineVirtualCamera camera2;
    public Cinemachine.CinemachineVirtualCamera camera3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.tag == "Player")
        {
            if (collision == maincamtrigger)
            {
                CameraManager.SwitchCamera(maincam);
            }
            if (collision == trigger1)
            {
                CameraManager.SwitchCamera(camera1);
            }
            if (collision == trigger2)
            {
                CameraManager.SwitchCamera(camera2);
            }
            if (collision == trigger3)
            {
                CameraManager.SwitchCamera(camera3);
            }
        }

    }
}
*/