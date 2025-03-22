using System;

public class SayaTubeVideo
{
   
    private int id;
    private string judul_video;
    private int playCount;


    public SayaTubeVideo(string judul_video)
    {
        if (judul_video == null)
        {
            throw new ArgumentNullException("judul_video", "Judul video tidak boleh null.");
        }
        if (judul_video.Length > 100)
        {
            throw new ArgumentException("Judul video tidak boleh lebih dari 100 karakter.");
        }

        Random rand = new Random();
        this.id = rand.Next(10000, 99999); 
        this.judul_video = judul_video;
        this.playCount = 0; 
    }

   
    public void IncreasePlayCount(int count)
    {
        if (count > 10000000)
        {
            throw new ArgumentOutOfRangeException("count", "Penambahan playCount maksimal 10.000.000 per panggilan.");
        }

        try
        {
          
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Terjadi overflow pada playCount.");
        }
    }


    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {this.id}");
        Console.WriteLine($"judul_video: {this.judul_video}");
        Console.WriteLine($"PlayCount: {this.playCount}");
    }
}

 }
}
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - [Relingga Aditya]");
            video.IncreasePlayCount(5000000);
            video.PrintVideoDetails();
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

   