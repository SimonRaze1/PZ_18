using System;

public class Parcel
{
    private static int totalParcels = 0;
    private static double totalWeight = 0;
    private const double maxTotalWeight = 30.0;

    private string senderName;
    public string SenderName
    {
        get { return senderName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Предупреждение: ФИО отправителя не может быть пустым.");
            }
            else
            {
                senderName = value;
            }
        }
    }

    private string receiverName;
    public string ReceiverName
    {
        get { return receiverName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Предупреждение: ФИО получателя не может быть пустым.");
            }
            else
            {
                receiverName = value;
            }
        }
    }

    private string receiverAddress;
    public string ReceiverAddress
    {
        get { return receiverAddress; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Предупреждение: Адрес получателя не может быть пустым.");
            }
            else
            {
                receiverAddress = value;
            }
        }
    }

    private double weight;
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value >= 0.2 && value <= 5.0)
            {
                if (totalWeight + value <= maxTotalWeight)
                {
                    totalWeight += value;
                    weight = value;
                }
                else
                {
                    Console.WriteLine("Предупреждение: Невозможно добавить посылку, общий вес превышает 30 кг.");
                }
            }
            else
            {
                Console.WriteLine("Предупреждение: Вес посылки должен быть от 0.2 кг до 5 кг.");
            }
        }
    }

    public enum ClassType
    {
        Standard = 500,
        FirstClass = 2000
    }

    public ClassType Class { get; set; }

    public Parcel(string senderName, string receiverName, string receiverAddress, double weight, ClassType parcelClass)
    {
        SenderName = senderName;
        ReceiverName = receiverName;
        ReceiverAddress = receiverAddress;
        Weight = weight;
        Class = parcelClass;
        totalParcels++;
    }

    public void DisplayParcelInfo()
    {
        Console.WriteLine($"Отправитель: {SenderName}");
        Console.WriteLine($"Получатель: {ReceiverName}");
        Console.WriteLine($"Адрес получателя: {ReceiverAddress}");
        Console.WriteLine($"Вес посылки: {Weight} кг");
        Console.WriteLine($"Класс посылки: {Class}");
    }

    public double CalculatePrice()
    {
        double pricePer100g = 10;
        double weightInGrams = Weight * 1000;
        double price = weightInGrams * pricePer100g + (double)Class;
        return price;
    }

    public static void DisplayTotalInfo()
    {
        Console.WriteLine($"Общее количество посылок: {totalParcels}");
        Console.WriteLine($"Общий вес всех посылок: {totalWeight} кг");
    }
}
