using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    public int vel=3;

    Slider dashBar;
    private void Start()
    {
        dashBar = GameObject.Find("dashIndicator").GetComponent<Slider>();

    }

    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0)*vel*Time.deltaTime;
        if (dashBar.value < 1)
        {
            dashBar.value += Time.deltaTime / 2;
        }

        if (dashBar.value==1 && Input.GetAxis("Jump") != 0)
        {
            dashBar.value =0;
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        vel = 8;
        yield return new WaitForSeconds(0.25f);
        vel = 3;
    }

    public void onDashBarChanged(Single perc)
    {
        Image barColor = GameObject.Find("dashIndicator").transform.Find("Fill Area").Find("Fill").gameObject.GetComponent<Image>();
        if (perc !=1)
        {
            barColor.color = new Color(70f/255,86f/255,123f/255);
        }
        else
        {
            barColor.color = Color.green;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Text hp = GameObject.Find("hpValue").GetComponent<Text>();
        Text scoreVal = GameObject.Find("scoreValue").GetComponent<Text>();
        if (collision.collider.tag == "enemy")
        {
            transform.position=new Vector3(0,0,0);
            hp.text = Convert.ToString(Convert.ToInt32(hp.text)-1);
            scoreVal.text = "0";
        }
    }
}
