using System;

namespace _06.OopAccessModifiers
{

    class Cat
    {
        //public is the most accessible form all classes , from everithere
        public string name;  //accessible at any class level
    }
    internal class Mammal  //internal --accessible only in the currenassembly - ie the project ;
    {
        //protected int age; //member is accesible at the Parent class and all child classes
    }

    class Person : Mammal
    {
        public const int MinAge = 0;
        public const int MaxAge = 200;

        private string name;  //accessible at the class level itself only
        protected int age;

        public Person(string name, int age)
        {
            this.Name = name;// this referes the object over which the method is called /this refers to the curr instance
            this.Age = age;   //this is used into the constructor too!! t refees to the class, the object,field,property
            Console.WriteLine(this.Name);
        }

        public int Useless 
        {
            get 
            {
                return -1;
            }
        }

        public string NameAndAge 
        {
            get 
            {
                return this.Name + " " + this.Age;
            }
        }

        public int Age   // We use property to make some check,, to make some validation, its a wrapper for variables
        {
            get //property read only, only we can receive the value,Examople--the lenght of teh array is read-only 
            {
                return this.age;
            }
            set  //write only property, to put some value//for passwords, to write only , not to read, we cant read others paawords
            {
                int newAge = value;
                if (newAge < MinAge || newAge > MaxAge)
                {
                    throw new ArgumentOutOfRangeException("The value must be between 0 and 200 ");
                }
                this.age = value;
            }

        }

        public string Name    // We use properties to make some check, to make some validation
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length >= 3 && value.Length <= 15)
                {
                    this.name = value;
                }
            }
        }

        public void Introduce()
        {
            string name = "Drugi ime";
            Console.WriteLine("Hello! , my name is {0} and i am {1}-years-old.",
                               this.name, this.age);
            //this improves code readability and prevents mistakes, this referes to the object ! 
        }

    }

    class Program  // we use classes to create an instance of the class call Object and to give him functionallity //
    {                // We have to define the class and his members , and their level of access;
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person("Person # " + (i + 1), (i + 10) % Person.MaxAge);
            }
            //foreach (Person person in people)
            //{
            //    person.Introduce();
            //}
            Console.WriteLine(people[0].Useless); 
            Console.WriteLine(people[0].NameAndAge);

        }
    }
}



