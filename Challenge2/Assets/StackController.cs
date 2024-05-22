using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    public static StackController Instance;
    public GameObject stackPrefab;
    private Vector3 _spawnPosition = Vector3.zero;
    public Transform parentStackObj, lastSpawnedStack;
    private float _spawnCount = 0;
    private bool _leftOrRightSpawn = false;
    private float _leftOrRightSpawnDistance = 10f;
    public event Action <Transform> StackStopAndCut;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnStack(3);
        // InvokeRepeating(nameof(SpawnStack), 1f, 1f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopLastStack();
        }
    }

    private void StopLastStack()
    {
        StackStopAndCut?.Invoke(lastSpawnedStack);
    }


    public void SpawnStack(float lastStackScaleX)
    {
        if (_leftOrRightSpawn)
        {
            _leftOrRightSpawnDistance *= 1;
        }
        else
        {
            _leftOrRightSpawnDistance *= -1;
        }

        _leftOrRightSpawn = _leftOrRightSpawn!;

        _spawnCount++;
        _spawnPosition = new Vector3(_leftOrRightSpawnDistance, 0, _spawnCount * 3);
      var spawnedStack=   Instantiate(stackPrefab, _spawnPosition, stackPrefab.transform.rotation, parentStackObj);
      spawnedStack.transform.localScale = new Vector3(lastStackScaleX, 1, 3);
    }
}