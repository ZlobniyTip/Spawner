using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy _enemy;

    private Coroutine _spawn;

    private void Start()
    {
        _spawn = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var delayBeforeSpawn = new WaitForSeconds(6);

        var enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        enemy.SetDirection(_target);
        yield return delayBeforeSpawn;

        RestartCoroutine();
    }

    private void RestartCoroutine()
    {
        StopCoroutine(Spawn());
        _spawn = StartCoroutine(Spawn());
    }
}
