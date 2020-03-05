using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParticleGroup : MonoBehaviour
{
    private ParticleSystem[] _Particles;

    private int _Count => _Particles?.Length ?? 0;

    private bool _IsInitialized = false;

    // Start is called before the first frame update
    void Start()
    {
        _Particles = GetComponentsInChildren<ParticleSystem>();

        _IsInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_Count <= 0 && _IsInitialized)
        {
            Destroy(gameObject);
        }

        bool canDestroy = _Particles.All(p => p == null || p.IsAlive(true) == false);

        if (canDestroy)
        {
            Destroy(gameObject);
        }
    }
}
