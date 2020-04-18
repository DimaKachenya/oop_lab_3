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
    public partial class Phone
    {
        public void Move()
        {
            Console.WriteLine("I am Partial class");
        }
    }
    public partial class Phone
    {
        public static string region;
        private string userFhone;
        private int userAge;
        private string userName;
        private string userCode;
        public string UserFhone
        {
            get { return userFhone; }
            set//проверим сначало длину , а потом проверим каждый символ , является ли он цифрой 
            {
                if (value.Length == 7)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (!(value[i] == '0' || value[i] == '1' || value[i] == '2' || value[i] == '3' ||
                            value[i] == '4' || value[i] == '5' || value[i] == '6' || value[i] == '7' |
                            value[i] == '8' || value[i] == '9'))
                        {
                            Console.WriteLine("Incorrect date");
                            break;
                        }
                    }
                    userFhone = value;
                }
                else
                {
                    Console.WriteLine("Incorrect date");
                }
            }
        }
        public int UserAge
        {
            get { return userAge; }
            set//задаем возрастной диапазон от 16 до 80 лет.
            {
                if (16 <= value || value <= 80)
                {
                    userAge = value;
                }
                else if (value > 80)
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
        public string UserCode
        {
            get { return userCode; }
            set//проверяем , является ли первый элемент "+"и колличество цифр , потом проверяем являются ли цифры -цифрами
            {
                if ((value[0] == '+') && (value.Length == 6))
                {
                    for (int i = 1; i < 6; i++)
                    {
                        if (!(value[i] == '0' || value[i] == '1' || value[i] == '2' || value[i] == '3' ||
                              value[i] == '4' || value[i] == '5' || value[i] == '6' || value[i] == '7' |
                              value[i] == '8' || value[i] == '9'))
                        {
                            Console.WriteLine("Incorrect date");
                            break;
                        }

                    }
                    userCode = value;
                }
                else
                {
                    Console.WriteLine("Incorrect date");
                }
            }
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                int sizeOfName = value.Length;
                for (int i = 0; i < sizeOfName; i++)
                {
                    if (value[i] == '0' || value[i] == '1' || value[i] == '2' || value[i] == '3' ||
                        value[i] == '4' || value[i] == '5' || value[i] == '6' || value[i] == '7' |
                        value[i] == '8' || value[i] == '9')
                    {
                        Console.WriteLine("Incorrect date");
                        break;
                    }
                }
                userName = value;
            }
        }
        static Phone()
        {
            region = "Belarus";
        }
        public Phone()
        {
            userFhone = "2471422";
            userName = "Dima";
            userAge = 19;
            userCode = "+37529";
        }
        public Phone(string userCode, int userFhone, string userName, int userAge)
        {
            userFhone = userFhone;
            userName = userName;
            userAge = userAge;
            userCode = userCode;
        }
        public Phone(Phone user)
        {
            this.userFhone = user.userFhone;
            this.userName = user.userName;
            this.userAge = user.userAge;
        }
        public override bool Equals(object obj) //переопределили метод  Equals
        {
            if (obj == null)
                return false;

            if (obj.GetType() != this.GetType())
                return false;
            Phone user = (Phone)obj;
            return (
                userAge == user.userAge
                && userName == user.userName
                && userFhone == user.userFhone
                && userCode == user.userCode
            );
        }
        public override string ToString()//переопределили метод ToString
        {//Метод ToString служит для получения строкового представления данного объекта.
            return $"Type : {base.ToString()} \n" +
                   $"Name: {userName};\n" +
                   $" Number Phone:{userCode}{userFhone};\n" +
                   $" Location: {region};\n" +
                   $" Age: {userAge} ;\n";
        }
        public override int GetHashCode()//переопределили метод GetHashCode
        {
            // 269 или 47 простые
            int hash = 269;
            hash = string.IsNullOrEmpty(userName) ? 0 : userName.GetHashCode();
            hash = (hash * 47) + userFhone.GetHashCode();
            return hash;
        }
        public static void print_my_date(Phone user)
        {
            Console.WriteLine($"User Name : {user.userName}\n" +
                $"User Age : {user.userAge} \n" +
                $"User Number Phone :{user.userCode}{user.userFhone}\n" +
                $"User Locathion : {Phone.region}");
        }
        public int my_Fun(ref int number1, int number2, out int res)
        {
            res = number1 + number2 + 55;
            return number1 += number2;
        }
        ~Phone()
        {
            Console.WriteLine("Destructor");
        }
    }
    public static class Info_Phone
    {
        public static void info_Phone(Phone inf)
        {
            Console.WriteLine(inf.ToString());
        }
    }
    public class MyList
    {
        private List<Phone> allUsers = new List<Phone>();
        public void Add(Phone user)//добавляем элемент в коллекцию
        {
            allUsers.Add(user);

        }
        public void deleteAll()
        {
            for (int i = allUsers.Count - 1; i >= 0; i--)
            {
                allUsers.RemoveAt(i);
            }
        }
        public void dellUser(Phone user)
        {
            allUsers.Remove(user);
        }
        public void dellLast()
        {
            allUsers.RemoveAt(allUsers.Count - 1);
        }
        public int Find(Phone user)//поиск элементов коллекции через прагон массива
        {
            for (int i = 0; i < allUsers.Count; i++)
            {
                if (user.Equals(allUsers[i]))
                {
                    return i + 1;
                }
            }
            return -1;//если не нашли элемент
        }
        public int count_elem()//выводим количество обьектов в коллекции
        {
            return allUsers.Count;
        }
        public void WriteAll()//читаем всю коллекцию и выводим её
        {
            for (int i = 0; i < allUsers.Count; i++)
            {
                Console.WriteLine($"{allUsers[i].ToString()}  ");
            }
        }
    }
    class Program
    {
        static void createDate(MyList allUsers)
        {
            Phone user = new Phone();
            Console.WriteLine("Введите возраст пользователя:");
            user.UserAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите имя пользователя:");
            user.UserName = Console.ReadLine();

            Console.WriteLine("Введите код региона пользователя:");
            user.UserCode = Console.ReadLine();

            Console.WriteLine("Введите номер телефона пользователя:");
            user.UserFhone = Console.ReadLine();
            allUsers.Add(user);
        }
        static void findUser(MyList allUsers)
        {

            Phone userForFind = new Phone();

            Console.WriteLine("Введите возраст пользователя:");
            userForFind.UserAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите имя пользователя:");
            userForFind.UserName = Console.ReadLine();

            Console.WriteLine("Введите код региона пользователя:");
            userForFind.UserCode = Console.ReadLine();

            Console.WriteLine("Введите номер телефона пользователя:");
            userForFind.UserFhone = Console.ReadLine();

            allUsers.dellUser(userForFind);
        }
        private static void dellUser(MyList allUsers)
        {
            Phone userForFind = new Phone();

            Console.WriteLine("Введите возраст пользователя:");
            userForFind.UserAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите имя пользователя:");
            userForFind.UserName = Console.ReadLine();

            Console.WriteLine("Введите код региона пользователя:");
            userForFind.UserCode = Console.ReadLine();

            Console.WriteLine("Введите номер телефона пользователя:");
            userForFind.UserFhone = Console.ReadLine();
            allUsers.dellUser(userForFind);
        }
        static void Main(string[] args)
        {
            int choise;
            MyList allUsers = new MyList();

            while (true)
            {
                Console.WriteLine("Введите 1 ,если хотите создать пользователя \n" +
                                  "Введите 2 ,если хотите удалить всех пользователей\n" +
                                  "Введите 3 ,если хотите удалить последнего пользователя\n" +
                                  "Введите 4 ,если хотите удалить определенного пользователя\n" +
                                  "Введите 5 ,если хотите вывести информацию о всех пользователей \n" +
                                  "Введите 6 ,если хотите вывести колличество пользователей в базе\n" +
                                  "Введите 7 ,если хотите проверить ,существует ли введеный пользователь в базе\n" +
                                  "Введите 666 для успешного выхода из программы"
                                  );
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Введите 1 , если хотите заполнить по умолчанию\n" +
                                         "Введите 2 , если хотите заполнить поля сами");
                        Phone user = new Phone();
                        choise = Convert.ToInt32(Console.ReadLine());
                        switch (choise)
                        {
                            case 1:
                                allUsers.Add(user);
                                break;
                            case 2:
                                createDate(allUsers);
                                break;
                        };
                        break;
                    case 2:
                        allUsers.deleteAll();
                        break;
                    case 3:
                        allUsers.dellLast();
                        break;
                    case 4:
                        dellUser(allUsers);
                        break;
                    case 5:
                        allUsers.WriteAll();
                        break;
                    case 6:
                        Console.WriteLine(allUsers.count_elem());
                        break;
                    case 7:
                        findUser(allUsers);
                        break;

                    case 666:
                        break;

                }

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
