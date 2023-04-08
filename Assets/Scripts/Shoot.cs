using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	[SerializeField]
    private float _rayDistance;
    public Camera Camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 Ray ray = Camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); // промінь відносно цента екрану
        RaycastHit hit;// змінна для розрахунків промення
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, _rayDistance)) // якщо промінь влучив в ціль 
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>(); // перевірка чи ціль є ворогом
                if (enemy)
                {
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }
}

