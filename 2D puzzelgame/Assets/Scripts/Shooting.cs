using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float throwSpeed;
    [SerializeField] private float maxSpeed;
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
        Vector2 playerPos = new Vector2(this.gameObject.transform.position.x + 1f, this.gameObject.transform.position.y + 1f);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 angle = mousePosition - playerPos;
        GameObject stok = Instantiate(bullet, playerPos, Quaternion.identity);
        Rigidbody2D rbStok = stok.GetComponent<Rigidbody2D>();

        rbStok.AddForce(angle * throwSpeed);



    }
}
