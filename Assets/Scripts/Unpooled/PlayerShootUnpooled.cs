using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootUnpooled : MonoBehaviour
{
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
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}
