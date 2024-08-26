using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.05f;
    [SerializeField] private GameObject _pipe;

    [SerializeField] private float _timeDestroy = 10f;
    private float _timer;
    private void Start()
    {
        if(_timer > _maxTime)
        {
            spawnPipe()
            _timer = 0 
        }    
        
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector spawnPos = transform.position + new Vector3(0, Random.Range( - _heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);
        
        Destroy(pipe, _timeDestroy); 

    }
    

}