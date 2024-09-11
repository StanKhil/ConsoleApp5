using System;
using System.Collections.Generic;
using System.Linq;

public abstract class DataCarrier
{
    public string Name { get; set; }
    public string ProducerName { get; set; }
    public string Model { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public abstract void Print();
    public abstract void LoadFromFile(string filePath);
    public abstract void SaveToFile(string filePath);
}

public class FlashMemory : DataCarrier
{
    public int MemoryCapacity { get; set; }
    public int USBSpeed { get; set; }

    public override void Print()
    {
        Console.WriteLine($"Flash-память: {Name}, производитель: {ProducerName}, модель: {Model}");
        Console.WriteLine($"Объем: {MemoryCapacity} Мб, скорость USB: {USBSpeed} Мб/с");
    }

    public override void LoadFromFile(string filePath)
    {
        Console.WriteLine("Загрузка данных из " + Name + " в файл: " + filePath);
    }

    public override void SaveToFile(string filePath)
    {
        Console.WriteLine("Загрузка данных на " + Name + " из файла: " + filePath);
    }
}

public class RemovableHDD : DataCarrier
{
    public int DiskSize { get; set; }
    public int USBSpeed { get; set; }

    public override void Print()
    {
        Console.WriteLine($"Жесткий диск: {Name}, производитель: {ProducerName}, модель: {Model}");
        Console.WriteLine($"Объем: {DiskSize} Мб, скорость USB: {USBSpeed} Мб/с");
    }

    public override void LoadFromFile(string filePath)
    {
        Console.WriteLine("Загрузка данных из " + Name + " в файл: " + filePath);
    }

    public override void SaveToFile(string filePath)
    {
        Console.WriteLine("Загрузка данных на " + Name + " из файла: " + filePath);
    }
}

public class DVDDisk : DataCarrier
{
    public int ReadSpeed { get; set; }
    public int WriteSpeed { get; set; }

    public override void Print()
    {
        Console.WriteLine($"DVD-диск: {Name}, производитель: {ProducerName}, модель: {Model}");
        Console.WriteLine($"Скорость чтения: {ReadSpeed} Мб/c, скорость записи: {WriteSpeed} Мб/с");
    }

    public override void LoadFromFile(string filePath)
    {
        Console.WriteLine("Загрузка данных из " + Name + " в файл: " + filePath);
    }

    public override void SaveToFile(string filePath)
    {
        Console.WriteLine("Загрузка данных на " + Name + " из файла: " + filePath);
    }
}

class Program
{
    static List<DataCarrier> carriers = new List<DataCarrier>();
    static void AddCarrier()
    {
        Console.WriteLine("\nВыберите тип носителя:");
        Console.WriteLine("1. Flash Memory");
        Console.WriteLine("2. Removable HDD");
        Console.WriteLine("3. DVD Disk");
        int choice = Convert.ToInt32(Console.ReadLine());

        DataCarrier carrier = null;

        switch (choice)
        {
            case 1:
                carrier = new FlashMemory();
                Console.Write("Введите объем памяти (Мб): ");
                ((FlashMemory)carrier).MemoryCapacity = int.Parse(Console.ReadLine());
                Console.Write("Введите скорость USB (Мб/с): ");
                ((FlashMemory)carrier).USBSpeed = int.Parse(Console.ReadLine());
                break;
            case 2:
                carrier = new RemovableHDD();
                Console.Write("Введите объем диска (Мб): ");
                ((RemovableHDD)carrier).DiskSize = int.Parse(Console.ReadLine());
                Console.Write("Введите скорость USB (Мб/с): ");
                ((RemovableHDD)carrier).USBSpeed = int.Parse(Console.ReadLine());
                break;
            case 3:
                carrier = new DVDDisk();
                Console.Write("Введите скорость чтения (Мб/с): ");
                ((DVDDisk)carrier).ReadSpeed = int.Parse(Console.ReadLine());
                Console.Write("Введите скорость записи (Мб/с): ");
                ((DVDDisk)carrier).WriteSpeed = int.Parse(Console.ReadLine());
                break;
            default:
                Console.WriteLine("Неправильный выбор.");
                return;
        }

        Console.Write("Введите имя: ");
        carrier.Name = Console.ReadLine();
        Console.Write("Введите производителя: ");
        carrier.ProducerName = Console.ReadLine();
        Console.Write("Введите модель: ");
        carrier.Model = Console.ReadLine();
        carriers.Add(carrier);

        Console.WriteLine("Носитель добавлен.");
    }

    static void RemoveCarrier()
    {
        Console.Write("Введите имя носителя для удаления: ");
        string name = Console.ReadLine();
        for (int i = 0; i < carriers.Count; i++)
            if (carriers[i].Name == name)
                carriers.RemoveAt(i);

        Console.WriteLine("Носитель удален.");
    }

    static void PrintCarriers()
    {
        Console.WriteLine("\nСписок носителей информации:");
        foreach (var carrier in carriers)
        {
            carrier.Print();
            Console.WriteLine();
        }
    }

    static void ModifyCarrier()
    {
        Console.Write("Введите имя носителя для изменения: ");
        string name = Console.ReadLine();
        DataCarrier foundCarrier = null;
        foreach (var carrier in carriers)
        {
            if (carrier.Name == name)
            {
                foundCarrier = carrier;
                break;
            }
        }

        if (foundCarrier != null)
        {
            Console.WriteLine("Носитель найден.");
            foundCarrier.Print();
            Console.WriteLine("Введите новые данные:");
            Console.Write("Имя: ");
            foundCarrier.Name = Console.ReadLine();
            Console.Write("Производитель: ");
            foundCarrier.ProducerName = Console.ReadLine();
            Console.Write("Модель: ");
            foundCarrier.Model = Console.ReadLine();
        }
        else Console.WriteLine("Носитель не найден.");
    }

    static void SearchCarrier()
    {
        Console.Write("Введите имя носителя для поиска: ");
        string name = Console.ReadLine();
        DataCarrier foundCarrier = null;
        foreach (var carrier in carriers)
        {
            if (carrier.Name == name)
            {
                foundCarrier = carrier;
                break;
            }
        }

        if (foundCarrier != null)
        {
            Console.WriteLine("Найденный носитель:");
            foundCarrier.Print();
        }
        else Console.WriteLine("Носитель не найден.");
    }
    static void Main()
    {

        carriers.Add(new FlashMemory { Name = "Kingston", ProducerName = "Kingston", Model = "DataTraveler", MemoryCapacity = 32, USBSpeed = 10 });
        carriers.Add(new RemovableHDD { Name = "Seagate", ProducerName = "Seagate", Model = "Expansion", DiskSize = 1000, USBSpeed = 5 });
        carriers.Add(new DVDDisk { Name = "Sony", ProducerName = "Sony", Model = "DVD-R", ReadSpeed = 16, WriteSpeed = 8 });

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить носитель информации");
            Console.WriteLine("2. Удалить носитель информации");
            Console.WriteLine("3. Печать списка носителей информации");
            Console.WriteLine("4. Изменить параметры носителя информации");
            Console.WriteLine("5. Поиск носителя информации");
            Console.WriteLine("6. Выход");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddCarrier();
                    break;
                case 2:
                    RemoveCarrier();
                    break;
                case 3:
                    PrintCarriers();
                    break;
                case 4:
                    ModifyCarrier();
                    break;
                case 5:
                    SearchCarrier();
                    break;
                case 6:
                    return;
                default:
                    break;
            }
        }
    }
}
