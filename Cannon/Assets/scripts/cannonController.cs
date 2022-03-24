using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonController : MonoBehaviour
{
    public float mass;
    public Rigidbody massRG;
    public int speed;
    public float friction;
    public float speed_povorot;
    float xdegrees, ydegrees;
    Quaternion fromrotation, torotation;
    Camera camera;
    public GameObject cannon_ball;
    Rigidbody cannon_ball_rb;
    public Transform shot_pos;
    public float fire_power;
    void Start()
    {
        camera = Camera.main;
        massRG.mass = mass;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit))//если рэйкаст попал куда то
        {
            if (hit.transform.gameObject.tag == "cannon")//если луч попал в объект с тэгом кэннон
            {
                if(Input.GetMouseButton(0))//если левая кнопка мыши
                {
                    xdegrees -= Input.GetAxis("Mouse Y")*speed*friction;
                    ydegrees += Input.GetAxis("Mouse X") * speed * friction;
                    fromrotation = transform.rotation;
                    torotation = Quaternion.Euler(xdegrees,ydegrees,0);
                    transform.rotation = Quaternion.Lerp(fromrotation, torotation, Time.deltaTime * speed_povorot);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            FireCannon();
        }

    }
    public void FireCannon()//стреляет пушка
    {
        GameObject CannonBallCopy = Instantiate(cannon_ball, shot_pos.position, transform.rotation);
        cannon_ball_rb = CannonBallCopy.GetComponent<Rigidbody>();//добавляяем к компоненту риджит бади силу
        cannon_ball_rb.AddForce(transform.forward * fire_power);
    }

}
