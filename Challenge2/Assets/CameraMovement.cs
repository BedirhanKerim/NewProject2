using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;
    public bool canRun = true;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.EndGame += Stop;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canRun)
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(Player.transform.position.x + 1.67f, transform.position.y, Player.position.z - 3),
                Time.deltaTime);
        }
    }

    void Stop()
    {
        canRun = false;
    }
}