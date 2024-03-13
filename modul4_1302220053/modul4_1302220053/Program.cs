using static kodeBuah;
using static Program;
public enum Buah {Apel, Aprikot,Alpukat, Pisang, Paprika, Blackberry,Ceri, Kelapa, Jagung, Kurma, Durian, Anggur, Melon, Semangka}

public class Program
{


    static void Main(string[] args)
    {
        // Example usage:
        Console.WriteLine("List Kelurahan: ");
        foreach (Buah fruit in Enum.GetValues(typeof(Buah)))
        {
            String fruitCode = getKodeBuah(fruit);
            Console.WriteLine(fruit + ": " + fruitCode);
        }
        

    }
}

public class kodeBuah
{
    public static String getKodeBuah(Buah fruit)
    {
        String[] fruitCode = { "A00","B00","C00","D00","E00","F00","H00","I00","J00","K00","L00","M00","N00","O00" };
        return fruitCode[(int)fruit];

    }
}


