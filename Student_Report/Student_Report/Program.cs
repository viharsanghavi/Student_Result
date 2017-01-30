using System;


namespace Student_Report
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student[] s=new Student[100];
                int len = 0;
                String temp1;
                char c='Y';
                do
                {
                    s[len] = new Student();
                    Console.WriteLine("Enter Student details:  ");
                    again:
                    Console.Write("Enter Roll no: ");
                    temp1 = Console.ReadLine();
                    if(IsDigitsOnly(temp1)==false)
                    {
                        Console.WriteLine("Roll number should contains only digits. ");
                        goto again;
                    }
                    s[len].Roll_no = Convert.ToInt32(temp1);
                    for(int i=0;i<len;i++)
                    {
                        if(s[i].Roll_no==s[len].Roll_no)
                        {
                            Console.WriteLine("Role number is already exists.");
                            goto again;
                        }
                    }
                    againN:
                    Console.Write("Enter Name: ");
                    s[len].Name = Console.ReadLine();
                    if(containsDigit(s[len].Name)==true)
                    {
                        Console.WriteLine("Name should contains only characters.");
                        goto againN;
                    }

                    for (int j = 0; j < 3; j++)
                    {
                        againM:
                        Console.Write("Enter mark for subject " + (j + 1) + " out of 100: ");
                        temp1 = Console.ReadLine();
                        if(IsDigitsOnly(temp1)==false)
                        {
                            Console.WriteLine("Marks should contains only digits.");
                            goto againM;
                        }
                        s[len].Marks[j] = Convert.ToInt32(temp1);
                        s[len].Total = s[len].Total + s[len].Marks[j];

                    }
                    s[len].Per = (float)s[len].Total / 3;
                    Console.Write("Do you want to add another student details(Y/N): ");
                    c = Convert.ToChar(Console.ReadLine());
                    len++;

                } while (c=='Y'|| c=='y');
                Console.WriteLine("\n--------------------Result---------------------");
                Console.WriteLine("Rank\tRollno\tName\tTotal\tPer");
                Student temp = new Student();
                for(int i=0;i<len;i++)
                {
                    for(int j=i+1;j<len;j++)
                    {
                        if(s[i].Total<s[j].Total)
                        {
                            temp = s[i];
                            s[i] = s[j];
                            s[j] = temp;
                        }
                    }
                }
                for (int i = 0; i < len; i++)
                {
                    Console.WriteLine("Rank "+(i + 1) + "\t" + s[i].Roll_no+ "\t"+s[i].Name+ "\t"+s[i].Total+ "\t"+s[i].Per );
                }


            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
               
            }
            Console.ReadKey();


        }
        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        static bool containsDigit(string str)
        {
            foreach (char c in str)
            {
                if (c >='0' && c <= '9')
                {
                    return true;
                }
                    
            }
            return false;
        }

    }
    class Student
    {
        private string name;
        private int roll_no;
        private int[] marks = new int[3];
        private int total=0;
        private float per;
        public int Roll_no
        {
            get { return roll_no; }
            set { roll_no = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
       
        public int[] Marks
        {
            get { return marks; }
            set { marks = (int[])value.Clone(); }
        }
        public int Total
        {
            get { return total; }
            set { total = value;}
        }
        public float Per
        {
            get { return per; }
            set { per = value; }
        }
      

    }
}
