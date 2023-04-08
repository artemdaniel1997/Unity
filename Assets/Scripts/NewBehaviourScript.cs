using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject cam; // камера гравця 
	public Text Text, WinText;// 
   	private int count, countCoins; 
    	Quaternion StartRotation; // початкова позиція гравця 
   	float Ver, Hor; // змінні для переміщення 
    	float RotVer, RotHor; // розміщення камери гравця 
    	public float Speed = 10, sensetive = 6; // швидкість гравця та чутливість мишкі 
	// Use this for initialization
	void Start () {
	StartRotation = transform.rotation;
	count = 0;
        WinText.text = "";
        countCoins = GameObject.FindGameObjectsWithTag("coins").Length;
        setCount();
	}
	void OnTriggerEnter (Collider other)// функція збирання монет 
    	{
        if (other.tag == "coins")
	{
            Destroy(other.gameObject);
            count++;
            setCount();
        }
    }
    private void setCount()
    {
        Text.text = "Кількість: " + count.ToString();
        if(count>=countCoins)
        {
            WinText.text = "Winner!";
        }
    }
	// Update is called once per frame
	void Update () {
	RotHor += Input.GetAxis("Mouse X") * sensetive; // направлення камери 
        RotVer += Input.GetAxis("Mouse Y") * sensetive;
	RotVer = Mathf.Clamp(RotVer, -60, 60); // границі камери
        Quaternion RotY = Quaternion.AngleAxis(RotHor, Vector3.up);// розміщення по осі Y
        Quaternion RotX = Quaternion.AngleAxis(-RotVer, Vector3.right);// розміщення по осі X
        cam.transform.rotation = StartRotation * transform.rotation * RotX;// переміщення камери
        transform.rotation = StartRotation * RotY;// переміщення камери відносно гравця
        Ver = Input.GetAxis("Vertical") * Time.deltaTime * Speed; // направлення вверх
        Hor = Input.GetAxis("Horizontal") * Time.deltaTime * Speed; // направлення вниз
        transform.Translate(new Vector3(Hor, 0, Ver));// переміщення гравця 
	}
}

