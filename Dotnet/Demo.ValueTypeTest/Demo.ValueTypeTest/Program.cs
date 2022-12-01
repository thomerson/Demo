using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ValueTypeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 值传递
            int a = 1;
            int b = a;
            b = 0;
            Console.WriteLine($"a:{a}"); //1

            Person person1 = new Person() { Id = 1, Name = "Jack" };
            Person person2 = person1;

            person2.Id = 2;
            person2.Name = "Tom";
            Console.WriteLine($"person1.Id:{person1.Id},name:{person1.Name}"); //2,Tom

            string sta = "a";
            string stb = sta;
            stb = "b";
            Console.WriteLine($"sta:{sta}"); //a


            // 引用传递

            // out
            int cc = 1;
            ValueOutTest(out cc);
            Console.WriteLine($"cc:{cc}"); //2

            Person person = new Person() { Id = 1, Name = "Jack" };
            ObjectOutTest(out person);
            Console.WriteLine($"person.Id:{person1.Id},name:{person1.Name}"); //2,Tom

            string st = "1";
            StringOutTest(out st);
            Console.WriteLine($"st:{st}"); //2

            // ref
            int c = 1;
            RefTest(ref c);
            Console.WriteLine($"c:{c}"); //2

            person = new Person() { Id = 1, Name = "Jack" };
            RefTest(ref person);
            Console.WriteLine($"person.Id:{person1.Id},name:{person1.Name}"); //2,Tom


            string stt = "1";
            StringOutTest(out stt);
            Console.WriteLine($"stt:{stt}"); //2


            Console.ReadLine();

        }


        static void ValueOutTest(out int a)
        {
            //离开当前方法之前必须对 out 参数赋值
            a = 2;
        }

        static void StringOutTest(out string a)
        {
            //离开当前方法之前必须对 out 参数赋值
            a = "2";
        }

        static void ObjectOutTest(out Person person)
        {
            person = new Person()
            {
                Id = 2,
                Name = "Tom"
            };
        }

        static void RefTest(ref int a)
        {
            a = 2;
        }


        static void RefTest(ref Person person)
        {
            person.Id = 2;
            person.Name = "Tom";
        }
        static void RefTest(ref string str)
        {
            str = "2";
        }

    }

    class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
