using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static CharacterMovement Instance;
    public float wayCenterLocation = 0;
    public bool canRun = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.EndGame += Stop;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (canRun)
        {
            Transform transform1;
            (transform1 = transform).Translate(Vector3.forward * (3f * Time.deltaTime));
            var position = transform1.position;
            transform.position = Vector3.Lerp(position, new Vector3(wayCenterLocation, position.y, position.z),
                Time.deltaTime);
        }
    }

    void Stop()
    {
        canRun = false;
    }
}