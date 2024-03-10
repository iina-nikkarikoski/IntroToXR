using System;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Story : MonoBehaviour
{
   public bool task1;
   public bool task2;
   public GameObject plane1;
   public GameObject plane2;
   public GameObject plane3;
   public GameObject chest;
   private Collision1 collision1;
   private Collision2 collision2;
   private Collision3 collision3;
   private Collision4 collision4;
   private Collision5 collision5;

   public List<int> buttonList = new List<int>();
   public Action<int> OnButtonPressed;
   private int count;

   

   void Start()
   {
        collision1 = GameObject.Find("Target 1").GetComponent<Collision1>();
        collision2 = GameObject.Find("Target 2").GetComponent<Collision2>();
        collision3 = GameObject.Find("Target 3").GetComponent<Collision3>();
        collision4 = GameObject.Find("Target 4").GetComponent<Collision4>();
        collision5 = GameObject.Find("Target 5").GetComponent<Collision5>();
   }

   void Update()
   {
        FinishedTask1();
        FinishedTask2();
        Treasure()
;   }

    void FinishedTask1()
    {
        if (collision1.target1 &&
            collision2.target2 &&
            collision3.target3 &&
            collision4.target4 &&
            collision5.target5) 
        {
            plane1.SetActive(true);
            task1 = true;
        }
        else
        {
            plane1.SetActive(false);
        }
    }

    void PrintList()
    {
        foreach (int element in buttonList)
        {
            Debug.Log(element);
        }
    }

    public void AddButtonIndex(int index)
    {
        buttonList.Add(index);
        PrintList();
        count++;
        OnButtonPressed?.Invoke(index);
    }

    public void ResetList(int index)
    {
        buttonList.Clear();
        PrintList();
        OnButtonPressed?.Invoke(index);
    }

    void FinishedTask2()
    {
        if (count >= 4 &&
            buttonList[0] == 4 &&
            buttonList[1] == 2 &&
            buttonList[2] == 1 &&
            buttonList[3] == 3)
        {
            plane2.SetActive(true);
            task2 = true;
        }
        else
        {
            plane2.SetActive(false);
        }   
    }

    void Treasure()
    {
        if (task1 && task2)
        {
            plane3.SetActive(true);
            chest.SetActive(true);
        }
        else
        {
            plane3.SetActive(false);
            chest.SetActive(false);
        }
    }
}
