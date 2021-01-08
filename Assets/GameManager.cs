using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
   
private int cookie ;    
private float counter;
public float cooldown;
public Text CookieText;

public List<string> Names = new List<string>();
public List<int> Numbers=new List<int>();
public List<int> Costs=new List<int>();
public List<int> Cooldowns=new List<int>();
public List<int> Rates=new List<int>();
private List<float> Counters=new List<float>() {0,0,0};
public Text CookerButtonText;
public Text OvenButtonText;
public Text BakeryButtonText;
    // Start is called before the first frame update
    void Start()
    {
        cookie = 0;
        counter = 0;
        
        /*
        int result = 0;
        Debug.Log(result); // affiche résultat 
        
    for (int i=0;i<20;i++) // tant que I < 20 ajoute 1 
        {
        result = Increment(result); // appel de la fonction 
        }
        result = Add(result,5);
 */

    }

    public void ManualIncrement()
    {
        cookie = Increment(1);
    }

    public void BuyCooker(){// BUY COOKERS
        if (cookie >= Costs[0]){
            cookie-=Costs[0];
             UpdateCookieDisplay(cookie);
            Numbers[0]++;
            CookerButtonText.text = Names[0] + " : " +Numbers[0].ToString();
                  
        }
    }
    public void BuyOvens(){//BUY OVENS
         if (cookie >= Costs[1]){
            cookie-=Costs[1];
             UpdateCookieDisplay(cookie);
            Numbers[1]++;
            OvenButtonText.text = Names[1] + " : " +Numbers[1].ToString();

        }
    }

     public void BuyBakery(){//BUY BAKERY
         if (cookie >= Costs[2]){
            cookie-=Costs[2];
             UpdateCookieDisplay(cookie);
            Numbers[2]++;
            BakeryButtonText.text = Names[2] + " : " +Numbers[2].ToString();

        }
    }

    public int Increment(int value) // la fonction avec sa définition 
    {
        int total = cookie + value ;
        UpdateCookieDisplay(total);
        return total;
        }

    /*int Add (int a,int b) // add 2 parameters exemple : result +5 
{
    int r = a+b;
     Debug.Log(r);
     return r;
} */

    // Update is called once per frame
    void Update()
    {
        counter +=Time.deltaTime;
        Counters[0] += Time.deltaTime;//créer des cookies 
        Counters[1] += Time.deltaTime;
        Counters[2] += Time.deltaTime;  
        /*if (counter>=cooldown) 
        {
           cookie = Increment(1);
            counter -= cooldown;
            
        }*/

        if (Counters[0] >=Cooldowns[0]){ // cookers créer cookie 
            cookie = Increment(Rates[0]*Numbers[0]);
            Counters[0]-=Cooldowns[0];
        }

         if (Counters[1] >=Cooldowns[1]){ // Ovens créer cookie 
            cookie = Increment(Rates[1]*Numbers[1]);
            Counters[1]-=Cooldowns[1];
        }

        if (Counters[2] >=Cooldowns[2]){ // bakeries créer cookie 
            cookie = Increment(Rates[2]*Numbers[2]);
            Counters[2]-=Cooldowns[2];
        }

    }
   private void UpdateCookieDisplay(int newNumber)
    {
        CookieText.text = "Cookies : " + newNumber.ToString();

    }

public void QuitGame() // quitter le jeu 
{
    Application.Quit();
}
}
