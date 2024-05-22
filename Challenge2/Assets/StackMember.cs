using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StackMember : MonoBehaviour
{
    public float speed = 5.0f;

    private float _direction;

    private bool isStop = false;

    // Start is called before the first frame update
    void Start()
    {
        _direction = transform.position.x > 0 ? 1 : -1;
        StackController.Instance.StackStopAndCut += Cut;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStop)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.left * _direction * speed * Time.deltaTime);
    }

    private void Cut(Transform oldStack)
    {
        if (CubeCut.Cut(transform, oldStack))
        {
            isStop = true;
            StackController.Instance.StackStopAndCut -= Cut;
            Destroy(this.gameObject);
        }
    }
}