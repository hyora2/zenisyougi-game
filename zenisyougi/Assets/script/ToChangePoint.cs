using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToChangePoint  : MonoBehaviour
{
  
    public float ToWorldPoint(int Lp){
       
        float[] wp = new float[8];
        wp[1] = 1.25f;
        wp[2] = 4.00f;
        wp[3] = 6.80f;
        wp[4] = 9.50f;
        wp[5] = 12.25f;
        wp[6] = 15.00f;
        wp[7] = 17.75f;

        wp[0] = 49.00f;

        switch(Lp){
            case 1: return wp[1];
            case 2: return wp[2];
            case 3: return wp[3];
            case 4: return wp[4];
            case 5: return wp[5];
            case 6: return wp[6];
            case 7: return wp[7];

            default: return wp[0];

        }

    }


    public int ToLocalPoint(float Wp){
        if(1.0f < Wp && Wp < 2.2f){
            return 1;
        }else if(3.5f < Wp && Wp < 4.5f){
            return 2;
        }else if(6.5f < Wp && Wp < 7.2f){
            return 3;
        }else if(9.0f < Wp && Wp < 10.0f){
            return 4;
        }else if(12.0f < Wp && Wp < 13.0f){
            return 5;
        }else if(14.5f < Wp && Wp < 15.5f){
            return 6;
        }else if(17.0f < Wp && Wp < 18.0f){
            return 7;
        }else {
            return 0;
        }
           

    }


}