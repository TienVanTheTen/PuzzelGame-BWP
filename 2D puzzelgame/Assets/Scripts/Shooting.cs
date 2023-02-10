using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject shootingPoint;
    [SerializeField] private float throwSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotationSpeedStok;
   
    private float offset;
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        Vector2 shootingPointPlayer = new(shootingPoint.transform.position.x, shootingPoint.transform.position.y);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - shootingPointPlayer;
        GameObject stok = Instantiate(bullet, shootingPointPlayer, Quaternion.identity);
        Rigidbody2D rbStok = stok.GetComponent<Rigidbody2D>();
        
        
        if(transform.localScale.x > 0)
        {
            direction.x = Mathf.Clamp(direction.x, 0, maxSpeed);
           
        }
        else
        {
            direction.x = Mathf.Clamp(direction.x, -maxSpeed, 0);
          
        }
        rbStok.AddTorque(rotationSpeedStok * (direction.x * 10) * -1);


        direction.y = Mathf.Clamp(direction.y, -maxSpeed, maxSpeed);
        rbStok.AddForce(direction * throwSpeed);
    }
}
