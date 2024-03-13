using static kodeBuah;
using static Program;
public enum Buah {Apel, Aprikot,Alpukat, Pisang, Paprika, Blackberry,Ceri, Kelapa, Jagung, Kurma, Durian, Anggur, Melon, Semangka}

public class Program
{


    static void Main(string[] args)
    {
        // Example usage:
        Console.WriteLine("List Buah: ");
        foreach (Buah fruit in Enum.GetValues(typeof(Buah)))
        {
            String fruitCode = getKodeBuah(fruit);
            Console.WriteLine(fruit + ": " + fruitCode);
        }
        Character mc = new Character();
        Console.WriteLine(mc.currentState);
        mc.ActivateTrigger(Trigger.TombolW);
        Console.WriteLine(mc.currentState);
        mc.ActivateTrigger(Trigger.TombolX);
        Console.WriteLine(mc.currentState);
        mc.ActivateTrigger(Trigger.TombolS);
        Console.WriteLine(mc.currentState);
        mc.ActivateTrigger(Trigger.TombolW);
        Console.WriteLine(mc.currentState);
        mc.ActivateTrigger(Trigger.TombolW);
        Console.WriteLine(mc.currentState);
        mc.ActivateTrigger(Trigger.TombolS);
        Console.WriteLine(mc.currentState);



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


public enum characterState { JONGKOK, BERDIRI, TENGKURAP, TERBANG };
public enum Trigger { TombolW, TombolS, TombolX };
public class Character
{
    public class PosisiKarakterGame
    {
        public characterState stateAwal;
        public characterState stateAkhir;
        public Trigger trigger;

        public PosisiKarakterGame(characterState stateAwal, characterState stateAkhir, Trigger trigger)
        {
            this.stateAwal = stateAwal;
            this.stateAkhir = stateAkhir;
            this.trigger = trigger;
        }

    }
    PosisiKarakterGame[] transisi =
    {
        new PosisiKarakterGame(characterState.JONGKOK, characterState.TENGKURAP, Trigger.TombolS),
        new PosisiKarakterGame(characterState.BERDIRI, characterState.JONGKOK, Trigger.TombolS),
        new PosisiKarakterGame(characterState.TERBANG, characterState.BERDIRI, Trigger.TombolS),
        new PosisiKarakterGame(characterState.TENGKURAP, characterState.JONGKOK, Trigger.TombolW),
        new PosisiKarakterGame(characterState.JONGKOK, characterState.BERDIRI, Trigger.TombolW),
        new PosisiKarakterGame(characterState.BERDIRI, characterState.TERBANG, Trigger.TombolW),
        new PosisiKarakterGame(characterState.TERBANG, characterState.JONGKOK,Trigger.TombolX)
         };

    public characterState currentState = characterState.BERDIRI;

    public characterState GetNextState(characterState stateAwal, Trigger trigger)
    {
        characterState stateAkhir = stateAwal;
        for (int i = 0; i < transisi.Length; i++)
        {
            PosisiKarakterGame perubahan = transisi[i];
            if (stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
            {
                stateAkhir = perubahan.stateAkhir;
            }
        }
        return stateAkhir;
    }

    public void ActivateTrigger(Trigger trigger)
    {
        Trigger currentTrigger = trigger;
        currentState = GetNextState(currentState, trigger);
        
        if (currentTrigger == Trigger.TombolS)
        {
            Console.WriteLine("Tombol arah bawah Ditekan");
        }
        else if (currentTrigger == Trigger.TombolW)
        {
            Console.WriteLine("tombol arah atas Ditekan");
        }
        Console.WriteLine("State anda Sekarang adalah : " + currentState);
    }
}