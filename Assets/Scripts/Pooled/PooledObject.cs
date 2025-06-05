using System;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileLifeTime = 2f;
    
    private PoolManager poolManager;
    
    int currentAnimationFrame = 0;
    float timeAlive = 0f;
    
    public void Initialize(PoolManager spawner)
    {
        poolManager = spawner;
    }

    void Update()
    {
        timeAlive += Time.deltaTime;
        currentAnimationFrame++;
        
        if(timeAlive > projectileLifeTime)
        {
            DestroyProjectile();
        }
        
        transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime, Space.World); 
    }
    
    private void DestroyProjectile()
    {
        transform.position = poolManager.transform.position;
        
        // Despawn the projectile using the SpawnManager
       poolManager.Despawn(gameObject);
    }

    public void ResetPooledObject()
    {
        currentAnimationFrame = 0;
        timeAlive = 0f;
    }
}
