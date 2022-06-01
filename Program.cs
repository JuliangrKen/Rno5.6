using System;

class Program
{
	public static void Main(string[] args)
	{
		OutputData(InputData());
		Console.ReadKey();
	}

	static
		(
		string Name,
		string Surname,
		int Age,
		bool hasPet,
		int numPet,
		string[] NamesPets,
		int numFavoriteColor,
		string[] FavoriteColor
		)
		InputData()
	{
		Console.Write("Введите своё имя: ");
		string Name = Console.ReadLine();
		Console.WriteLine();

		Console.Write(Name + ", введите свою фамилию: ");
		string Surname = Console.ReadLine();
		Console.WriteLine();

		int Age;
		CheckCorrect(out Age, $"{Surname} {Name}, введите ваш возраст: ");
		Console.WriteLine();

		bool hasPet;
		while (true)
		{
			Console.Write("{0} {1}, есть ли у вас домашние животные (Да/Нет)? Ввод: ", Surname, Name);
			string answer = Console.ReadLine();
			if (answer.ToLower() == "да")
			{
				hasPet = true;
				break;
			}
			else if (answer.ToLower() == "нет")
			{
				hasPet = false;
				break;
			}
		}
		Console.WriteLine();

		int numPet = 0;
		if (hasPet)
		{
			CheckCorrect(out numPet, $"{Surname} {Name}, сколько у вас домашних животных? Ввод: ");
			Console.WriteLine();
		}

		string[] NamesPets = new string[numPet];
		if (numPet != 0)
		{
			FillingArray(NamesPets, "Введите имя {0} питомца (слово ''Отмена'' позволяет вернуться к предыдущему имени): ");
			Console.WriteLine();
		}

		CheckCorrect(out int numFavoriteColor, $"{Surname} {Name}, введите количество ваших любимых цветов: ");

		Console.WriteLine();

		string[] FavoriteColor = new string[numFavoriteColor];
		FillingArray(FavoriteColor, "Введите название {0} любимого цвета (слово ''Отмена'' позволяет вернуться к предыдущему имени): ");

		return
		(
		Name,
		Surname,
		Age,
		hasPet,
		numPet,
		NamesPets,
		numFavoriteColor,
		FavoriteColor
		);
	}
	static void

	OutputData
	(
		(
			string Name,
			string Surname,
			int Age,
			bool hasPet,
			int numPet,
			string[] NamesPets,
			int numFavoriteColor,
			string[] FavoriteColor
		) data
	)
	{
		Console.WriteLine("=============="); // Разделитель для удобства чтения.
		Console.WriteLine($"{data.Surname} {data.Name}, {data.Age} лет.");
		if (data.hasPet)
		{
			Console.Write("\nКоличество питомцев: {0}, \nИмена: ", data.numPet);
			foreach (var pet in data.NamesPets)
				Console.Write(pet + "; ");
			Console.WriteLine();
		}
		else
			Console.WriteLine("Домашних питомцев нет");
		Console.Write("Количество любимых цветов: {0}.\nИх названия: ", data.numFavoriteColor);
		foreach (var color in data.FavoriteColor)
			Console.Write(color + "; ");
		Console.WriteLine();
	}
	static void CheckCorrect(out int var, string str)
	{
		while (true)
		{
			Console.Write(str);
			string input = Console.ReadLine();
			if ((input != null || input != "") && int.TryParse(input, out var) && var > 0)
				break;
		}
	}

	static void FillingArray(string[] array, string str)
	{
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(str, i + 1);
			array[i] = Console.ReadLine();
			if (array[i].ToLower() == "отмена" && i > 0) i -= 2;
		}
	}
}