// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace interview
{
    class Program{

        static void Main (string[]args)
        {
        //stored in program list 
        List<string> text = new List<string>();

        text.Add("Welcome to the timewarp of programs!");
        text.Add("Applications like this were used in in the 1980s.");
        text.Add("I can’t wait for User Interfaces to be invented.");
        text.Add("Then I can do much more complicated things");

        Console.WriteLine("Enter your command");
        var str = Console.ReadLine();
        //do-while loop occurs unless input of "exit" is achieved
        do {
        //display the current list by "l" or "L" command   
        if (string.Equals(str, "l") || string.Equals(str, "L")) {
            
            Console.WriteLine("Current List:");
            foreach (var textString in text) {
            Console.WriteLine(textString);
            }

            str = Console.ReadLine();
        }
        //add the list by "a " or "A " command 
        else if (str.StartsWith("a ") || str.StartsWith("A ") ) {
            string str2 = str.Substring(1).TrimStart(); 
            text.Add(str2);
            Console.WriteLine("String added in the list");
            str = Console.ReadLine();

        }
        //insert the list at choosen position by "i " or "I " command
        else if (str.StartsWith("i ") || str.StartsWith("I ") ) {
            var ListCount = text.Count();
            var str2 = str.Substring(1).TrimStart();
            try{
            //check if the inserted var value contains number
            Regex re = new Regex(@"\d+");
            Match m = re.Match(str2);

            //position to be inserted to List
            int FrontNum = Convert.ToInt32(m.Value);
 
            //check if the number is within the bounds of the List
            if (FrontNum > ListCount) {
               Console.WriteLine("There is no List existed at " + FrontNum);
            }

            //insert element based on the FrontNum(index) to the List
            else if (m.Success && ((FrontNum < ListCount) || (FrontNum == ListCount)))
            {
             var str3 = str2.Substring(2);         
             text.Insert(FrontNum-1, str3);
             Console.WriteLine("String of " + str3 + " inserted into "+FrontNum + " list position");
            }
            //error handling
            }   
            catch(System.FormatException){
                Console.Error.WriteLine("Input string was not in a correct format. Try again");
            }
            catch(System.ArgumentOutOfRangeException){
                Console.Error.WriteLine("Index must be within the bounds of the List. Try again");
            }
            str = Console.ReadLine();
        }
        //delete a list at choosen position by "d " or "D " command
        else if (str.StartsWith("d ") || str.StartsWith("D ") ) {
            var ListCount = text.Count();
            var str2 = str.Substring(1).TrimStart();
            try{
            //check if the inserted var value contains number
            Regex re = new Regex(@"\d+");
            Match m = re.Match(str2);

            //position to be deleted to List 
            int FrontNum = Convert.ToInt32(m.Value);

            //check if the number is within the bounds of the List
            if (FrontNum > ListCount) {
               Console.WriteLine("There is no List existed at " + FrontNum);
            }

            //delete String based on the FrontNum(index) in the List
            else if ((m.Success && (FrontNum < ListCount)) || (m.Success && (FrontNum == ListCount)))
            {
             text.RemoveAt(FrontNum-1);
             Console.WriteLine("item removed from " + FrontNum + " list position");
            }
            //error handling
            }   
            catch(System.FormatException){
                Console.Error.WriteLine("Input string was not in a correct format. Try again");
            }
            catch(System.ArgumentOutOfRangeException){
                Console.Error.WriteLine("Index must be within the bounds of the List. Try again");
            }
            str = Console.ReadLine();

        }
        //replace a list at choosen position by "r " or "R " command
        else if (str.StartsWith("r ") || str.StartsWith("R ") ) {
            var ListCount = text.Count();
            var str2 = str.Substring(1).TrimStart();
            var str3 = str.Substring(4).TrimStart();

            try{
            //check if the inserted var value contains number
            Regex re = new Regex(@"\d+");
            Match m = re.Match(str2);
            Match m2 = re.Match(str3);

            //position to be swapped in the List
            int FrontNum = Convert.ToInt32(m.Value);
            int SecondNum = Convert.ToInt32(m2.Value);

            //check if the number is within the bounds of the List
            if (FrontNum > ListCount || SecondNum > ListCount) {
               Console.WriteLine("One or both list does not exist");
            }

            //Swap Element based on the FrontNum and SecondNum in the list
            else if ((m.Success && (FrontNum < ListCount)) || (m.Success && (FrontNum == ListCount)) &&
                     (m.Success && (SecondNum < ListCount)) || (m.Success && (SecondNum == ListCount)))
            {

             Swap (text, FrontNum-1, SecondNum-1); 
             Console.WriteLine("item " + FrontNum + " is swapped with item "+ SecondNum );

            }
            //error handling
            }   
            catch(System.FormatException){
                Console.Error.WriteLine("Input string was not in a correct format. Try again");
            }
            catch(System.ArgumentOutOfRangeException){
                Console.Error.WriteLine("Index must be within the bounds of the List. Try again");
            }
            
            str = Console.ReadLine();

        }
        //edit a list at choosen position by "e " or "E " command
        else if (str.StartsWith("e ") || str.StartsWith("E ") ) {
            var ListCount = text.Count();
            var str2 = str.Substring(1).TrimStart();
            var str3 = str.Substring(4).TrimStart();
            
            try{
            //check if the inserted var value contains number
            Regex re = new Regex(@"\d+");
            Match m = re.Match(str2);

            //position to be edited in the List
            int FrontNum = Convert.ToInt32(m.Value);

            //check if the number is within the bounds of the List
            if (FrontNum > ListCount) {
               Console.WriteLine("There is no List existed at " + FrontNum);
            }

            //edit Element based on the FrontNum in the List
            else if ((m.Success && (FrontNum < ListCount)) || (m.Success && (FrontNum == ListCount)))
            {
             text[FrontNum-1] = str3; 
             Console.WriteLine("item edited at " + FrontNum + " with " + str3);
            }
            //error handling
            }   
            catch(System.FormatException){
                Console.Error.WriteLine("Input string was not in a correct format. Try again");
            }
            catch(System.ArgumentOutOfRangeException){
                Console.Error.WriteLine("Index must be within the bounds of the List. Try again");
            }
            
            str = Console.ReadLine();
        }
        //save function with output of autonamed to .txt
        else if (str.StartsWith("save") || str.StartsWith("Save") ) {
            var str2 = str.Substring(4).TrimStart();

            StreamWriter sw = new StreamWriter(str2 + ".txt");
            foreach (var textString in text) {
            sw.WriteLine(textString);
            }
            sw.Close();

            Console.WriteLine("Progress saved named "+ str2 + ".txt");
            str = Console.ReadLine();
        }
        //load function which requires correct full name input
        else if (str.StartsWith("load") || str.StartsWith("Load") ) {
            var str2 = str.Substring(4).TrimStart();

            try{
            StreamReader sr = new StreamReader(str2);
            text.Clear();
            string line;
            while ((line = sr.ReadLine()) != null){
            text.Add(line); 
             }
            sr.Close();
            Console.WriteLine("new list loaded from "+ str2);
            }
            //error handling
            catch (FileNotFoundException){
                Console.Error.WriteLine("Can not find file {0}.", str2);
            }
            catch(System.ArgumentException){
                 Console.Error.WriteLine("Empty path name is not legal. Try again");
            }
            str = Console.ReadLine();
        }
        //if incorrect command format is entered
        else {
            Console.WriteLine("error! enter the correct command");
            str = Console.ReadLine();
        }

        }
        while (str != "exit");
        }
        
        //swap function in a list given 2 index position
        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
          T tmp = list[indexA];
          list[indexA] = list[indexB];
          list[indexB] = tmp;
        }
    }
 
}
