global using System;
global using System.Collections;
global using System.Collections.Generic;
global using System.Diagnostics.Metrics;
global using System.Linq;
global using System.Reflection;
global using System.Runtime.InteropServices;
global using System.Text;
global using System.Text.RegularExpressions;
global using Microsoft.VisualBasic;
global using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
using static System.Net.Mime.MediaTypeNames;

namespace Final_Project
{
    public static class Program
    {
        static void Main(string[] args)
        {
            
            Game newGame = new Game();
            newGame.InitializeGame();

            /*----------------------------------------------
                Notes before playing:
                    * Have the outline box when started
                      encompass the width of the console

                    * Have a 2 line gap between top and
                      bottom of box

                    * The Yamato weapon was used for testing
                      as it 1-shots every enemy


                Changes from original instructions:
                    * Every fight you do you earn BP,
                      losing earns you half the total BP

                    * Weapon drops are a 1/4 chance

                    * Show statistics is replaced with 
                      store menu

                    * Strength is replaced with attacks 
                      purchased from the store that
                      multiply the damage of equiped weapon

                    * Equiped armor is replaced with 
                      energy and enery is replenished
                      every round
             -----------------------------------------------*/

        }
    }
}