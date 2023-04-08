using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
[SerializeField]
    private Transform _player; //приватне поле, яке буде доступне в інспекторі 
    [SerializeField]
    private int _distance;
    [SerializeField]
    private float _speedRotation;
    [SerializeField]
    private float _speedMove;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, _player.transform.position) < _distance) // перевірка дистанції між гравцем та ворогом
        {
            Vector3 Rotation = _player.position - transform.position;//змінна для повороту ворога
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Rotation), _speedRotation * Time.deltaTime);// швидкість повороту ворога 
            transform.position += transform.forward * _speedMove * Time.deltaTime;// швидкість переміщення ворога 
        }
	}
	
	
}
