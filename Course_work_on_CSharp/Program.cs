using System.ComponentModel.DataAnnotations;
using System.Linq;
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
    #region Запитання для вікторини
    public class QuestionsCSharp
    {
        public string Questions { get; set; }
        public string[] Answers { get; set; }
        public string[] ResponseIndex { get; set; }
    }
    public class Result
    {

        public string Login { get; set; }
        public string Password { get; set; }
        public int NumberOfIncorrectAnswers { get; set; }
        public int NumberOfCorrectAnswers { get; set; }
        public DateTime EndDate { get; set; }
        public Result()
        {
        }
        public Result(string login, string password, int numberOfCorrectAnswers , int numberOfIncorrectAnswers)
        {
            Login = login;
            Password = password;
            NumberOfCorrectAnswers = numberOfCorrectAnswers;
            NumberOfIncorrectAnswers = numberOfIncorrectAnswers;
            EndDate= DateTime.Now;

        }

    }
    static class Quiz_Questions_About_CSharp
    {
        static List<Result> resultsUser = new List<Result>();
        static List<QuestionsCSharp> questions = new List<QuestionsCSharp>()
        {
            new QuestionsCSharp
            {
                Questions = "1. Які завдання виконує середовище CLR?",
                Answers = new string[] { "   A. Компіляція коду", "   B. Виконання коду", "   C. Управління пам'яттю" },
                ResponseIndex = new string[] { "A", "B", "C" },
            },
            new QuestionsCSharp
            {
                Questions = "2. Яка абривіатури в платформі .NET визначає проміжну мову, в яку компілюється додаток?",
                Answers = new string[] { "   A. IL (Intermediate Language)", "   B. CIL (Common Intermediate Language)" },
                ResponseIndex = new string[] { "B" },
            },
            new QuestionsCSharp
            {
                Questions = "3. Чи можливо зробити декомпіляцію виконувального файлу (.exe) додатка написаного на мові C#?",
                Answers = new string[] { "A. Так", "B. Ні" },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "4. Назвіть основні відмінності між класом та структурою.",
                Answers = new string[] { "   A. Класи підтримують наслідування, структури - ні.", "   B. Класи - reference-типи, структури - value-типи" },
                ResponseIndex = new string[] { "A","B" },
            },
            new QuestionsCSharp
            {
                Questions = "5. Різниця між абстрактним класом та інтерфейсом?",
                Answers = new string[] { "   A. Абстрактний клас може мати реалізовані методи, інтерфейс - ні.", "   B. Клас може успадковувати тільки один абстрактний клас, але реалізувати кілька інтерфейсів." },
                ResponseIndex = new string[] { "A", "B" },
            },
            new QuestionsCSharp
            {
                Questions = "6. Коли ми можемо пройтися по власній колекції foreach-ом? Що для цього треба зробити і чому?",
                Answers = new string[] { "   A. Колекція повинна реалізувати інтерфейс IEnumerable", "   B. Використовувати foreach можна тільки для масивів.", "   C. Колекція повинна містити тільки значення типу int." },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "7. У чому відмінність між ключовими словами 'ref' і 'out'?",
                Answers = new string[] { "   A. 'ref' передає змінну до методу зі значенням за замовчуванням, 'out' вимагає, щоб метод присвоїв їй значення в середині методу", "   B. \"ref\" і \"out\" є абсолютно ідентичними і можуть використовуватися взаємозамінно." },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "8. Розкажіть, як працює try, catch, finally? Коли викликається кожен?",
                Answers = new string[] { "   A. Код в try блоку виконується завжди, потім виконується код в catch блоку, і, в кінці, код в finally блоку.", "   B. Код в try блоку виконується спробно, якщо виникає виняток, виконується код в catch блоку. Finally завжди виконується, навіть якщо виняток не виник" },
                ResponseIndex = new string[] { "B" },
            },
            new QuestionsCSharp
            {
                Questions = "9. Чим відрізняються один від одного класи String і StringBuilder? Коли доцільно використовувати 2-й?",
                Answers = new string[] { "   A. String - незмінний (immutable) рядок, StringBuilder - змінний (mutable) рядок. StringBuilder доцільно використовувати, коли потрібно виконувати багато операцій додавання або зміни тексту, оскільки він ефективніший у таких випадках", "   B. String і StringBuilder - однакові за своєю призначеністю і взаємозамінні." },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "10. Які відмінності між value-типами і reference-типами?",
                Answers = new string[] { "   A. Value-типи зберігаються на стеку, reference-типи - в кучі (heap).", "   B. Value-типи передаються за значенням, reference-типи - за посиланням.", "   C. Value-типи можуть бути null, reference-типи - ні" },
                ResponseIndex = new string[] { "A", "B", "C" },
            },
            new QuestionsCSharp
            {
                Questions = "11. У чому відмінність використання Finalize і Dispose?",
                Answers = new string[] { "   A. Finalize викликається автоматично збирачем сміття (GC) для очищення ресурсів, Dispose має бути викликаний вручну і призначений для явного вивільнення ресурсів", "   B. Finalize і Dispose - ідентичні методи для вивільнення ресурсів." },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "12. Що таке Boxing і Unboxing?",
                Answers = new string[] { "A. Boxing - перетворення value-типу в reference-тип (наприклад, int в object), Unboxing - перетворення reference-типу назад в value-тип","B. Boxing і Unboxing відносяться до збору сміття (GC) і не використовуються в C#."},
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "13. Чим відрізняється event від delegate?",
                Answers = new string[] { "   A. Delegate і event - це синоніми і можуть використовуватися взаємозамінно.", "   B. Event - це інкапсульований delegate, який дозволяє обмежити зовнішній доступ до підписників" },
                ResponseIndex = new string[] { "B" },
            },
            new QuestionsCSharp
            {
                Questions = "14. Чи може клас реалізувати два інтерфейса, у яких оголошено однакові методи? Якщо так, то яким чином?",
                Answers = new string[] { "   A. Так, клас може реалізувати два інтерфейса з однаковими методами, і в цьому випадку він повинен надати власну реалізацію цих методів", "   B. Ні, це неможливо, інтерфейси не можуть мати однакових методів." },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "15. Що таке абстрактний клас? В чому його особливість відносно простих класів?",
                Answers = new string[] { "   A. Простий клас - це клас, який може бути створений і використаний без обов'язкового успадкування.", "   B. Абстрактний клас - це клас, який не може бути створений безпосередньо, а лише унаслідуваний і розширений іншими класами. Він може мати абстрактні методи, які повинні бути реалізовані в похідних класах" },
                ResponseIndex = new string[] { "B" },
            },
            new QuestionsCSharp
            {
                Questions = "16. Чи можна заборонити наслідування від свого власного класу?",
                Answers = new string[] { "   A. Так, за допомогою ключового слова sealed", "   B. Ні, наслідування завжди дозволяється." },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "17. Яким чином можна присвоїти значення полям, які позначені ключовим словом readonly?",
                Answers = new string[] { "A. Значення readonly полів можна присвоїти тільки в конструкторі класу або в момент їхнього оголошення","B. Значення readonly полів можна змінювати в будь-який момент під час виконання програми." },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "18. Коли викликається статичний конструктор класу?",
                Answers = new string[] { "   A. Статичний конструктор викликається один раз, при першому використанні класу або доступу до статичних членів класу", "   B. Статичний конструктор не існує в C#." },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "19. Чим відрізняються константи і поля, доступні тільки для читання (readonly)?",
                Answers = new string[] { "   A. Константи і поля readonly - ідентичні і можуть використовуватися взаємозамінно.", "   B. Константи визначаються на етапі компіляції і не можуть бути змінені під час виконання. Поля readonly можуть бути ініціалізовані в конструкторі та змінені в моменті створення об'єкта" },
                ResponseIndex = new string[] { "B" },
            },
            new QuestionsCSharp
            {
                Questions = "20. Коли об'єкт поміщається в чергу на видалення GC?",
                Answers = new string[] { "   A. Об'єкт поміщається в чергу на видалення GC, коли він стає недосяжним і не має жодних посилань на нього", "   B. GC завжди видаляє об'єкти автоматично, і немає потреби в черзі на видалення." },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "21. Яким чином до об'єкту можна додати атрибут?",
                Answers = new string[] { "   A. Атрибути в C# додаються за допомогою використання квадратних дужок перед об'єктом і зазначенням властивостей атрибута", "   B. Додавання атрибутів до об'єктів в C# не підтримується." },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "22. Чи підтримує C# множинне наслідування?",
                Answers = new string[] { "   A. Ні, C# не підтримує множинне наслідування.", "   B. Так, C# підтримує множинне наслідування, коли клас успадковує одночасно від декількох батьківських класів" },
                ResponseIndex = new string[] { "B" },
            },
            new QuestionsCSharp
            {
                Questions = "23. Чи наслідуються змінні з модифікатором private?",
                Answers = new string[] { "   A. Змінні з модифікатором private не наслідуються і не доступні в похідних класах", "   B. Змінні з модифікатором private доступні для наслідування, але тільки в тому ж класі, де вони оголошені." },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "24. Що означає модифікатор virtual?",
                Answers = new string[] { "   A. Модифікатор virtual позначає, що метод може бути перевизначений (override) в похідних класах.", "   B. Модифікатор virtual позначає, що метод є абстрактним і має бути реалізованим у похідних класах." },
                ResponseIndex = new string[] { "A" },
            },
            new QuestionsCSharp
            {
                Questions = "25. Кому доступні змінні з модифікатором protected на рівні класу?",
                Answers = new string[] { "   A. Змінні з модифікатором protected доступні тільки для самого класу, де вони оголошені.", "   B. Змінні з модифікатором protected доступні для всіх класів у тому ж просторі імен і для похідних класів навіть за межами простору імен." },
                ResponseIndex = new string[] { "A" },
            },
        };
        static public void Saving_Results(string login,string password,int numberOfCorrectAnswers, int numberOfIncorrectAnswers)
        {
            resultsUser.Add(new Result(login, password, numberOfCorrectAnswers, numberOfIncorrectAnswers));

        }
        
        static public void Quiz(string login, string password)
        {
            int correctQuestionsCounter = 0;// рахує правильні відповіді
            int wrongAnswerCounter = 0;// рахує неправильні відповіді
            foreach (var item in questions)
            {
                wrongAnswerCounter = questions.Count;
                Console.WriteLine(item.Questions); // Виводимо питання на консоль

                for (int i = 0; i < item.Answers.Length; i++)
                {
                    Console.WriteLine($"  {item.Answers[i]}"); // Виводимо варіанти відповідей
                }
                Console.Write("Enter answer : ");
                string answer = Console.ReadLine();
                int lenght = 0;
                for (int j = 0; j < item.ResponseIndex.Length; j++)
                {
                    string[] words = answer.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int d = 0; d < words.Length; d++)
                    {
                        if (words[d] == item.ResponseIndex[j])
                        {
                            lenght++;
                        }
                        if (lenght == item.ResponseIndex.Length)
                        {
                            correctQuestionsCounter++;
                        }
                    }
                }
                Console.WriteLine(); // Додаємо порожній рядок між питаннями
            }
            wrongAnswerCounter -= correctQuestionsCounter;
            Saving_Results(login, password, correctQuestionsCounter, wrongAnswerCounter);
            Saving_Results_To_File();
        }
        static void Saving_Results_To_File()
        {
            // Серіалізація та збереження даних користувачів в файл
            if (resultsUser.Count > 0)
            {
                try
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Result>));
                    using (Stream fs = File.Create("list_of_user_results.xml"))
                    {
                        formatter.Serialize(fs, resultsUser);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        

    }
    #endregion
    internal class Program
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
                Console.WriteLine("0. Exit");

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
                    case 0:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
        #region Вхід користувача
        static bool Check_For_Uniqueness_Upon_Entry(string login, string password)
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
                        if (user.Login == login && user.Password == password)
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
                return false;// якщо користувача не знайдено то функція повертає false і користувача перекідає на реєстрацію
            }
            return true;// якщо користувача знайдено то функція повертає true і користувачу відкривається меню вікторини
        }
        static void login_User()
        {
            bool isRunning = true;
            Console.Write("Введіть Login : ");
            string login = Console.ReadLine();
            Console.Write("Введіть Password : ");
            string password = Console.ReadLine();
            if (Check_For_Uniqueness_Upon_Entry(login, password))
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
                            Quiz_Questions_About_CSharp.Quiz(login, password);
                            break;
                        case 2:
                            Deserialize_Results_File(login);
                            break;
                        case 3:
                            Top_Quiz_Results();
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
        }
        #endregion
        #region Реєстрація користувача
        static string Check_For_Uniqueness_At_Registration()// Перевірка на унікальність логіна при реєстрації
        {
            Console.Write("Введіть Login : ");
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
        static void Top_Quiz_Results()
        {
            if (File.Exists("list_of_user_results.xml"))
            {
                // Десеріалізація та завантаження даних користувачів з файлу
                int i = 0;
                XmlSerializer formatter = new XmlSerializer(typeof(List<Result>));
                List<Result> loadUsers = null;
                using (Stream fs = File.OpenRead("list_of_user_results.xml"))
                {
                    loadUsers = (List<Result>)formatter.Deserialize(fs);
                }
                var resultTop = loadUsers.OrderByDescending(i => i, new ResultComparer()).Take(20);
                foreach (var item in resultTop)
                {
                    i++;
                    Console.WriteLine($"Top number {i}");
                    Console.WriteLine($"Login: {item.Login}");
                    Console.WriteLine($"NumberOfCorrectAnswers: {item.NumberOfCorrectAnswers}");
                    Console.WriteLine($"NumberOfIncorrectAnswers: {item.NumberOfIncorrectAnswers}");
                    Console.WriteLine($"Data : {item.EndDate.Year}.{item.EndDate.Month}.{item.EndDate.Day}, {item.EndDate.Hour}:{item.EndDate.Minute}:{item.EndDate.Second}");
                    Console.WriteLine();
                }
                Console.WriteLine("User data has been deserialized and loaded.");
            }
            else
            {
                Console.WriteLine("User data file not found.");
            }
        }
        static void Deserialize_Results_File(string login)// вивід інформації з файлу
        {
            if (File.Exists("list_of_user_results.xml"))
            {
                // Десеріалізація та завантаження даних користувачів з файлу
                XmlSerializer formatter = new XmlSerializer(typeof(List<Result>));
                List<Result> loadUsers = null;
                using (Stream fs = File.OpenRead("list_of_user_results.xml"))
                {
                    loadUsers = (List<Result>)formatter.Deserialize(fs);
                }
                foreach (Result item in loadUsers)
                {
                    if (item.Login==login)
                    {
                        Console.WriteLine($"Login: {item.Login}");
                        Console.WriteLine($"NumberOfCorrectAnswers: {item.NumberOfCorrectAnswers}");
                        Console.WriteLine($"NumberOfIncorrectAnswers: {item.NumberOfIncorrectAnswers}");
                        Console.WriteLine($"Data : {item.EndDate.Year}.{item.EndDate.Month}.{item.EndDate.Day}, {item.EndDate.Hour}:{item.EndDate.Minute}:{item.EndDate.Second}");
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("User data has been deserialized and loaded.");
            }
            else
            {
                Console.WriteLine("User data file not found.");
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
    public class ResultComparer : IComparer<Result>
    {
        public int Compare(Result x, Result y)
        {
            // Додайте тут логіку порівняння двох об'єктів Result
            // Наприклад, в порядку спадання NumberOfCorrectAnswers

            if (x.NumberOfCorrectAnswers < y.NumberOfCorrectAnswers)
                return -1;
            if (x.NumberOfCorrectAnswers > y.NumberOfCorrectAnswers)
                return 1;
            return 0;
        }
    }

}

