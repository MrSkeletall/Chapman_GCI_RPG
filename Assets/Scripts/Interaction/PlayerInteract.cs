using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    
    public float radius = 2.0f;
    public LayerMask layerMask;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckNearbyObjects();
        }
    }

    void CheckNearbyObjects()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D hitCollider in hitColliders)
        {
            CheckInteractable(hitCollider.gameObject);
        }
    }


    private void CheckInteractable(GameObject checkObject)
    {
        InteractableObj intObj;
        if (checkObject.TryGetComponent<InteractableObj>(out intObj))
        {
            
            TriggerInteract(intObj);
        }
        
    }



    void TriggerInteract(InteractableObj intObject)
    {
        //Debug.Log("Interaction on" + intObject);
        intObject.OnUse();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
    
}
