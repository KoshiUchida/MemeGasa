using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaTest : MonoBehaviour
{
    //int
    int umbrellaHp;

    GameObject damage;

    // Start is called before the first frame update
    void Start()
    {
        //P‚Ì‘Ï‹v‚ğİ’è
        umbrellaHp = 30;

        damage = GameObject.Find("Umbrella");
    }

    // Update is called once per frame
    void Update()
    {
        umbrellaHp = damage.GetComponent<Damage>().GetHealth();

        //–hŒä
        //Guard();

        //P‚Ì‘Ï‹v
        Durability();

    }

    void Guard()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.tag = "Guard";
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.tag = "Umbrella";
        }
    }

    //P‚Ì‘Ï‹v
    void Durability()
    {

        switch (umbrellaHp)
        {
            case 30:
                //–hŒä
                Guard();
                break;

            case 20:
                //–hŒä
                Guard();
                break;

            case 10:
                //–hŒä
                Guard();
                break;

            case 0:
                Debug.Log("P‚Ì‘Ï‹v‚ª–³‚­‚È‚Á‚½");
                break;

            default:
                break;
        }
    }
}
