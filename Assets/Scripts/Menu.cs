using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static bool GamePause = false;// змінна пузи гри

    public GameObject player;// змінна гравця 

    public GameObject menu;// змінна панелі меню
 
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))// при натисканні кнопки Escape
        {
            if (GamePause)// Якщо гра вже не на паузі
            {

                menu.SetActive(false);// меню не активне
                Time.timeScale = 1f;// нормалізується час гри
                GamePause = false; // гра не на паузі
                player.GetComponent<NewBehaviourScript>().enabled = true;// зупиняємо скрипт переміщення гравця та камери 

            }
            else // Якщо гра на паузі
            {
                menu.SetActive(true);// меню активне
                Time.timeScale = 0f;// час гри зупиняється 
                GamePause = true;// гра на паузі 
                player.GetComponent<NewBehaviourScript>().enabled = false;// запускаємо скрипт переміщення гравця та камери 
            }
        }
    }
    public void Resume() // функція для кнопки 
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
        player.GetComponent<NewBehaviourScript>().enabled = true;
    }
    public void Exit()// функція для кнопки вийти
    {
        Application.Quit();
    }
}