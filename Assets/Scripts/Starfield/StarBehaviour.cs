using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class StarBehaviour : MonoBehaviour
{
    [SerializeField] Vector2 minMaxScale = new Vector2(0.5f, 1.5f);
    [SerializeField] float speed = 5f;
    [SerializeField] float size = 1f;
    StarfieldManager _starfieldManager;

    private float scaledSpeed = -1;
    private float scaledSize = -1;
    
    private SpriteRenderer spriteRenderer;

    InputAction moveAction;

    public void Initialize(StarfieldManager spawner)
    {
        _starfieldManager = spawner;
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveAction = InputSystem.actions.FindAction("Move");
        ResetStar();
    }
    
    void Update()
    {
        transform.Translate(Vector3.down * (scaledSpeed * Time.deltaTime), Space.World); 
       
        var moveValue = moveAction.ReadValue<Vector2>();
        
        transform.Translate(Vector3.left * (moveValue.x * scaledSpeed * 0.25f * Time.deltaTime), Space.World); 

        if(transform.position.y < _starfieldManager.BottomYPosition)
        {
            ResetStar();
        }
    } 
    
    
    public void ResetStar()
    {
        var randomScale = Random.Range(minMaxScale.x, minMaxScale.y);
        scaledSpeed = randomScale * speed;
        scaledSize = randomScale * size;
        transform.localScale = new Vector3(scaledSize * 0.025f, transform.localScale.y, 0f);
        spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(-0.5f, 1f, randomScale));
        
        transform.position = new Vector3(Random.Range(_starfieldManager.SpawnRangeX.x, _starfieldManager.SpawnRangeX.y), _starfieldManager.transform.position.y, 0f);
    }
}
