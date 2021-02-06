using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxHp;
    public float speed;
    public float firingSpeed;
    public float safeTime;

    private float hp;
    private float currentFireCD;
    private float curentSafeTime;

    public GameObject projectile;
    public Slider[] sliders;

    public int deathCount;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            deathCount++;
            switch(deathCount)
            {
                case 1:
                    sliders[1].gameObject.SetActive(true);
                    break;
                case 2:
                    sliders[2].gameObject.SetActive(true);
                    sliders[3].gameObject.SetActive(true);
                    break;
                case 3:
                    sliders[4].gameObject.SetActive(true);
                    sliders[5].gameObject.SetActive(true);
                    sliders[6].gameObject.SetActive(true);
                    sliders[7].gameObject.SetActive(true);
                    break;
                case 4:
                    sliders[8].gameObject.SetActive(true);
                    sliders[9].gameObject.SetActive(true);
                    sliders[10].gameObject.SetActive(true);
                    sliders[11].gameObject.SetActive(true);
                    sliders[12].gameObject.SetActive(true);
                    sliders[13].gameObject.SetActive(true);
                    sliders[14].gameObject.SetActive(true);
                    sliders[15].gameObject.SetActive(true);
                    break;
            }
            
            foreach(Slider i in sliders)
            {
                i.value = 1;
            }

            hp = maxHp;
        }

        if(Input.GetAxis("Horizontal") > 0.1f)
        {
            this.transform.position = this.transform.position + this.transform.right * speed * Time.deltaTime;
        }

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            this.transform.position = this.transform.position + -this.transform.right * speed * Time.deltaTime;
        }

        if (Input.GetAxis("Vertical") > 0.1f)
        {
            this.transform.position = this.transform.position + this.transform.up * speed * Time.deltaTime;
        }

        if (Input.GetAxis("Vertical") < -0.1f)
        {
            this.transform.position = this.transform.position + -this.transform.up * speed * Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && currentFireCD > firingSpeed)
        {
            currentFireCD = 0;
            Instantiate(projectile, this.transform.position, Quaternion.identity);
        }

        currentFireCD += Time.deltaTime;
        curentSafeTime += Time.deltaTime;
    }

    public void LowerHpBy(float value)
    {
        hp -= value;

        foreach (Slider i in sliders)
        {
            i.value = (hp * 100 / maxHp ) /100;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ennemy" && curentSafeTime > safeTime)
        {
            //Destroy(other.transform.parent.gameObject);
            curentSafeTime = 0;
            LowerHpBy(1);
        }
    }
}
