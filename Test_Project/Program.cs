using System.Reflection.Metadata.Ecma335;
using Test_Project;

namespace Test_Project
{
    public  class QuestionsCSharp
    {
        public string Questions { get; set; }
        public string[] Answers { get; set; }
        public string[] ResponseIndex { get; set; }
        public override string ToString()
        {
            return $"\n\n{Questions}\n{Answers}";
        }
    }
    static class Quiz_Questions_About_CSharp
    {
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
        static public int Quiz()
        {
            int countTrue = 0;// рахує правильні відповіді
            foreach (var item in questions)
            {
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
                            countTrue++;
                        }
                    }
                }
                Console.WriteLine(); // Додаємо порожній рядок між питаннями
            }
            return countTrue;
        }
        

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int a = Quiz_Questions_About_CSharp.Quiz();
            Console.WriteLine($"Number of correct answers: {a}");
            
        }
    }
}