using UnityEngine;

public class PooledObjectUnpooled : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileLifeTime = 2f;
    
    int currentAnimationFrame = 0;
    float timeAlive = 0f;
    

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
        Destroy(gameObject);
    }
}
