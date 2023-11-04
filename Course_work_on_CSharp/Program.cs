using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Course_work_on_CSharp
{
    #region Zavdanua
    /*
    Завдання 2
                        Створити додаток «Вікторина».
           Основне завдання проєкту: надати користувачеві можливість перевірити свої знання
           у різних галузях.
           Інтерфейс додатку повинен надавати такі можливості:
           ■ При старті програми користувач вводить логін і пароль для входу.
             Якщо користувач не зареєстрований, він має пройти процес реєстрації.
           ■ При реєстрації потрібно вказати:
                • логін (не можна зареєструвати вже існуючий логін);
                • пароль;
                • дату народження.
           ■ Після входу в систему користувач може:
                • стартувати нову вікторину;
                • переглянути результати своїх минулих вікторин;
                • переглянути Топ-20 з конкретної вікторини;
                • змінити налаштування: можна змінювати пароль та дату народження;
                • вихід.
           ■ Для старту нової вікторини користувач повинен обрати розділ знань вікторини.
           Наприклад, «Історія», «Географія», «Біологія» і т.д.Також потрібно передбачити
           змішану вікторину, коли питання будуть обиратися з різних вікторин за рандомним
           принципом.
           ■ Конкретна вікторина складається із двадцяти питань. Кожне питання може мати
           один або декілька правильних варіантів відповідей. Якщо питання передбачає
           декілька правильних відповідей, а користувач вказав не все, питання не зараховується.
           ■ Після завершення вікторини користувач отримує кількість правильних відповідей,
           а також отримує своє місце у таблиці результатів гравців вікторини.
           Необхідно також розробити утиліту для створення і редагування вікторин і їх питань.
           Цей додаток має передбачати вхід за логіном і паролем
    */
    #endregion
    #region User
    public class User
    {
        [Required(ErrorMessage = "Логін не вказаний")]
        //[UniquenessСheck(ErrorMessage = "Логін не унікальний")]
        [RegularExpression(@"^[a-zA-Z0-9 +]+$", ErrorMessage = "Логін має містити лише літери і цифри")]
        public string Login { get; set; }// ллогін користувача 

        [Required(ErrorMessage = "Пароль не вказаний")]
        [RegularExpression(@"^[a-zA-Z0-9*$_-]+$", ErrorMessage = "Пароль може містити лише літери, цифри, *, $, _, -, без пробілів")]
        [MinLength(8, ErrorMessage = "Пароль повинен бути принаймні 8 символів")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Підтвердження паролю не вказано")]
        [Compare(nameof(Password), ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Дата народження не вказана")]
        [DataType(DataType.Date, ErrorMessage = "Невірний формат дати")]
        [DateOfBirth(ErrorMessage = "Дата народження не може бути більшою за поточний час")]
        public DateTime Data { get; set; }
    }
    public class DateOfBirthAttribute : ValidationAttribute// написав chatGPT
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date <= DateTime.Now;
            }
            return true; // Повертає true, якщо значення не є DateTime (ігноруємо його в цьому випадку)
        }
    }


    #endregion
    class QuestionsCSharp
    {
        public string Questions { get; set; }
        public string[] Answers { get; set; }
        public int[] ResponseIndex { get; set; }
       
    }
    static class Quiz_Questions_About_CSharp
    {
        static List<QuestionsCSharp> questions = new List<QuestionsCSharp>()
        {
            new QuestionsCSharp
            {
                Questions = "1. Які завдання виконує середовище CLR?",
                Answers = new string[] { "A. Компіляція коду", "B. Виконання коду", "C. Управління пам'яттю" },
                ResponseIndex = new int[] { 0, 1, 2 },
            },
            new QuestionsCSharp
            {
                Questions = "2. Яка абривіатури в платформі .NET визначає проміжну мову, в яку компілюється додаток?",
                Answers = new string[] { "A. CIL (Common Intermediate Language)", "B. IL (Intermediate Language)" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "3. Чи можливо зробити декомпіляцію виконувального файлу (.exe) додатка написаного на мові C#?",
                Answers = new string[] { "A. Так", "B. Ні" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "4. Назвіть основні відмінності між класом та структурою.",
                Answers = new string[] { "A. Класи підтримують наслідування, структури - ні.", "B. Класи - reference-типи, структури - value-типи" },
                ResponseIndex = new int[] { 0, 1 },
            },
            new QuestionsCSharp
            {
                Questions = "5. Різниця між абстрактним класом та інтерфейсом?",
                Answers = new string[] { "A. Абстрактний клас може мати реалізовані методи, інтерфейс - ні.", "B. Клас може успадковувати тільки один абстрактний клас, але реалізувати кілька інтерфейсів." },
                ResponseIndex = new int[] { 0, 1 },
            },
            new QuestionsCSharp
            {
                Questions = "6. Коли ми можемо пройтися по власній колекції foreach-ом? Що для цього треба зробити і чому?",
                Answers = new string[] { "A. Колекція повинна реалізувати інтерфейс IEnumerable" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "7. У чому відмінність між ключовими словами 'ref' і 'out'?",
                Answers = new string[] { "A. 'ref' передає змінну до методу зі значенням за замовчуванням, 'out' вимагає, щоб метод присвоїв їй значення в середині методу" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "8. Розкажіть, як працює try, catch, finally? Коли викликається кожен?",
                Answers = new string[] { "A. Код в try блоку виконується спробно, якщо виникає виняток, виконується код в catch блоку. Finally завжди виконується, навіть якщо виняток не виник" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "9. Чим відрізняються один від одного класи String і StringBuilder? Коли доцільно використовувати 2-й?",
                Answers = new string[] { "A. String - незмінний (immutable) рядок, StringBuilder - змінний (mutable) рядок. StringBuilder доцільно використовувати, коли потрібно виконувати багато операцій додавання або зміни тексту, оскільки він ефективніший у таких випадках" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "10. Які відмінності між value-типами і reference-типами?",
                Answers = new string[] { "A. Value-типи зберігаються на стеку, reference-типи - в кучі (heap).", "B. Value-типи передаються за значенням, reference-типи - за посиланням.", "C. Value-типи можуть бути null, reference-типи - ні" },
                ResponseIndex = new int[] { 0, 1, 2 },
            },
            new QuestionsCSharp
            {
                Questions = "11. У чому відмінність використання Finalize і Dispose?",
                Answers = new string[] { "A. Finalize викликається автоматично збирачем сміття (GC) для очищення ресурсів, Dispose має бути викликаний вручну і призначений для явного вивільнення ресурсів" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "12. Що таке Boxing і Unboxing?",
                Answers = new string[] { "A. Boxing - перетворення value-типу в reference-тип (наприклад, int в object), Unboxing - перетворення reference-типу назад в value-тип" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "13. Чим відрізняється event від delegate?",
                Answers = new string[] { "A. Event - це інкапсульований delegate, який дозволяє обмежити зовнішній доступ до підписників" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "14. Чи може клас реалізувати два інтерфейса, у яких оголошено однакові методи? Якщо так, то яким чином?",
                Answers = new string[] { "A. Так, клас може реалізувати два інтерфейса з однаковими методами, і в цьому випадку він повинен надати власну реалізацію цих методів" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "15. Що таке абстрактний клас? В чому його особливість відносно простих класів?",
                Answers = new string[] { "A. Абстрактний клас - це клас, який не може бути створений безпосередньо, а лише унаслідуваний і розширений іншими класами. Він може мати абстрактні методи, які повинні бути реалізовані в похідних класах" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "16. Чи можна заборонити наслідування від свого власного класу?",
                Answers = new string[] { "A. Так, за допомогою ключового слова sealed" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "17. Яким чином можна присвоїти значення полям, які позначені ключовим словом readonly?",
                Answers = new string[] { "A. Значення readonly полів можна присвоїти тільки в конструкторі класу або в момент їхнього оголошення" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "18. Коли викликається статичний конструктор класу?",
                Answers = new string[] { "A. Статичний конструктор викликається один раз, при першому використанні класу або доступу до статичних членів класу" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "19. Чим відрізняються константи і поля, доступні тільки для читання (readonly)?",
                Answers = new string[] { "A. Константи визначаються на етапі компіляції і не можуть бути змінені під час виконання. Поля readonly можуть бути ініціалізовані в конструкторі та змінені в моменті створення об'єкта" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "20. Коли об'єкт поміщається в чергу на видалення GC?",
                Answers = new string[] { "A. Об'єкт поміщається в чергу на видалення GC, коли він стає недосяжним і не має жодних посилань на нього" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "21. Яким чином до об'єкту можна додати атрибут?",
                Answers = new string[] { "A. Атрибути в C# додаються за допомогою використання квадратних дужок перед об'єктом і зазначенням властивостей атрибута" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "22. Чи підтримує C# множинне наслідування?",
                Answers = new string[] { "A. Так, C# підтримує множинне наслідування, коли клас успадковує одночасно від декількох батьківських класів" },
                ResponseIndex = new int[] { 0 },
            },
            new QuestionsCSharp
            {
                Questions = "23. Чи наслідуються змінні з модифікатором private?",
                Answers = new string[] { "A. Змінні з модифікатором private не наслідуються і не доступні в похідних класах" },
                ResponseIndex = new int[] { 0 },
            },
        };
        static public void Print()
        {
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine(questions[i].Questions); // Виводимо питання на консоль

                for (int j = 0; j < questions[i].Answers.Length; j++)
                {
                    Console.WriteLine($"  {questions[i].Answers[j]}"); // Виводимо варіанти відповідей
                }

                Console.WriteLine(); // Додаємо порожній рядок між питаннями
            }
        }
    }
    class Program
    {
        static List<User> users = new List<User>();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1. Зареєструватися");
                Console.WriteLine("2. Вхід");
                Console.WriteLine("3. вивести всіх користувачив");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterUser();
                        break;
                    case 2:
                        login_User();
                        break;
                    case 3:
                        DeserializeAndLoadUserData();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
        static bool Check_For_Uniqueness_Upon_Entry(string login, string pasword)
        {
            int choice;
            bool isValid = false;
            if (File.Exists("quiz_user_list.xml"))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
                List<User> loadedUsers = null;

                using (Stream fs = File.OpenRead("quiz_user_list.xml"))
                {
                    // Додати перевірку на null
                    if (fs.Length > 0)
                    {
                        loadedUsers = (List<User>)formatter.Deserialize(fs);
                    }
                }
                if (loadedUsers != null)
                {
                    foreach (User user in loadedUsers)
                    {
                        if (user.Login == login && user.Password == pasword)
                        {
                            Console.WriteLine("ви успішно увійшли");
                            isValid = true;
                        }
                    }
                }
            }
            if (!isValid)
            {
                Console.WriteLine("Такого користувача не знайдено :(");
                Console.WriteLine("Спробувати ще раз\n\t1 - Так\n\t2 - Ні");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    login_User();
                }
                else if (choice == 2)
                {
                    RegisterUser();
                }
                return false;
            }
            return true;
        }
        static void login_User()
        {
            bool isRunning = true;
            Console.Write("Введіть Login : ");
            string login = Console.ReadLine();
            Console.Write("Введіть Password : ");
            string pasword = Console.ReadLine();
            if (Check_For_Uniqueness_Upon_Entry(login, pasword))
            {
                while (isRunning)
                {
                    Console.WriteLine("1. стартувати нову вікторину");
                    Console.WriteLine("2. переглянути результати своїх минулих вікторин");
                    Console.WriteLine("3. переглянути Топ-20 з конкретної вікторини");
                    Console.WriteLine("4. змінити налаштування: можна змінювати пароль та дату народження");
                    Console.WriteLine("5. вихід");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
            }
            else
            {
                RegisterUser();
            }

        }

        #region Реєстрація користувача
        static string Check_For_Uniqueness_At_Registration()// Перевірка на унікальність логіна при реєстрації
        {
            string login = Console.ReadLine();
            if (File.Exists("quiz_user_list.xml"))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
                List<User> loadedUsers = null;

                using (Stream fs = File.OpenRead("quiz_user_list.xml"))
                {
                    // Додати перевірку на null
                    if (fs.Length > 0)
                    {
                        loadedUsers = (List<User>)formatter.Deserialize(fs);
                    }
                }
                if (loadedUsers != null)
                {
                    foreach (User user in loadedUsers)
                    {
                        if (user.Login == login)
                        {
                            Console.WriteLine("Користувач з таким логіном вже існує. Будь ласка, виберіть інший логін.");
                            return Check_For_Uniqueness_At_Registration(); // Рекурсивний виклик, щоб вибрати інший логін
                        }
                    }
                }
            }
            return login;
        }
        static void RegisterUser()
        {
            User newUser = new User();
            bool isValid;
            do
            {
                Console.WriteLine("Меню реєстрації користувачів вікторини");
                Console.Write("Введіть Login : ");
                newUser.Login = Check_For_Uniqueness_At_Registration();

                Console.Write("Введіть Password : ");
                newUser.Password = Console.ReadLine();

                Console.Write("Підтвердіть Password : ");
                newUser.ConfirmPassword = Console.ReadLine();

                Console.Write("Введіть дату народження (yyyy-MM-dd) : ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
                {
                    newUser.Data = dateOfBirth;
                }
                else
                {
                    Console.WriteLine("Неправильний формат дати. Введіть в такому форматі yyyy-MM-dd.");
                }

                var result = new List<ValidationResult>();
                var context = new ValidationContext(newUser);

                if (!(isValid = Validator.TryValidateObject(newUser, context, result, true)))
                {
                    foreach (ValidationResult error in result)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

            } while (!isValid);

            // Generate a unique Id and add the user to the dictionary
            users.Add(newUser);
            SerializeAndSaveUserData();
            Console.WriteLine("Користувач успішно зареєстрований.");
        }
        #endregion
        static void SerializeAndSaveUserData()
        {
            // Серіалізація та збереження даних користувачів в файл
            if (users.Count > 0)
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
                try
                {
                    using (Stream fs = File.Create("quiz_user_list.xml"))
                    {
                        formatter.Serialize(fs, users);
                    }
                    Console.WriteLine("User data has been serialized and saved.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("No user data to save.");
            }

        }
        static void DeserializeAndLoadUserData()// вивід інформації з файлу
        {
            if (File.Exists("quiz_user_list.xml"))
            {
                // Десеріалізація та завантаження даних користувачів з файлу
                XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
                List<User> loadUsers = null;
                using (Stream fs = File.OpenRead("quiz_user_list.xml"))
                {
                    loadUsers = (List<User>)formatter.Deserialize(fs);
                }
                foreach (User item in loadUsers)
                {
                    Console.WriteLine($"Login: {item.Login}");
                    Console.WriteLine($"Data : {item.Data.Year}.{item.Data.Month}.{item.Data.Day}");
                    Console.WriteLine();
                }


                Console.WriteLine("User data has been deserialized and loaded.");
            }
            else
            {
                Console.WriteLine("User data file not found.");
            }
        }

    }
}

