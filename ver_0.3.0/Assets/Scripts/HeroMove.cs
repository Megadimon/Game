using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroMove : MonoBehaviour
{

    public float _moveSpeed;
    public int HP;
    bool HetDamage = true;
    GameObject prew = null;
    public GameObject Connon;
    public float power = 2;
    public Slider HPbar;
    public GameObject GameOverPanel;
    public Slider Fuel;
    bool isOver = false;

    public void Move()
    {
        if (power >= 0)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            if (moveHorizontal * _moveSpeed > 0)
                power = power - moveHorizontal * _moveSpeed;
            else
                power = power + moveHorizontal * _moveSpeed;
            Fuel.value = power;
            var movement = new Vector3(moveHorizontal * _moveSpeed + this.transform.position.x, this.transform.position.y, 0);
            this.transform.position = movement;
        }
    }

    public void Ratation()
    {
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            Connon.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
        //float AngleRotate = Input.GetAxis("Mouse X");
        //Tower.transform.Rotate(0, 0, AngleRotate);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Explo")
        {
            if (prew == null)
                HetDamage = true;
            prew = collision.gameObject;

            if (HetDamage)
            {
                HP = HP - 20;
                HPbar.value = 100 - HP;
                Destroy(collision.gameObject);
                HetDamage = false;
                if (HP <= 0)
                {
                    
                    //GetComponent<ControllerPlayr>().Destr(this.);
                    //GetComponent<ControllerPlayr>().Players.Remove(this.gameObject);
                    Destroy(this.gameObject);
                    if (!isOver)
                    {
                        isOver = true;
                        GameOverPanel.SetActive(true);
                    }

                }
            }
        }
    }
}