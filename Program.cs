using System;
using System.Collections;
using System.Collections.Generic;

namespace GalaxySystem
{

    interface ISubject
    {
        void Attach(IObserver observer);

        void Notify();

    }


    interface IObserver
    {


        void Update(ISubject subject);

    }




    // display interface inheritence



    public interface PlanetInformation
    {

        void DisplayInformation();


    }

    // USED JUST IN EARTH AND MARS 
    public interface LifeFormInformation : PlanetInformation
    {

        void ShowADN();
        void ShowLifeFormName();
        void ShowLanguageSample();

    }


   







    class Star : ISubject
    {
        private List<IObserver> observers; // create a list of observers

        // we create a variable gravity that will be observed

        public bool isalive;

        public bool Isalive
        {

            get { return isalive; }



            set
            {
                isalive = value;
                Notify();

                // whenever the gravity will be changed notify will be called and will update all the registered observers

            }


        }
        // for the sake of pattern demonstration we will act as gravity is a normal property of a galaxy and doesnt get its value as physical gravity




        public Star()
        {

            observers = new List<IObserver>(); // initialise the list


        }

        public void Attach(IObserver myobserver)
        {
            // attach observers to the subject

            observers.Add(myobserver);
        }


        public void Notify()
        {
            // notify all the registered observers that a change has been made about the subject Galaxy

            observers.ForEach(o =>
            {
                o.Update(this);

            });

        }

    }


    // SINGLETON PATTERN 

    public class Galaxy
    {

        // private constructor for singleton , lets us create only 1 instance of Galaxy

        private Galaxy() { }

        // we assign the instance 

        private static Galaxy mygalaxy = new Galaxy(); 


        // lets create a public property to use our singleton


        public static Galaxy Instance
        {

            get { return mygalaxy; } // retuns mygalaxy instance

        }

        public void GalaxyName()
        {
            Console.WriteLine("\nThis is the Millky Way galaxy !");

        }

        // we use the singleton in menu to show information for the galaxy 

    }








    public abstract class PlanetBluePrint
    {

        // advantages of abstract class is that not all methods need to be implemented and that you can add implementation directly here


        public String name;
        public int distancefromsun;
        public int size;
        
        public int temperature;
        public int windspeed;

        
       



        public PlanetBluePrint( int distancefromsun, int size, int temperature, int windspeed)
        {
            
            this.distancefromsun = distancefromsun;
            this.size = size;
            this.temperature = temperature;
            this.windspeed = windspeed;


        }



        public abstract void calculateGravity();

        public abstract double CalculateMagneticFieldStrength();

        public abstract void HasWater();

        public abstract void HasSolidCore(ref bool flag); // !!! USED TO SHOW SOLID CONCEPT OF 1 METHOD SHOULD DO 1 THING LOOK IN PLANET IMPLEMENTATION 

        public abstract void createPlanet();



    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ MERCURY @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    class Mercury : PlanetBluePrint, IObserver , PlanetInformation
    {
        public string Name { get; set; }  // property

        public int Distancefromsun { get; set; }  // property

        public int Size { get; set; }  // property


        public int Temperature { get; set; }  // property

        public int Windspeed { get; set; }  // property

        public Mercury(String name, int distancefromsun, int size, int temperature, int windspeed) : base(distancefromsun, size, temperature, windspeed)

        {
            Name = name;

            Distancefromsun = distancefromsun;

            Size = size;

            Temperature = temperature;

            Windspeed = windspeed;



        }




        // implement observer interface
        public void Update(ISubject subject)
        {
            // read the gracvity value from the subject passed as argument


            // cast the subject in galaxy type 


            if (subject is Star mystar)
            // if subject is type of Galaxy
            {

                Console.WriteLine("Planet's " + Name + " star is alive ? " + mystar.isalive);

                if (!mystar.isalive)
                {

                    // here we can do anything we want 


                    Console.WriteLine("All the life is dead");
                    
                }

                else
                {

                    Console.WriteLine("Everything is ok ! ");

                }


            }



        }



        public void DisplayInformation()
        {
            Console.WriteLine("Infomation -- >" + "Planet name " + Name + "\n" + "Planet distance from sun " + Distancefromsun + "\n" + "Planet size " + Size + "\n" + "Planet temperature " + Temperature + "\n" + "Planet windspeed " + Windspeed);
        }



        // -------------------------------------------------------------------------------------------- ABSTRACT CLASS IMPLEMENTATION ---------------------------------------------------------------------------------------------------------------


        public override void  createPlanet()
        {
            Console.WriteLine("\n" + "This is the planet " + Name + "\n");

            Console.WriteLine(@"

            _______
         .-' _____ '-.
        .' .-'.  ':'-. '.
       / .''::: .:    '. \
      / /   :::::'      \ \
     | ;.    ':' `       ; |
     | |       '..       | |
     | ; '      ::::.    ; |
      \ \       '::::   / /
       \ '.      :::  .' /
        '. '-.___'_.-' .'
          '-._______.-

            ");
        }



        


        private double gravitational_acceleration = 4.7;
     
        bool myFlag = false;

        public override void HasSolidCore(ref bool flag)
        {
            flag = true;
        }

        public override void calculateGravity()
        {
            HasSolidCore(ref myFlag); // setting the core true for being solid 

            if (myFlag)
            {
                Console.WriteLine("Gravity on Mercury is " + gravitational_acceleration * 9.8);
            }

            else
            {
                Console.WriteLine("Planet " + Name + " has no gravity");

            }

        }



        public override double CalculateMagneticFieldStrength()
        {


            double strength = gravitational_acceleration * 9.8 / 2;
           
            Console.WriteLine("The magnetic field strength of " + Name + " is " + strength);
            
            return strength;

            


        }



        public override void HasWater()
        {
            Console.WriteLine("This planet does not have water ! ");
        }

        
    }


    





    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ VENUS @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@




    class Venus : PlanetBluePrint, IObserver , PlanetInformation 
    {

        public string Name { get; set; }  // property

        public int Distancefromsun { get; set; }  // property

        public int Size { get; set; }  // property


        public int Temperature { get; set; }  // property

        public int Windspeed { get; set; }  // property

       



        public Venus(String name,int distancefromsun, int size,  int temperature, int windspeed) : base( distancefromsun,size, temperature, windspeed)

        {
            Name = name;

            Distancefromsun = distancefromsun;

            Size = size;

            Temperature = temperature;

            Windspeed = windspeed;


        }




        // implement observer interface
        public void Update(ISubject subject)
        {
            // read the gracvity value from the subject passed as argument


            // cast the subject in galaxy type 


            if (subject is Star mystar)
                 // if subject is type of Galaxy
            {

                Console.WriteLine("Planet's " + Name + " star is alive ? " + mystar.isalive);

                if (!mystar.isalive)
                {

                    Console.WriteLine("All the life is dead");
                    // adauga implementare mai buna
                }

                else
                {

                    Console.WriteLine("Everything is ok ! ");

                }


            }



        }

        public void DisplayInformation()
        {
            Console.WriteLine("Infomation -- >" + "Planet name " + Name  +"\n"+  "Planet distance from sun " + Distancefromsun  + "\n" + "Planet size " + Size  + "\n" + "Planet temperature " + Temperature + "\n" + "Planet windspeed " + Windspeed );
        }

        
        
        
        // -------------------------------------------------------------------------------------------- ABSTRACT CLASS IMPLEMENTATION ---------------------------------------------------------------------------------------------------------------
        
        
        
        public override void createPlanet()
        {
            Console.WriteLine("\n" + "This is the planet " + Name + "\n");

            Console.WriteLine(@"

              __...----...__
           .-' -=;::;::`;:::`-.
        .-'""; `-;:"""";`-; ,;;'`-.
      .''"";;:     ,..   `.;;. .';;'.
     /  ,;;::,     `--'  ,.;: ::  .;:\
    ..- .; ;:,;,,.,   ,  ;;: ::;;:..;:.
   ;   ;    .;::,    ;:.;:::::::::;., ;
   |;. :      ;:;       `-;:::::-'""""|
   | ;,'  ,;::     ;.     `-;::  `;:::|
   ;`-;.   ,;:  ,;; `.  ."""";,   ;;, ;
   '. ."""".,    """".    ,;:;  '.,;::.
    `.                              .'
      `.                          .'
        `-.                    .-'
           """"--...______...--""""

            ");
        }


       




        private double gravitational_acceleration = 3.7;

        bool myFlag = false;

        public override void HasSolidCore(ref bool flag)
        {
            flag = false;
        }


        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! display of SOLID CONCEPT 1 method should do only 1 thing , We decide if the planet has solid care in external method and use it in calculateGravity() method

        public override void calculateGravity()
        {
            HasSolidCore(ref myFlag); // setting the core true for being solid 

            if (myFlag)
            {
                Console.WriteLine("Gravity on Mercury is " + gravitational_acceleration * 9.8);
            }

            else
            {
                Console.WriteLine("Planet " + Name + " has no gravity");

            }

        }



        public override double CalculateMagneticFieldStrength()
        {


            double strength = gravitational_acceleration * 9.8 / 2;

            Console.WriteLine("The magnetic field strength of " + Name + " is " + strength);

            return strength;




        }



        public override void HasWater()
        {
            Console.WriteLine("This planet does not have water ! ");
        }

        
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ EARTH @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    class Earth : PlanetBluePrint, IObserver, LifeFormInformation // Extends 1 abstract class and multiple interfaces 
    {

        public string Name { get; set; }  // property

        public int Distancefromsun { get; set; }  // property

        public int Size { get; set; }  // property


        public int Temperature { get; set; }  // property

        public int Windspeed { get; set; }  // property



        public Earth(String name, int distancefromsun, int size, int temperature, int windspeed) : base(distancefromsun, size, temperature, windspeed)

        {
            Name = name;

            Distancefromsun = distancefromsun;

            Size = size;

            Temperature = temperature;

            Windspeed = windspeed;



        }

        // implement observer interface
        public void Update(ISubject subject)
        {
            // read the gracvity value from the subject passed as argument


            // cast the subject in galaxy type 


            if (subject is Star mystar
                ) // if subject is type of Galaxy
            {

                Console.WriteLine("Planet's " + Name + " star is alive ? " + mystar.isalive);

                if (!mystar.isalive)
                {

                    Console.WriteLine("All the life is dead");
                    // adauga implementare mai buna
                }

                else
                {

                    Console.WriteLine("Everything is ok ! ");

                }


            }



        }





        // -------------------------------------------------------------------------------------------- ABSTRACT CLASS IMPLEMENTATION ---------------------------------------------------------------------------------------------------------------


        // we can see Earth impelemnts a child interface of PlanetInformation  caleed LifeFormInformation and needs to implement the methods from LifeFormInformation but also the method from the mother interface


      


        public void DisplayInformation()
        {
            Console.WriteLine("Infomation -- >" + "Planet name " + Name + "\n" + "Planet distance from sun " + Distancefromsun + "\n" + "Planet size " + Size + "\n" + "Planet temperature " + Temperature + "\n" + "Planet windspeed " + Windspeed);
        }

        public void ShowADN()

        {

            Console.WriteLine("\n" + "The ADN of the lifeforms from earth looks like this :" );


            Console.WriteLine(@"

`-:-.   ,-;""`-:-.   ,-;""`-:-.   ,-;""`-:-.   ,-;""
   `=`,'=/     `=`,'=/     `=`,'=/     `=`,'=/
     y==/        y==/        y==/        y==/
   ,=,-<=`.    ,=,-<=`.    ,=,-<=`.    ,=,-<=`.
,-'-'   `-=_,-'-'   `-=_,-'-'   `-=_,-'-'   `-=_");
        }

        public void ShowLifeFormName()
        {

            Console.WriteLine("\n"+ "The name of the lifeform from earth is Human :" );


            Console.WriteLine(@"
                 ,#####,
                 #_   _#
                 |a` `a|
                 |  u  |
                 \  =  /
                 |\___/|
        ___ ____/:     :\____ ___
      .'   `.-===-\   /-===-.`   '.
     /      .-""""""""""-.-""""""""""-.      \
    /'             =:=             '\
  .'  ' .:    o   -=:=-   o    :. '  `.
  (.'   /'. '-.....-'-.....-' .'\   '.)
  /' ._/   "".     --:--     .""   \_. '\
 |  .'|      "".  ---:---  .""      |'.  |
 |  : |       |  ---:---  |       | :  |
  \ : |       |_____._____|       | : /
  /   (       |----|------|       )   \
 /... .|      |    |      |      |. ...\
|::::/''     /     |       \     ''\::::|
'""""""""       /'    .L_      `\       """"""""'
           /'-.,__/` `\__..-'\
          ;      /     \      ;
          :     /       \     |
          |    /         \.   |
          |`../           |  ,/
          ( _ )           |  _)
          |   |           |   |
          |___|           \___|
          :===|            |==|
           \  /            |__|
           /\/\           /""""""`8.__
           |oo|           \__.//___)
           |==|
           \__/");
        }

        public void ShowLanguageSample()
        {
            Console.WriteLine("\n" + " Sample of human language : ");

            Console.WriteLine(@"
  _    _      _ _         _   _     _       _                          _                                          
 | |  | |    | | |       | | | |   (_)     (_)                        | |                                         
 | |__| | ___| | | ___   | |_| |__  _ ___   _ ___    ___  _   _ _ __  | | __ _ _ __   __ _ _   _  __ _  __ _  ___ 
 |  __  |/ _ \ | |/ _ \  | __| '_ \| / __| | / __|  / _ \| | | | '__| | |/ _` | '_ \ / _` | | | |/ _` |/ _` |/ _ \
 | |  | |  __/ | | (_) | | |_| | | | \__ \ | \__ \ | (_) | |_| | |    | | (_| | | | | (_| | |_| | (_| | (_| |  __/
 |_|  |_|\___|_|_|\___/   \__|_| |_|_|___/ |_|___/  \___/ \__,_|_|    |_|\__,_|_| |_|\__, |\__,_|\__,_|\__, |\___|
                                                                                      __/ |             __/ |     
                                                                                     |___/             |___/");
        }


        // -------------------------------------------------------------------------------------------- ABSTRACT CLASS IMPLEMENTATION ---------------------------------------------------------------------------------------------------------------

        public override void createPlanet()
        {
            Console.WriteLine("\n" + "This is the planet " + Name + "\n");

            Console.WriteLine(@"

            _-o#&&*''''?d:>b\_
          _o/""`'''',, dMF9MMMMMHo_
       .o&#'      `""MbHMMMMMMMMMMMHo.
     .o"""" '       vodM*$&&HMMMMMMMMMM?.
    ,'              $M&ood,~'`(&##MMMMMMH\
   /               ,MMMMMMM#b?#bobMMMMHMMML
  &              ?MMMMMMMMMMMMMMMMM7MMM$R*Hk
 ?$.            :MMMMMMMMMMMMMMMMMMM/HMMM|`*L
|               |MMMMMMMMMMMMMMMMMMMMbMH'   T,
$H#:            `*MMMMMMMMMMMMMMMMMMMMb#}'  `?
]MMH#       """"*""""""""*#MMMMMMMMMMMMM'    -
MMMMMb_                   |MMMMMMMMMMMP'     :
HMMMMMMMHo                 `MMMMMMMMMT       .
?MMMMMMMMP                  9MMMMMMMM}       -
-?MMMMMMM                  |MMMMMMMMM?,d-    '
 :|MMMMMM-                 `MMMMMMMT .M|.   :
  .9MMM[                    &MMMMM*' `'    .
   :9MMk                    `MMM#""        -
     &M}                     `          .-
      `&.                             .
        `~,   .                     ./
            . _                  .-
              '`--._,dd###pp=""""'

            ");
        }




        private double gravitational_acceleration = 12.7;

        bool myFlag = false;

        public override void HasSolidCore(ref bool flag)
        {
            flag = true;
        }

        public override void calculateGravity()
        {
            HasSolidCore(ref myFlag); // setting the core true for being solid 

            if (myFlag)
            {
                Console.WriteLine("Gravity on Mercury is " + gravitational_acceleration * 9.8);
            }

            else
            {
                Console.WriteLine("Planet " + Name + " has no gravity");

            }

        }



        public override double CalculateMagneticFieldStrength()
        {


            double strength = gravitational_acceleration * 9.8 / 2;

            Console.WriteLine("The magnetic field strength of " + Name + " is " + strength);

            return strength;




        }



        public override void HasWater()
        {
            Console.WriteLine("This planet has water ! ");
        }
    }



    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ MARS @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    class Mars : PlanetBluePrint, IObserver, LifeFormInformation
    {
        public string Name { get; set; }  // property

        public int Distancefromsun { get; set; }  // property

        public int Size { get; set; }  // property


        public int Temperature { get; set; }  // property

        public int Windspeed { get; set; }  // property



        public Mars(String name, int distancefromsun, int size, int temperature, int windspeed) : base(distancefromsun, size, temperature, windspeed)

        {
            Name = name;

            Distancefromsun = distancefromsun;

            Size = size;

            Temperature = temperature;

            Windspeed = windspeed;



        }


        // implement observer interface
        public void Update(ISubject subject)
        {
            // read the gracvity value from the subject passed as argument


            // cast the subject in galaxy type 


            if (subject is Star mystar
                ) // if subject is type of Galaxy
            {

                Console.WriteLine("Planet's " + Name + " star is alive ? " + mystar.isalive);

                if (!mystar.isalive)
                {

                    Console.WriteLine("All the life is dead");
                    // adauga implementare mai buna
                }

                else
                {

                    Console.WriteLine("Everything is ok ! ");

                }


            }



        }



        // we can see Earth impelemnts a child interface of PlanetInformation  caleed LifeFormInformation and needs to implement the methods from LifeFormInformation but also the method from the mother interface

        public void DisplayInformation()
        {
            Console.WriteLine("Infomation -- >" + "Planet name " + Name + "\n" + "Planet distance from sun " + Distancefromsun + "\n" + "Planet size " + Size + "\n" + "Planet temperature " + Temperature + "\n" + "Planet windspeed " + Windspeed);
        }

       



        public void ShowADN()

        {

            Console.WriteLine("The ADN of the lifeforms from earth looks like this :" + "\n");


            Console.WriteLine(@"
       o O       o O       o O       o O
     o | | O   o | | O   o | | O   o | | O
   O | | | | O | | | | O | | | | O | | | | O
  O-oO | | o   O | | o   O | | o   O | | oO-o
 O---o O o       O o       O o       O o O---o
O-----O                                 O-----o
o-----O                                 o-----O
 o---O                                   o---O
  o-O                                     o-O
   O                                       O
  O-o                                     O-O
 O---o                                   O---o
O-----o                                 O-----o
o-----O                                 o-----O
 o---O o O       o O       o O       o O o---O
  o-Oo | | O   o | | O   o | | O   o | | Oo-O
   O | | | | O | | | | O | | | | O | | | | O
     O | | o   O | | o   O | | o   O | | o
       O o       O o       O o       O o");
        }

        public void ShowLifeFormName()
        {

            Console.WriteLine("\n" + "The name of the lifeform from earth is Human :");


            Console.WriteLine(@"
      _       _
     (_\     /_)
       ))   ((
  .-""""""""""""""-.
 /^\/  _.   _.  \/^\
 \(   /__\ /__\   )/
  \,  \o_/_\o_/  ,/
    \    (_)    /
     `-.'==='.-'
      __) - (__
     /  `~~~`  \
    /  /     \  \
    \ :       ; /
     \|==(*)==|/
      :       :
       \  |  /
     ___)=|=(___
    {____/ \____}");
        }

        public void ShowLanguageSample()
        {
            Console.WriteLine("\n" + " Sample of human language : ");

            Console.WriteLine(@"
  ____  _ _         _     _               _     _ _     _ _ _ _   _     _             
 |  _ \| (_)       | |   | |             | |   | (_)   | (_) (_) | |   | |            
 | |_) | |_ _ __   | |__ | | ___  _ __   | |__ | |_  __| |_| |_  | |__ | | ___  _ __  
 |  _ <| | | '_ \  | '_ \| |/ _ \| '_ \  | '_ \| | |/ _` | | | | | '_ \| |/ _ \| '_ \ 
 | |_) | | | |_) | | |_) | | (_) | |_) | | |_) | | | (_| | | | | | |_) | | (_) | |_) |
 |____/|_|_| .__/  |_.__/|_|\___/| .__/  |_.__/|_|_|\__,_|_|_|_| |_.__/|_|\___/| .__/ 
           | |                   | |                                           | |    
           |_|                   |_|                                           |_|");
        }


        // -------------------------------------------------------------------------------------------- ABSTRACT CLASS IMPLEMENTATION ---------------------------------------------------------------------------------------------------------------



        public override void createPlanet()
        {
            Console.WriteLine("\n" + "This is the planet " + Name + "\n");

            Console.WriteLine(@"

          ___---___                    
      .--           --.      
    ./   ()      . -.  \.
   /   o    .   (    )   \
  / .            '-'      \         
 | ()    .  O         .    |      
|                           |      
|    o           ()         |
|       .--.          O     |            
 | .   |    |               |
  \    `.__.'    o     .   /    
   \                      /                   
    `\  o    ()         /'       
      `--___   ______--'
            ---

            ");
        }




        private double gravitational_acceleration = 12.7;

        bool myFlag = false;

        public override void HasSolidCore(ref bool flag)
        {
            flag = true;
        }

        public override void calculateGravity()
        {
            HasSolidCore(ref myFlag); // setting the core true for being solid 

            if (myFlag)
            {
                Console.WriteLine("Gravity on Mercury is " + gravitational_acceleration * 9.8);
            }

            else
            {
                Console.WriteLine("Planet " + Name + " has no gravity");

            }

        }



        public override double CalculateMagneticFieldStrength()
        {


            double strength = gravitational_acceleration * 9.8 / 2;

            Console.WriteLine("The magnetic field strength of " + Name + " is " + strength);

            return strength;




        }



        public override void HasWater()
        {
            Console.WriteLine("This planet has water ! ");
        }
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ JUPITER @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    class Jupiter : PlanetBluePrint,IObserver,PlanetInformation
    {
        public string Name { get; set; }  // property

        public int Distancefromsun { get; set; }  // property

        public int Size { get; set; }  // property


        public int Temperature { get; set; }  // property

        public int Windspeed { get; set; }  // property



        public Jupiter(String name, int distancefromsun, int size, int temperature, int windspeed) : base(distancefromsun, size, temperature, windspeed)

        {
            Name = name;

            Distancefromsun = distancefromsun;

            Size = size;

            Temperature = temperature;

            Windspeed = windspeed;



        }

        // implement observer interface
        public void Update(ISubject subject)
        {
            // read the gracvity value from the subject passed as argument


            // cast the subject in galaxy type 


            if (subject is Star mystar
                ) // if subject is type of Galaxy
            {

                Console.WriteLine("Planet's " + Name + " star is alive ? " + mystar.isalive);

                if (!mystar.isalive)
                {

                    Console.WriteLine("All the life is dead");
                    // adauga implementare mai buna
                }

                else
                {

                    Console.WriteLine("Everything is ok ! ");

                }


            }



        }

        public void DisplayInformation()
        {
            Console.WriteLine("Infomation -- >" + "Planet name " + Name + "\n" + "Planet distance from sun " + Distancefromsun + "\n" + "Planet size " + Size + "\n" + "Planet temperature " + Temperature + "\n" + "Planet windspeed " + Windspeed);
        }



        
        
        
        // --------------------------------------------------------------------- ABSTRACT  METHODS IMPLEMENTATION -----------------------------------------------------------------------------------------------------------------------------------------



        public override void createPlanet()
        {
            Console.WriteLine("\n" + "This is the planet " + Name + "\n");

            Console.WriteLine(@"

        _____
    ,-:` \;',`'-, 
  .'-;_,;  ':-;_,'.
 /;   '/    ,  _`.-\
| '`. (`     /` ` \`|
|:.  `\`-.   \_   / |
|     (   `,  .`\ ;'|
 \     | .'     `-'/
  `.   ;/        .'
     `'-._____.

            ");
        }

       


        private double gravitational_acceleration = 2.7;

        bool myFlag = false;

        public override void HasSolidCore(ref bool flag)
        {
            flag = true;
        }

        public override void calculateGravity()
        {
            HasSolidCore(ref myFlag); // setting the core true for being solid 

            if (myFlag)
            {
                Console.WriteLine("Gravity on Mercury is " + gravitational_acceleration * 9.8);
            }

            else
            {
                Console.WriteLine("Planet " + Name + " has no gravity");

            }

        }



        public override double CalculateMagneticFieldStrength()
        {


            double strength = gravitational_acceleration * 9.8 / 2;

            Console.WriteLine("The magnetic field strength of " + Name + " is " + strength);

            return strength;




        }



        public override void HasWater()
        {
            Console.WriteLine("This planet does not have water ! ");
        }
    }




    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ SATURN @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    class Saturn : PlanetBluePrint, IObserver,PlanetInformation
    {
        public string Name { get; set; }  // property

        public int Distancefromsun { get; set; }  // property

        public int Size { get; set; }  // property


        public int Temperature { get; set; }  // property

        public int Windspeed { get; set; }  // property



        public Saturn(String name, int distancefromsun, int size, int temperature, int windspeed) : base(distancefromsun, size, temperature, windspeed)

        {
            Name = name;

            Distancefromsun = distancefromsun;

            Size = size;

            Temperature = temperature;

            Windspeed = windspeed;



        }

        // implement observer interface
        public void Update(ISubject subject)
        {
            // read the gracvity value from the subject passed as argument


            // cast the subject in galaxy type 


            if (subject is Star mystar
                ) // if subject is type of Galaxy
            {

                Console.WriteLine("Planet's " + Name + " star is alive ? " + mystar.isalive);

                if (!mystar.isalive)
                {

                    Console.WriteLine("All the life is dead");
                    // adauga implementare mai buna
                }

                else
                {

                    Console.WriteLine("Everything is ok ! ");

                }


            }



        }

        public void DisplayInformation()
        {
            Console.WriteLine("Infomation -- >" + "Planet name " + Name + "\n" + "Planet distance from sun " + Distancefromsun + "\n" + "Planet size " + Size + "\n" + "Planet temperature " + Temperature + "\n" + "Planet windspeed " + Windspeed);
        }


        // --------------------------------------------------------------------- ABSTRACT  METHODS IMPLEMENTATION -----------------------------------------------------------------------------------------------------------------------------------------


        public override void createPlanet()
        {
            Console.WriteLine("\n" + "This is the planet " + Name + "\n");

            Console.WriteLine(@"

                                                                    ..;===+.
                                                                .:=iiiiii=+=
                                                             .=i))=;::+)i=+,
                                                          ,=i);)I)))I):=i=;
                                                       .=i==))))ii)))I:i++
                                                     +)+))iiiiiiii))I=i+:'
                                .,:;;++++++;:,.       )iii+:::;iii))+i='
                             .:;++=iiiiiiiiii=++;.    =::,,,:::=i));=+'
                           ,;+==ii)))))))))))ii==+;,      ,,,:=i))+=:
                         ,;+=ii))))))IIIIII))))ii===;.    ,,:=i)=i+
                        ;+=ii)))IIIIITIIIIII))))iiii=+,   ,:=));=,
                      ,+=i))IIIIIITTTTTITIIIIII)))I)i=+,,:+i)=i+
                     ,+i))IIIIIITTTTTTTTTTTTI))IIII))i=::i))i='
                    ,=i))IIIIITLLTTTTTTTTTTIITTTTIII)+;+i)+i`
                    =i))IIITTLTLTTTTTTTTTIITTLLTTTII+:i)ii:'
                   +i))IITTTLLLTTTTTTTTTTTTLLLTTTT+:i)))=,
                   =))ITTTTTTTTTTTLTTTTTTLLLLLLTi:=)IIiii;
                  .i)IIITTTTTTTTLTTTITLLLLLLLT);=)I)))))i;
                  :))IIITTTTTLTTTTTTLLHLLLLL);=)II)IIIIi=:
                  :i)IIITTTTTTTTTLLLHLLHLL)+=)II)ITTTI)i=
                  .i)IIITTTTITTLLLHHLLLL);=)II)ITTTTII)i+
                  =i)IIIIIITTLLLLLLHLL=:i)II)TTTTTTIII)i'
                +i)i)))IITTLLLLLLLLT=:i)II)TTTTLTTIII)i;
              +ii)i:)IITTLLTLLLLT=;+i)I)ITTTTLTTTII))i;
             =;)i=:,=)ITTTTLTTI=:i))I)TTTLLLTTTTTII)i;
           +i)ii::,  +)IIITI+:+i)I))TTTTLLTTTTTII))=,
         :=;)i=:,,    ,i++::i))I)ITTTTTTTTTTIIII)=+'
       .+ii)i=::,,   ,,::=i)))iIITTTTTTTTIIIII)=+
      ,==)ii=;:,,,,:::=ii)i)iIIIITIIITIIII))i+:'
     +=:))i==;:::;=iii)+)=  `:i)))IIIII)ii+'
   .+=:))iiiiiiii)))+ii;
  .+=;))iiiiii)));ii+
 .+=i:)))))))=+ii+
.;==i+::::=)i=;
,+==iiiiii+,
`+=+++;`

            ");
        }


        


        private double gravitational_acceleration = 2.1;

        bool myFlag = false;

        public override void HasSolidCore(ref bool flag)
        {
            flag = true;
        }

        public override void calculateGravity()
        {
            HasSolidCore(ref myFlag); // setting the core true for being solid 

            if (myFlag)
            {
                Console.WriteLine("Gravity on Mercury is " + gravitational_acceleration * 9.8);
            }

            else
            {
                Console.WriteLine("Planet " + Name + " has no gravity");

            }

        }



        public override double CalculateMagneticFieldStrength()
        {


            double strength = gravitational_acceleration * 9.8 / 2;

            Console.WriteLine("The magnetic field strength of " + Name + " is " + strength);

            return strength;




        }



        public override void HasWater()
        {
            Console.WriteLine("This planet does not have water ! ");
        }
    }


    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ URANUS @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    class Uranus : PlanetBluePrint, IObserver,PlanetInformation
    {
        public string Name { get; set; }  // property

        public int Distancefromsun { get; set; }  // property

        public int Size { get; set; }  // property


        public int Temperature { get; set; }  // property

        public int Windspeed { get; set; }  // property



        public Uranus(String name, int distancefromsun, int size, int temperature, int windspeed) : base(distancefromsun, size, temperature, windspeed)

        {
            Name = name;

            Distancefromsun = distancefromsun;

            Size = size;

            Temperature = temperature;

            Windspeed = windspeed;



        }

        // implement observer interface
        public void Update(ISubject subject)
        {
            // read the gracvity value from the subject passed as argument


            // cast the subject in galaxy type 


            if (subject is Star mystar
                ) // if subject is type of Galaxy
            {

                Console.WriteLine("Planet's " + Name + " star is alive ? " + mystar.isalive);

                if (!mystar.isalive)
                {

                    Console.WriteLine("All the life is dead");
                    // adauga implementare mai buna
                }

                else
                {

                    Console.WriteLine("Everything is ok ! ");

                }


            }



        }

        public void DisplayInformation()
        {
            Console.WriteLine("Infomation -- >" + "Planet name " + Name + "\n" + "Planet distance from sun " + Distancefromsun + "\n" + "Planet size " + Size + "\n" + "Planet temperature " + Temperature + "\n" + "Planet windspeed " + Windspeed);
        }



        // --------------------------------------------------------------------- ABSTRACT  METHODS IMPLEMENTATION -----------------------------------------------------------------------------------------------------------------------------------------




        public override void createPlanet()
        {
            Console.WriteLine("\n" + "This is the planet " + Name + "\n");

            Console.WriteLine(@"

                                        
                 .        ___---___                    .                   
       .              .--\        --.     .  
                    ./.;_.\     __/~ \.     
                   /;  / `-'  __\    . \                            
 .        .       / ,--'     / .   .;   \      
                 | .|       /       __   |     
                |__/    __ |  . ;   \ | . |      
                |      /  \\_    . ;| \___|    
   .    o       |      \  .~\\___,--'     |       
                 |     | . ; ~~~~\_    __|
    |             \    \   .  .  ; \  /_/   
               .    \   /         . |  ~/               
    |    .          ~\ \   .      /  /~         
  .                   ~--___ ; ___--~       
                 .          ---                  

            ");
        }


        private double gravitational_acceleration = 1.2;

        bool myFlag = false;

        public override void HasSolidCore(ref bool flag)
        {
            flag = false;
        }

        public override void calculateGravity()
        {
            HasSolidCore(ref myFlag); // setting the core true for being solid 

            if (myFlag)
            {
                Console.WriteLine("Gravity on Mercury is " + gravitational_acceleration * 9.8);
            }

            else
            {
                Console.WriteLine("Planet " + Name + " has no gravity");

            }

        }



        public override double CalculateMagneticFieldStrength()
        {


            double strength = gravitational_acceleration * 9.8 / 2;

            Console.WriteLine("The magnetic field strength of " + Name + " is " + strength);

            return strength;




        }



        public override void HasWater()
        {
            Console.WriteLine("This planet does not have water ! ");
        }
    }
    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ NEPTUNE @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    class Neptune : PlanetBluePrint, IObserver,PlanetInformation
    {
        public string Name { get; set; }  // property

        public int Distancefromsun { get; set; }  // property

        public int Size { get; set; }  // property


        public int Temperature { get; set; }  // property

        public int Windspeed { get; set; }  // property



        public Neptune(String name, int distancefromsun, int size, int temperature, int windspeed) : base(distancefromsun, size, temperature, windspeed)

        {
            Name = name;

            Distancefromsun = distancefromsun;

            Size = size;

            Temperature = temperature;

            Windspeed = windspeed;



        }

        // implement observer interface
        public void Update(ISubject subject)
        {
            // read the gracvity value from the subject passed as argument


            // cast the subject in galaxy type 


            if (subject is Star mystar
                ) // if subject is type of Galaxy
            {

                Console.WriteLine("Planet's " + Name + " star is alive ? " + mystar.isalive);

                if (!mystar.isalive)
                {

                    Console.WriteLine("All the life is dead");
                    // adauga implementare mai buna
                }

                else
                {

                    Console.WriteLine("Everything is ok ! ");

                }


            }



        }

        public void DisplayInformation()
        {
            Console.WriteLine("Infomation -- >" + "Planet name " + Name + "\n" + "Planet distance from sun " + Distancefromsun + "\n" + "Planet size " + Size + "\n" + "Planet temperature " + Temperature + "\n" + "Planet windspeed " + Windspeed);
        }


        // --------------------------------------------------------------------- ABSTRACT  METHODS IMPLEMENTATION -----------------------------------------------------------------------------------------------------------------------------------------


        public override void createPlanet()
        {
            Console.WriteLine("\n"+ "This is the planet " + Name + "\n");

            Console.WriteLine(@"

                                        
           ,dP9CGG88@b,
        ,IP""""YICCG888@@b,
         dIi   ,IICGG8888@b
        dCIIiciIICCGG8888@@b
        GCCIIIICCCGGG8888@@@
        GGCCCCCCCGGG88888@@@
        GGGGCCCGGGG88888@@@@
        Y8GGGGGG8888888@@@@P
         @@8888888@@@@@@@P'
          @@@@@@@@@@@@P'
             


            ");
        }




        private double gravitational_acceleration = 6.7;

        bool myFlag = false;

        public override void HasSolidCore(ref bool flag)
        {
            flag = true;
        }

        public override void calculateGravity()
        {
            HasSolidCore(ref myFlag); // setting the core true for being solid 

            if (myFlag)
            {
                Console.WriteLine("Gravity on Mercury is " + gravitational_acceleration * 9.8);
            }

            else
            {
                Console.WriteLine("Planet " + Name + " has no gravity");

            }

        }



        public override double CalculateMagneticFieldStrength()
        {


            double strength = gravitational_acceleration * 9.8 / 2;

            Console.WriteLine("The magnetic field strength of " + Name + " is " + strength);

            return strength;




        }



        public override void HasWater()
        {
            Console.WriteLine("This planet does not have water ! ");
        }
    }

    class Test
    {

        static void Main(string[] args)
        {
            
            
            
            // create an OBSERVABLE star 

            Star mystar = new Star();


            // create one instance for every planet 

            Mercury mercury = new Mercury("Mercury", 1, 33541234, 80, 35); 

            Venus venus = new Venus("Venusss", 2, 33541234, 300, 700);

            Earth myearth = new Earth("Earth", 3, 335241234, 28, 35);

            Mars mars = new Mars("Mars", 4, 1541234, 4, 20);

            Jupiter jupiter = new Jupiter("Jupiter", 5, 211234, 28, 60);

            Saturn saturn = new Saturn("Saturn", 6, 111541234, 0, 100);

            Uranus uranus = new Uranus("Uranus", 7, 2241234, 4, 421);

            Neptune neptune = new Neptune("Neptune", 8, 4541234, 1, 321);

           
            
            // lets add them in an array list to use it later 

            ArrayList myplanets = new ArrayList();

            myplanets.Add(mercury);
            myplanets.Add(venus);
            myplanets.Add(myearth);
            myplanets.Add(mars);
            myplanets.Add(jupiter);
            myplanets.Add(saturn);
            myplanets.Add(uranus);
            myplanets.Add(neptune);




            // adding the observers to observable star 

            mystar.Attach(mercury);
            mystar.Attach(venus);
            mystar.Attach(myearth);
            mystar.Attach(mars);
            mystar.Attach(jupiter);
            mystar.Attach(saturn);
            mystar.Attach(uranus);
            mystar.Attach(neptune);

            


            int input = 0;

            try
            {

                while (input != 5)
                {


                    Console.WriteLine(" \n#########  MENU  ###############");
                    Console.WriteLine("\n1 to check what is our galaxy   \n2 to see what planets are in our galaxy\n3 Activate / Dezactivate the Star \n4 to get information about a specific planet \n5 to Quit");
                    Console.WriteLine(" \n################################ ");

                    input = Convert.ToInt32(Console.ReadLine());

                    if (input >= 0 && input <= 5)
                    {
                        switch (input)
                        {

                            case 1:

                                // we use the Instance method to create the unique instance of Galaxy 

                                Galaxy mygalaxy = Galaxy.Instance;
                               
                                // we simply call its method 

                                mygalaxy.GalaxyName();


                                break;

                            case 2:


                                // iterate over the arraylist and call method for all members 

                                foreach (PlanetBluePrint item in myplanets)
                                {
                                    // ! foreach statement helps us to evidenciate how the type of our planets is parent class type "PlanetBluePrint"


                                    item.createPlanet();


                                }



                                break;

                            case 3:

                                int input2 = 0;

                                try
                                {

                                    while (input2 != 3)
                                    {
                                        Console.WriteLine("\n1 to dezactivate the Star   \n2 to activate it back \n3 GO BACK ");
                                        Console.WriteLine(" \n################################ ");

                                        input2 = Convert.ToInt32(Console.ReadLine());

                                        if (input2 >= 0 && input2 <= 3)
                                        {

                                            switch (input2)
                                            {

                                                case 1:



                                                    mystar.Isalive = false;
                                                    break;


                                                case 2:
                                                    mystar.Isalive = true;
                                                    break;

                                                case 3:

                                                    break;

                                                default:
                                                    Console.WriteLine(" Invalid choice ! ");
                                                    break;
                                            }
                                        }
                                        else
                                        {

                                            Console.WriteLine("No valid input! ");

                                        }
                                    }

                                    Console.ReadLine();
                                }

                                catch (Exception ExP)
                                {
                                    Console.WriteLine(ExP.Message);
                                }



                                break;

                            case 4:

                                int input3 = 0;

                                try
                                {
                                    while(input3 !=9)
                                    {
                                        Console.WriteLine(" \n################################ ");
                                        Console.WriteLine(" \n Get information : ");
                                        Console.WriteLine("\n1 for Mercury   \n2 for Venus \n3 for Earth  \n4 for Mars  \n5 for Jupiter  \n6 for Saturn  \n7 for Uranus  \n8 for Neptune  \n9 GO BACK    ");
                                        Console.WriteLine(" \n################################ ");

                                        input3 = Convert.ToInt32(Console.ReadLine());

                                        if (input3 >= 0 && input3 <= 9)

                                            switch (input3)
                                        {

                                            case 1:
                                                    int input4 = 0;

                                                    try
                                                    {
                                                        while (input4 != 6)
                                                        {

                                                            Console.WriteLine(" \n################################ ");
                                                            Console.WriteLine(" \n Get information : ");
                                                            Console.WriteLine("\n1 to show planet   \n2 to calculate gravity\n3 to calculate magnetic field  \n4 to see if the planet has water  \n5 to display planet information  \n6 GO BACK    ");
                                                            Console.WriteLine(" \n################################ ");
                                                            input4 = Convert.ToInt32(Console.ReadLine());

                                                            if (input4 >= 0 && input4 <= 6)

                                                                switch (input4)
                                                                {

                                                                    case 1:
                                                                        mercury.createPlanet();

                                                                        break;
                                                                    case 2:
                                                                        mercury.calculateGravity();
                                                                        break;
                                                                    case 3:
                                                                        mercury.CalculateMagneticFieldStrength();
                                                                        break;
                                                                    case 4:
                                                                        mercury.HasWater();
                                                                        break;
                                                                    case 5:
                                                                        mercury.DisplayInformation();
                                                                        break;
                                                                    case 6:
                                                                        break;

                                                                    default:
                                                                        Console.WriteLine(" Invalid choice ! ");
                                                                        break;





                                                                }
                                                        }

                                                        Console.ReadLine();
                                                    }

                                                    catch(Exception ExP)
                                                    {
                                                        Console.WriteLine(ExP.Message);

                                                    }

                                                    break;



                                                    

                                            case 2:

                                                    int input5 = 0;

                                                    try
                                                    {
                                                        while (input5 != 6)
                                                        {

                                                            Console.WriteLine(" \n################################ ");
                                                            Console.WriteLine(" \n Get information : ");
                                                            Console.WriteLine("\n1 to show planet   \n2 to calculate gravity\n3 to calculate magnetic field  \n4 to see if the planet has water  \n5 to display planet information  \n6 GO BACK    ");
                                                            Console.WriteLine(" \n################################ ");
                                                            input5 = Convert.ToInt32(Console.ReadLine());

                                                            if (input5 >= 0 && input5 <= 6)

                                                                switch (input5)
                                                                {

                                                                    case 1:
                                                                        venus.createPlanet();

                                                                        break;
                                                                    case 2:
                                                                        venus.calculateGravity();
                                                                        break;
                                                                    case 3:
                                                                        venus.CalculateMagneticFieldStrength();
                                                                        break;
                                                                    case 4:
                                                                        venus.HasWater();
                                                                        break;
                                                                    case 5:
                                                                        venus.DisplayInformation();
                                                                        break;
                                                                    case 6:
                                                                        break;

                                                                    default:
                                                                        Console.WriteLine(" Invalid choice ! ");
                                                                        break;






                                                                }
                                                        }

                                                        Console.ReadLine();
                                                    }

                                                    catch (Exception ExP)
                                                    {
                                                        Console.WriteLine(ExP.Message);

                                                    }

                                                    break;
                                            case 3:

                                                    int input6 = 0;

                                                    try
                                                    {
                                                       


                                                        while (input6 != 6)

                                                           

                                                        {

                                                            Console.WriteLine(" \n################################ ");
                                                            Console.WriteLine(" \n Get information : ");
                                                            Console.WriteLine("\n1 to show planet   \n2 to calculate gravity\n3 to calculate magnetic field  \n4 to see if the planet has water  \n5 to display information about the planet  \n6 to show life form name  \n7 to show DNA sample  \n8 GO to show life form language     \n9 GO BACK    ");
                                                            input6 = Convert.ToInt32(Console.ReadLine());

                                                            if (input6 >= 0 && input6 <= 9)

                                                                


                                                            switch (input6)
                                                                {






                                                                    case 1:
                                                                        myearth.createPlanet();

                                                                        break;
                                                                    case 2:
                                                                        myearth.calculateGravity();
                                                                        break;
                                                                    case 3:
                                                                        myearth.CalculateMagneticFieldStrength();
                                                                        break;
                                                                    case 4:
                                                                        myearth.HasWater();
                                                                        break;
                                                                    case 5:
                                                                        myearth.DisplayInformation();
                                                                        break;

                                                                    case 6:
                                                                        myearth.ShowLifeFormName();
                                                                        break;
                                                                    case 7:
                                                                        myearth.ShowADN();
                                                                        break;
                                                                    case 8:
                                                                        myearth.ShowLanguageSample();
                                                                        break;
                                                                    case 9:
                                                                        break;

                                                                    default:
                                                                        Console.WriteLine(" Invalid choice ! ");
                                                                        break;


                                                                }
                                                        }

                                                        Console.ReadLine();
                                                    }

                                                    catch (Exception ExP)
                                                    {
                                                        Console.WriteLine(ExP.Message);

                                                    }
                                                    break;

                                            case 4:

                                                    int input7 = 0;

                                                    try
                                                    {


                                                        while (input7 != 6)
                                                        {

                                                            Console.WriteLine(" \n################################ ");
                                                            Console.WriteLine(" \n Get information : ");
                                                            Console.WriteLine("\n1 to show planet   \n2 to calculate gravity\n3 to calculate magnetic field  \n4 to see if the planet has water  \n5 to display information about the planet  \n6 to show life form name  \n7 to show DNA sample  \n8 GO to show life form language     \n9 GO BACK    ");
                                                            Console.WriteLine(" \n################################ ");
                                                            input7 = Convert.ToInt32(Console.ReadLine());

                                                            if (input7 >= 0 && input7 <= 9)

                                                                switch (input7)
                                                                {

                                                                    case 1:
                                                                        mars.createPlanet();

                                                                        break;
                                                                    case 2:
                                                                        mars.calculateGravity();
                                                                        break;
                                                                    case 3:
                                                                        mars.CalculateMagneticFieldStrength();
                                                                        break;
                                                                    case 4:
                                                                        mars.HasWater();
                                                                        break;
                                                                    case 5:
                                                                        mars.DisplayInformation();
                                                                        break;

                                                                    case 6:
                                                                        mars.ShowLifeFormName();
                                                                        break;
                                                                    case 7:
                                                                        mars.ShowADN();
                                                                        break;
                                                                    case 8:
                                                                        mars.ShowLanguageSample();
                                                                        break;
                                                                    case 9:
                                                                        break;

                                                                    default:
                                                                        Console.WriteLine(" Invalid choice ! ");
                                                                        break;






                                                                }
                                                        }

                                                        Console.ReadLine();
                                                    }

                                                    catch (Exception ExP)
                                                    {
                                                        Console.WriteLine(ExP.Message);

                                                    }
                                                    break;
                                            case 5:

                                                    int input8 = 0;

                                                    try
                                                    {
                                                        while (input8 != 6)
                                                        {

                                                            Console.WriteLine(" \n################################ ");
                                                            Console.WriteLine(" \n Get information : ");
                                                            Console.WriteLine("\n1 to show planet   \n2 to calculate gravity\n3 to calculate magnetic field  \n4 to see if the planet has water  \n5 to display planet information  \n6 GO BACK    ");
                                                            Console.WriteLine(" \n################################ ");
                                                            input8 = Convert.ToInt32(Console.ReadLine());

                                                            if (input8 >= 0 && input8 <= 6)

                                                                switch (input8)
                                                                {

                                                                    case 1:
                                                                        jupiter.createPlanet();

                                                                        break;
                                                                    case 2:
                                                                        jupiter.calculateGravity();
                                                                        break;
                                                                    case 3:
                                                                        jupiter.CalculateMagneticFieldStrength();
                                                                        break;
                                                                    case 4:
                                                                        jupiter.HasWater();
                                                                        break;
                                                                    case 5:
                                                                        jupiter.DisplayInformation();
                                                                        break;
                                                                    case 6:
                                                                        break;

                                                                    default:
                                                                        Console.WriteLine(" Invalid choice ! ");
                                                                        break;





                                                                }
                                                        }

                                                        Console.ReadLine();
                                                    }

                                                    catch (Exception ExP)
                                                    {
                                                        Console.WriteLine(ExP.Message);

                                                    }
                                                    break;

                                            case 6:

                                                    int input9 = 0;

                                                    try
                                                    {
                                                        while (input9 != 6)
                                                        {

                                                            Console.WriteLine(" \n################################ ");
                                                            Console.WriteLine(" \n Get information : ");
                                                            Console.WriteLine("\n1 to show planet   \n2 to calculate gravity\n3 to calculate magnetic field  \n4 to see if the planet has water  \n 5 to display planet information  \n6 GO BACK    ");
                                                            Console.WriteLine(" \n################################ ");
                                                            input9 = Convert.ToInt32(Console.ReadLine());

                                                            if (input9 >= 0 && input9 <= 6)

                                                                switch (input9)
                                                                {

                                                                    case 1:
                                                                        saturn.createPlanet();

                                                                        break;
                                                                    case 2:
                                                                        saturn.calculateGravity();
                                                                        break;
                                                                    case 3:
                                                                        saturn.CalculateMagneticFieldStrength();
                                                                        break;
                                                                    case 4:
                                                                        saturn.HasWater();
                                                                        break;
                                                                    case 5:
                                                                        saturn.DisplayInformation();
                                                                        break;
                                                                    case 6:
                                                                        break;

                                                                    default:
                                                                        Console.WriteLine(" Invalid choice ! ");
                                                                        break;





                                                                }
                                                        }

                                                        Console.ReadLine();
                                                    }

                                                    catch (Exception ExP)
                                                    {
                                                        Console.WriteLine(ExP.Message);

                                                    }
                                                    break;
                                            case 7:

                                                    int input10 = 0;

                                                    try
                                                    {
                                                        while (input10 != 6)
                                                        {

                                                            Console.WriteLine(" \n################################ ");
                                                            Console.WriteLine(" \n Get information : ");
                                                            Console.WriteLine("\n1 to show planet   \n2 to calculate gravity\n3 to calculate magnetic field  \n4 to see if the planet has water  \n5 to display planet information  \n6 GO BACK    ");
                                                            Console.WriteLine(" \n################################ ");
                                                            input10 = Convert.ToInt32(Console.ReadLine());

                                                            if (input10 >= 0 && input10 <= 6)

                                                                switch (input10)
                                                                {

                                                                    case 1:
                                                                        uranus.createPlanet();

                                                                        break;
                                                                    case 2:
                                                                        uranus.calculateGravity();
                                                                        break;
                                                                    case 3:
                                                                        uranus.CalculateMagneticFieldStrength();
                                                                        break;
                                                                    case 4:
                                                                        uranus.HasWater();
                                                                        break;
                                                                    case 5:
                                                                        uranus.DisplayInformation();
                                                                        break;
                                                                    case 6:
                                                                        break;

                                                                    default:
                                                                        Console.WriteLine(" Invalid choice ! ");
                                                                        break;





                                                                }
                                                        }

                                                        Console.ReadLine();
                                                    }

                                                    catch (Exception ExP)
                                                    {
                                                        Console.WriteLine(ExP.Message);

                                                    }
                                                    break;

                                            case 8:

                                                    int input11 = 0;

                                                    try
                                                    {
                                                        while (input11 != 6)
                                                        {

                                                            Console.WriteLine(" \n################################ ");
                                                            Console.WriteLine(" \n Get information : ");
                                                            Console.WriteLine("\n1 to show planet   \n2 to calculate gravity\n3 to calculate magnetic field  \n4 to see if the planet has water  \n5 to display planet information  \n6 GO BACK    ");
                                                            Console.WriteLine(" \n################################ ");
                                                            input11 = Convert.ToInt32(Console.ReadLine());

                                                            if (input11 >= 0 && input11 <= 6)

                                                                switch (input11)
                                                                {

                                                                    case 1:
                                                                        neptune.createPlanet();

                                                                        break;
                                                                    case 2:
                                                                        neptune.calculateGravity();
                                                                        break;
                                                                    case 3:
                                                                        neptune.CalculateMagneticFieldStrength();
                                                                        break;
                                                                    case 4:
                                                                        neptune.HasWater();
                                                                        break;
                                                                    case 5:
                                                                        neptune.DisplayInformation();
                                                                        break;
                                                                    case 6:
                                                                        break;

                                                                    default:
                                                                        Console.WriteLine(" Invalid choice ! ");
                                                                        break;






                                                                }
                                                        }

                                                        Console.ReadLine();
                                                    }

                                                    catch (Exception ExP)
                                                    {
                                                        Console.WriteLine(ExP.Message);

                                                    }
                                                    break;




                                        }



                                    }

                                    Console.ReadLine();


                                }
                               
                                catch (Exception ExP)
                                {
                                    Console.WriteLine(ExP.Message);

                                }
                                
                                break;


                            case 5:
                               

                                
                                break;

                            default:
                                Console.WriteLine(" Invalid choice ! ");
                                break;

                        }

                    }

                    else
                    {

                        Console.WriteLine("No valid input! ");

                    }

                }

                Console.ReadLine();

            }

            catch (Exception ExP)
            {
                Console.WriteLine(ExP.Message);
            }



        }


    }








}


