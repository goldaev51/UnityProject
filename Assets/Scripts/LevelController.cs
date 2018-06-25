using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
   
    public static LevelController current;
    private int lifesCount = 3;
   

    void Awake() {
        current = this;
    }

    public int getLifesCount(){
        return lifesCount;
    }
 
    //class LevelController
    Vector3 startingPosition;
   
    public void setStartPosition(Vector3 pos) {
        this.startingPosition = pos;
    }
    
    public void onRabitDeath(HeroRabit rabit) {
        //При смерті кролика повертаємо на початкову позицію
        rabit.transform.position = this.startingPosition;
    }
}
