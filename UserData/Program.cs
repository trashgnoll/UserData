using System;

namespace UserData2
{
    internal class Program
    {
        static string InputString(string Prompt, bool AllowEmptyInput = false)
        {
            Console.Write(Prompt);
            string result = "";
            if (AllowEmptyInput)
                result = Console.ReadLine();
            else
                while ((result = Console.ReadLine()) == null || result == "")
                    Console.Write(Prompt);
            return result;
        }
        static int InputPetCount()
        {
            int result = -1;
            while (result < 0)
            {
                string answer =
                    InputString("Если есть питомцы, введите их количество. Если нет, нажмите Enter: ", true);
                if (answer == "")
                    result = 0;
                else if (!int.TryParse(answer, out result) || result < 0)
                    result = -1;
            }
            return result;
        }
        static string[] InputPetNames(int PetsCount)
        {
            string[] result = new string[PetsCount];
            for (uint i = 0; i < PetsCount; i++)
                result[i] = InputString("\tИмя питомца №" + (i + 1).ToString() + ": ");
            return result;
        }
        static int InputColorsCount()
        {
            int result = -1;
            while (result < 0)
            {
                string answer =
                    InputString("Введите количество любимых цветов: ");
                if (!int.TryParse(answer, out result) || result <= 0)
                    result = -1;
            }
            return result;
        }
        static int InputAge()
        {
            int result = -1;
            while (result < 0)
            {
                string answer =
                    InputString("Введите возраст: ");
                if (!int.TryParse(answer, out result) || result < 1)
                    result = -1;
            }
            return result;
        }
        static string[] InputColorNames(int ColorsCount)
        {
            string[] result = new string[ColorsCount];
            for (uint i = 0; i < ColorsCount; i++)
                result[i] = InputString("\tЛюбимый цвет №" + (i + 1).ToString() + ": ");
            return result;
        }
        static (string FirstName, string LastName, int Age, string[] Pets, string[] Colors) InputUserData()
        {
            // Empty return:
            (string FirstName, string LastName, int Age, string[] Pets, string[] Colors) result =
                ("", "", -1, new string[0], new string[0]);
            // Name:
            result.FirstName = InputString("Введите имя: ");
            result.LastName = InputString("Введите фамилию: ");
            // Age:
            result.Age = InputAge();
            // Pets:
            int petCount = InputPetCount();
            result.Pets = InputPetNames(petCount);
            // Colors:
            int colorsCount = InputColorsCount();
            result.Colors = InputColorNames(colorsCount);
            return result;
        }

        static string StringArrayToString(string[] arr, string EmptyPrompt = "", string Prompt = "")
        {
            string result;
            if (arr.Length > 0)
            {
                result = Prompt;
                for (int i = 0, count = arr.Length; i < count; i++)
                    result += arr[i] + (i < count - 2 ? ", " : (i == count - 2) ? " и " : "");
            }
            else
                result = EmptyPrompt;
            return result;
        }

        static void OutputUserData(in (string FirstName, string LastName, int Age, string[] Pets, string[] Colors) UserData)
        {
            Console.WriteLine(UserData.FirstName);
            Console.WriteLine(UserData.LastName);
            Console.WriteLine(StringArrayToString(UserData.Pets, "Питомцев нет", "Питомцы: "));
            Console.WriteLine(StringArrayToString(UserData.Colors, "", "Любимые цвета: "));
        }
        static void Main(string[] args)
        {
            var userData = InputUserData();
            OutputUserData(userData);
            Console.ReadKey();
        }
    }
}
