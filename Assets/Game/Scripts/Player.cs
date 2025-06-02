using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private int vida;
    [HideInInspector]public int dano;
    // Start is called before the first frame update 
    void Start()
    {
        Debug.Log("Ola mundo :)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        
    }
}
