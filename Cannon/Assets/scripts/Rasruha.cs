
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]//автомат риджит 
public class Rasruha : MonoBehaviour
{
    public float HP_WALLS_ONE,HP_WALLS_TWO,CASTLE_HP;
    public Rigidbody walls1, walls2, castle,yadroRG;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cbtag")
        {
            if (transform.GetComponent<Collider>().tag=="w1")
            {
                HP_WALLS_ONE -= yadroRG.mass;
                if (HP_WALLS_ONE <= 0)
                {

                    HP_WALLS_ONE = 0;
                    walls1.isKinematic = false;
                }
                
            }
            if (transform.GetComponent<Collider>().tag == "w2")
            {
                HP_WALLS_TWO -= yadroRG.mass;
                if (HP_WALLS_TWO <= 0)
                {
                    HP_WALLS_TWO = 0;
                    walls2.isKinematic = false;
                }

            }
            if (transform.GetComponent<Collider>().tag == "castlet")
            {
                CASTLE_HP -= yadroRG.mass;
                if (CASTLE_HP <= 0)
                {
                    CASTLE_HP = 0;
                    castle.isKinematic = false;
                }

            }
        }

    }

}
