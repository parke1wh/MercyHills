using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    //Day 1 tasks list
    public Item task0, task1b, task2;       //This references the Item class and creating objects of the class
    public locationTrigger task1a, task3, task6a1, task6a2, task6a3, task6a4, task6a5, task6a6, task6a7, task6a8;   //This references the locationTrigger class and creating objects of the class
    public ButtonInteractions task4, task5a, task5b, task6b1, task6b2, task6b3, task6b4, task7;    //This references the ButtonInteractions class and creating objects of the class

    public Item day2Task6b, day2Task8;  //This references the Item class and creating objects of the class
    public locationTrigger day2Task2a, day2Task3, day2Task6a; //This references the locationTrigger class and creating objects of the class
    public ButtonInteractions day2Task0, day2Task1, day2Task2b, day2Task4, day2Task5, day2Task7a, day2Task7b, day2Task9,
        day2Task10, day2Task11, day2Task12, day2Task13a, day2Task13b, day2Task13c, day2Task13d, day2Task14;  //references the ButtonInteractions class and creating objects of the class

  

    public DayAnimations tasksFade;
    public TaskList taskList;
    public Status status;
    private Win_Cutscene_Activation activateWin;
    public Lighting lighting;

    [SerializeField] private List<Behaviour> glintZones;
    int counter;

    //This function keeps track of what task the player is currently on. Completed
    //Need to add a coroutine to switch the tasks
    //Need to add UI elements thats integrated with the coroutine
    //need to assign the button values to a dummy variable so that they don't go off again.

    private void Start()
    {
        activateWin = FindObjectOfType<Win_Cutscene_Activation>();
        glintZones = TurnOFFGlintAreas(glintZones);
        counter = 0;
        glintZones[counter].GetComponent("Halo");
        glintZones[counter].enabled = true;


    }

    private List<Behaviour> TurnOFFGlintAreas(List<Behaviour> zones)
    {
        List<Behaviour> placeholder = zones;
        foreach(Behaviour c in zones)
        {

            c.GetComponent("Halo");
            c.enabled = false;
        }
        return placeholder;

    }

    public void day2Tasks(int taskNum)
    {
        switch (taskNum)
        {
            case -2:
                Debug.Log("Shower activation before and after the task");

                status.resetStatus();
                break;

            case -1:
                Debug.Log("Dummy Variable doing nothing");
                lighting.check = true;
                break;

            case 0:
                Debug.Log("Task day2Task1 complete"); //(button obj) 
                day2Task2a.check = true;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                tasksFade.playAnimation();
                taskList.setString("Head to the Electrical Room!");
                lighting.turnOff();
                lighting.generatorOn = true;
                GameManager.Instance.lightsOff = true;
                day2Task1.turnOff();
                break;


            case 1:
                Debug.Log("Task day2Task2a complete"); //(area obj)
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task2b.check = true;
                tasksFade.playAnimation();
                taskList.setString("Turn on the Generator. It should stay on?");
                counter++;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = true;
                break;

            case 2:
                Debug.Log("Task day2Task2b complete"); //(button obj)
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task3.check = true;
                lighting.check = true;
                lighting.generatorOn = true;
                GameManager.Instance.lightsOff = false;
                day2Task2b.taskNum = -1;
                tasksFade.playAnimation();
                status.virusLeak = true; //virus bar still running during cutscene here
                taskList.setString("Virus Leak! Find the Security Room.");
                break;
            case 3:
                Debug.Log("Task day2Task3 complete"); //(area obj) 
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task4.check = true;
                status.virusLeak = false; 
                tasksFade.playAnimation();
                taskList.setString("Use the computer to lock down the Virus");
                counter++;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = true;
                day2Task4.turnOn();
                break;
            case 4:
                Debug.Log("Task day2Task4 complete"); //(button obj) 
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task5.check = true;
                tasksFade.playAnimation();
                taskList.setString("Restart the Virus Chamber");
                counter++;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = true;
                day2Task4.turnOff();
                day2Task5.turnOn();
                break;
            case 5:
                Debug.Log("Task day2Task5 complete"); //(button obj) 
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task6a.check = true;
                tasksFade.playAnimation();
                taskList.setString("Go to Lab 1");
                counter++;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = true;
                day2Task5.turnOff();
                break;
            case 6:
                Debug.Log("Task day2Task6a complete"); //(area obj)
                day2Task6b.check = true;
                tasksFade.playAnimation();
                taskList.setString("Grab the RNA strand jar");
                break;
            case 7:
                Debug.Log("Task day2Task6b complete");  //(item obj)
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task7a.check = true;
                tasksFade.playAnimation();
                taskList.setString("Put the RNA strand into the Virus Chamber");
                counter++;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = true;
                day2Task7a.turnOn();

                break;
            case 8:
                Debug.Log("Task day2Task7a complete"); //(button obj) 
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task7b.check = true;
                tasksFade.playAnimation();
                taskList.setString("Activate the Chamber");
                counter++;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = true;
                day2Task7a.turnOff();
                day2Task7b.turnOn();
                break;
            case 9:
                Debug.Log("Task day2Task7b complete"); //(button item) 
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task8.check = true;
                tasksFade.playAnimation();
                taskList.setString("Find a empty Syringe");
                counter++;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = true;
                day2Task7b.turnOff();
                break;
            case 10:
                Debug.Log("Task day2Task8 complete");  //(item obj)
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task9.check = true;
                tasksFade.playAnimation();
                taskList.setString("Fill Syringe with Virus at the Chamber");
                counter++;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = true;
                day2Task9.turnOn();
                break;
            case 11:
                Debug.Log("Task day2Task9 complete"); //(button obj) 
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task10.check = true;
                tasksFade.playAnimation();
                //if(GameManager.Instance.restart.played += Restart_played)
                status.virusLeak = true; //virus bar still running during cutscene here
                taskList.setString("Lab Leak! Lock down the Virus!");
                counter++;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = true;
                day2Task9.turnOff();
                day2Task10.turnOn();
                break;
            case 12:
                Debug.Log("Task day2Task11 complete"); //(button obj) 
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task11.check = true;
                status.virusLeak = false;
                tasksFade.playAnimation();
                taskList.setString("Activate Chamber to Mass Produce Vaccines");
                counter++;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = true;
                day2Task10.turnOff();
                day2Task11.turnOn();
                break;
            case 13:
                Debug.Log("Task day2Task12 complete"); //(button obj) 
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task12.check = true;
                tasksFade.playAnimation();
                taskList.setString("Put the vaccine in the shipping box in Electrical");
                counter++;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = true;
                day2Task11.turnOff();
                day2Task12.turnOn();
                break;
            case 14:
                Debug.Log("Task day2Task13 complete"); //(button obj) 
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task13a.taskNum = 15;
                day2Task13b.taskNum = 15;
                day2Task13c.taskNum = 15;
                day2Task13d.taskNum = 15;
                tasksFade.playAnimation();
                taskList.setString("Wash the Virus off using the shower");
                counter++;
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = true;
                day2Task12.turnOff();
                break;
            case 15:
                Debug.Log("Task day2Task14 complete"); //(button obj) 
                glintZones[counter].GetComponent("Halo");
                glintZones[counter].enabled = false;
                day2Task14.check = true;
                day2Task13a.taskNum = -2;
                day2Task13b.taskNum = -2;
                day2Task13c.taskNum = -2;
                day2Task13d.taskNum = -2;
                status.resetStatus();
                tasksFade.playAnimation();
                taskList.setString("You feel extremely exhausted, get some sleep");
                break;
            case 16:
                Debug.Log("Task day2Task15 complete"); // Activate bed to end/win the game.
                //tasksFade.playAnimation();
                //taskList.setString("");
                activateWin.EnableCutscene();
                day2Task14.turnOff();
                break;


        }
    }

    //private void Restart_played(UnityEngine.Playables.PlayableDirector obj)
    //{
    //    throw new NotImplementedException();
    //}

    public void day1Tasks(int taskNum)
    {
        switch (taskNum)
        {
            case -2:
                Debug.Log("Shower activation before and after the task");
                //resetStatus function from the status script
                status.resetStatus();
                break;
            case -1:
                Debug.Log("Generator");
                break;
            case 0:
                Debug.Log("Picked up task list"); // item tasks
                task1a.check = true;
                tasksFade.playAnimation();
                taskList.setString("Find Lab 2");
                break;
            case 1:
                Debug.Log("Task 1a complete");
                task1b.check = true;
                tasksFade.playAnimation();
                taskList.setString("Retrieve Virus Syringe");
                break;
            case 2:
                Debug.Log("Task 1b complete");
                task2.check = true;
                tasksFade.playAnimation();
                taskList.setString("Retrieve Beaker of low pH from Lab 2");
                break;
            case 3:
                Debug.Log("Task 2 complete");
                task3.check = true;
                tasksFade.playAnimation();
                taskList.setString("Find the Lab 3");
                break;
            case 4:
                Debug.Log("Task 3 completed");
                task4.check = true;
                tasksFade.playAnimation();
                taskList.setString("Release the Virus into the Virus Chamber");
                break;
            case 5:
                Debug.Log("Task 4 complete"); //button task
                task5a.check = true;
                task4.turnOff();
                task5a.turnOn();
                tasksFade.playAnimation();
                taskList.setString("Put the Low pH into the Chamber");
                task4.taskNum = -1;
                break;
            case 6:
                Debug.Log("Task 5a complete");
                task5b.check = true;
                task5a.turnOff();
                task5b.turnOn();
                tasksFade.playAnimation();
                taskList.setString("Activate the Chamber");
                task5a.taskNum = -1;
                break;
            case 7:
                Debug.Log("Task 5b completed");
                task6a1.check = true;
                task6a2.check = true;
                task6a3.check = true;
                task6a4.check = true;
                task6a5.check = true;
                task6a6.check = true;
                task6a7.check = true;
                task6a8.check = true;

                task5b.turnOff();
                tasksFade.playAnimation();
                taskList.setString("Find the Decontamination Room");
                task5b.taskNum = -1;                //if the object is a button and needs to be reused later, hard code the change of the task number and the check boolean.
                break;
            case 8:
                Debug.Log("Task 6a complete");
                task6b1.check = true;
                task6b2.check = true;
                task6b3.check = true;
                task6b4.check = true;

                task6b1.taskNum = 9;
                task6b2.taskNum = 9;
                task6b3.taskNum = 9;
                task6b4.taskNum = 9;

                task6a1.turnOff();
                task6a2.turnOff();
                task6a3.turnOff();
                task6a4.turnOff();
                task6a5.turnOff();
                task6a6.turnOff();
                task6a7.turnOff();
                task6a8.turnOff();

                tasksFade.playAnimation();
                taskList.setString("Wash the Virus off using the shower");
                break;
            case 9:
                Debug.Log("Task 6b complete"); //write code to reduce virus (case -2)
                task7.check = true;
                tasksFade.playAnimation();
                taskList.setString("Go to sleep. It's late");
                status.resetStatus();
                task6b1.taskNum = -2;
                task6b2.taskNum = -2;
                task6b3.taskNum = -2;
                task6b4.taskNum = -2;

                break;
            case 10:
                Debug.Log("Task 7 complete");  //cutscene to sleep and switch scenes or end it
                                               //task7.check = true;
                activateWin.EnableCutscene();
                task7.taskNum = -1;
                break;

        }
    }
}
