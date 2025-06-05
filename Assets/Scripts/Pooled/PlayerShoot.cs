using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] PoolManager poolManager;
    [SerializeField] GameObject projectilePrefab;
    
    InputAction shootAction;
    
    void Start()
    {
        shootAction = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        if (shootAction.IsPressed())
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject newProjectile = poolManager.Spawn();
        newProjectile.transform.position = transform.position;
    }
}
