﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyuncuKontrol : MonoBehaviour
{
    public Transform mermiPos;
    public GameObject mermi;
    public GameObject patlama;
    public Image canImaji;
    public oyunKontrol oKontrol;
    private float canDegeri = 100f;
    public AudioClip atisSesi, olmeSesi, canAlmaSesi, yaralanmaSesi;
    private AudioSource aSource;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            aSource.PlayOneShot(atisSesi, 1f);
            GameObject go = Instantiate(mermi, mermiPos.position, mermiPos.rotation) as GameObject;
            GameObject goPatlama = Instantiate(patlama, mermiPos.position, mermiPos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 10f;
            Destroy(go.gameObject, 2f);
            Destroy(goPatlama.gameObject, 2f);
        }
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("zombi"))
        {
            aSource.PlayOneShot(yaralanmaSesi, 1f);
            canDegeri -= 10f;
            canImaji.fillAmount = canDegeri / 100f;
            canImaji.color = Color.Lerp(Color.red, Color.green, canDegeri / 100f);

            if(canDegeri <= 0)
            {
                aSource.PlayOneShot(olmeSesi, 1f);
                oKontrol.OyunBitti();
            }
        }


    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag.Equals("kalp"))
        {
            aSource.PlayOneShot(canAlmaSesi, 1f);
            if(canDegeri < 100f)
            canDegeri += 10f;
            canImaji.fillAmount = canDegeri / 100f;
            canImaji.color = Color.Lerp(Color.red, Color.green, canDegeri / 100f);
            Destroy(c.gameObject);
        }
    }
    
}
