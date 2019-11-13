using System;
using System.Data;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace taska_3
{
    public  partial class phone
    {
    public void Move()
        {
            Console.WriteLine( "I am Partial class" );
        }

    }

    public  partial class phone
    {


        public static string region;
        private int user_phone;
        private int user_age;
        private string user_name;
        private string user_code;


        public int User_phone {
            get { return user_phone; }
            set
            {
                if (1000000 <= value && value <= 9999999)
                {
                    user_phone = value;
                }
                else
                {
                    Console.WriteLine("Incorrect date");
                }
            }
        }

        public int User_age
        {
            get { return user_age; }
            set
            {
                if (16 <= value && value <= 80)
                {
                    user_age = value;
                }
                else if(value > 80)
                {
                    {
                        Console.WriteLine("People don't live that much ");
                    }
                }
                else if (16 < value)
                {
                    Console.WriteLine("Школьникам тут не место ");
                }
            }

        }

        public string User_code
        {
            get { return User_code; }

            set
            {

                if ((value[0] != '+')&&(value.Length != 6))
                {
                    Console.WriteLine("Incorrect date");
                }
                else
                {
                    user_code = value;
                }
            }
        }

        public string User_name
        {
            get { return user_name;}
            set
            {
                int size_of_name = value.Length;
                for(int i=0; i<size_of_name;i++)
                {
                    if (value[i] == '0' && value[i] == '1' && value[i] == '2' && value[i] == '3' &&
                        value[i] == '4' && value[i] == '5' && value[i] == '6' && value[i] == '7' &&
                        value[i] == '8' && value[i] == '9')
                    {
                        Console.WriteLine("Incorrect date");
                        return;

                    }
                    
                }
                user_name = value;
                    
            }
        }
        static phone()
        {
            region = "Belarus";
        }


       public phone() {
            User_phone = 2471422;
            User_name = "Dima";
            User_age = 19;
            User_code = "+37529";
       }

       public phone(string user_code, int user_phone, string user_name, int user_age)
       {
           User_phone = user_phone;
           User_name = user_name;
           User_age = user_age;
           User_code = user_code;
       }



       public phone(phone user)
       {
           this.User_phone = user.User_phone;
           this.User_name = user.User_name;
           this.User_age = user.User_age;
       }

       public override bool Equals(object obj) //переопределили метод  Equals
       {
           if (obj == null)
               return false;

           if (obj.GetType() != this.GetType())
               return false;


           phone user = (phone) obj;

           return (
               user_age == user.user_age
               && user_name == user.user_name
               && user_phone == user.user_phone
               && user_code == user.user_code
           );
       }


       public override string ToString()//переопределили метод ToString
        {//Метод ToString служит для получения строкового представления данного объекта.
            return "Type : " 
                + base.ToString()
                + " Name: "
                + user_name
                + "; Number phone: "
                + user_code
                + user_phone
                + "; Location: " 
                + region
                +"; Age: "
                + user_age+" ;";
        }



        public override int GetHashCode()//переопределили метод GetHashCode
        {
            // 269 или 47 простые
            int hash = 269;
            hash = string.IsNullOrEmpty(User_name) ? 0 :User_name.GetHashCode();
            hash = (hash * 47) + User_phone.GetHashCode();
            return hash;
        }

       
        public static void print_my_date(phone user) 
        {
            Console.WriteLine($"User Name : {user.User_name}\n" +
                $"User Age : {user.User_age} \n" +
                $"User Number Phone :{user.user_code}{user.User_phone}\n" +
                $"User Locathion : {phone.region}");

        }
        



        public int my_Fun(ref int number1, int number2, out int res)
        {
            res = number1 + number2 + 55;
            return number1 += number2;
        }

         ~phone () {
                    Console.WriteLine("Destructor");
         }
        

    }

    public static class Info_phone
    {
       public static void info_phone(phone inf)
        {
            Console.WriteLine( inf.ToString());
        }
    }

    public class MyList
    {
        private phone[] all_users;
        private int counter;

        public MyList()
        {
            all_users = new phone[0];
        }

        public void Add(phone user)//добавляем элемент в коллекцию
        {
            Array.Resize(ref all_users, all_users.Length + 1);//увеличиваем массив и записываем в него

            all_users[counter] = user;
            counter++;
        }
        public void delete()//удаление элементов коллекции через уменьшение массива
        {
            if (counter != 0)
            {
                Array.Resize(ref all_users, all_users.Length - 1);
                counter--;
            }
        }
        public int Find(phone user)//поиск элементов коллекции через прагон массива
        {
            for (int i = 0; i < counter; i++)
            {
                if (user == all_users[i])
                {
                    return i + 1;
                }
            }

            return -1 ;//если не нашли элемент
        }

        public int count_elem()//выводим количество обьектов в коллекции
        {
            return all_users.Length;
        }

        public void WriteAll()//читаем всю коллекцию и выводим её
        {
            for (int i = 0; i < all_users.Length; i++)
            {
                Console.WriteLine(all_users[i].ToString() + "");
            }
        }

       

    }




    class Program
    {
        static void Main(string[] args)
        {
            int choise;
            int counter;
            MyList all_users = new MyList();
            
            int counter_of_users=0;
            while (true)
            {
                Console.WriteLine("Введите 1 ,если хотите создать пользователя \n" +
                                  "Введите 2 ,если хотите удалить последнего пользователея\n" +
                                  "Введите 3 ,если хотите вывести информацию о всех пользователей \n" +
                                  "Введите 4 ,если хотите вывести колличество пользователей в базе\n" +
                                  "Введите 5 ,если хотите проверить ,существует ли введеный пользователь в базе\n" +
                                  "Введите 666 для успешного выхода из программы"
                                  );
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                { 

                   case 1:

                       Console.WriteLine("Введите 1 , если хотите заполнить по умолчанию\n" +
                                         "Введите 2 , если хотите заполнить поля сами");

                       phone user = new phone(); 

                       choise = Convert.ToInt32(Console.ReadLine());


                       switch (choise)
                       {
                            case 1:
                                all_users.Add(user);
                                break;
                            case 2:
                                Console.WriteLine("Введите возраст пользователя:");
                                user.User_age= Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Введите имя пользователя:");
                                user.User_name=Console.ReadLine();

                                Console.WriteLine("Введите код региона пользователя:");
                                user.User_code=Console.ReadLine();

                                Console.WriteLine("Введите номер телефона пользователя:");
                                user.User_phone= Convert.ToInt32(Console.ReadLine());
                                all_users.Add(user);
                                ;
                                break;
                       };
                       break;
                  case 2 :
                      all_users.delete();
                      ;
                      break; 
                   case 3 :
                       all_users.WriteAll();
                       ;break;
                   case 4: all_users.count_elem();
                       break;
                   case 5:

                       phone user_for_find = new phone();

                       Console.WriteLine("Введите возраст пользователя:");
                       user_for_find.User_age = Convert.ToInt32(Console.ReadLine());

                       Console.WriteLine("Введите имя пользователя:");
                       user_for_find.User_name = Console.ReadLine();

                       Console.WriteLine("Введите код региона пользователя:");
                       user_for_find.User_code = Console.ReadLine();

                       Console.WriteLine("Введите номер телефона пользователя:");
                       user_for_find.User_phone = Convert.ToInt32(Console.ReadLine());

                       switch (all_users.Find(user_for_find))
                       {
                            case -1: Console.WriteLine("Такого пользователя нет в базе.");break;
                            default: Console.WriteLine($"Номер данного пользователя :{all_users.Find(user_for_find)}");break;
                                
                       };
                       break;
            
                  case 666:
                      break; 
                      
                }
                //break;
            }

        }
    }
}

//1
//основанная на представлении программы в виде совокупности объектов,
//каждый из которых является экземпляром определённого класса,
//а классы образуют иерархию наследования.

//абстракция-это придание объекту харрактеристик котрые будут отличать его от всех других обектов

//Инкапсуляия -запрещение юзеру на прямую взаимодействовать с полями нашего класса 

//наследование - это создание ного класса на основе уже существующего
//(при наследованиипри этом свойства и функциональность родительского класса заимствуются новым классом.)

//Полиморфизм -возможность объектов с одинаковой спецификацией иметь различную реализацию 
