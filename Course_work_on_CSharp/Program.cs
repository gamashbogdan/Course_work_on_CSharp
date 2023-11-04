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
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Логін має містити лише літери і цифри")]
        public string Login { get; set; }// ллогін користувача 

        [Required(ErrorMessage = "Пароль не вказаний")]
        [RegularExpression(@"^[a-zA-Z0-9*$_-]+$", ErrorMessage = "Пароль може містити лише літери, цифри, *, $, _, -")]
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
                Console.WriteLine("2. вивести всіх користувачив");
                Console.WriteLine("3. Deserialize and load user data");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterUser();
                        break;
                    case 2:
                        DeserializeAndLoadUserData();
                        break;
                    case 3:
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
        static string IsLoginUnique()
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
                            return IsLoginUnique(); // Рекурсивний виклик, щоб вибрати інший логін
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
                Console.Write("Введіть Login : ");
                newUser.Login = IsLoginUnique();

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
            Console.WriteLine("User registered successfully.");
        }
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
        static void DeserializeAndLoadUserData()
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
                    Console.WriteLine($"Password: {item.Password}");
                    Console.WriteLine($"Confirm Password: {item.ConfirmPassword}");
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

