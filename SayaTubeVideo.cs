using System;

public class SayaTubeVideo
{
   
    private int id;
    private string judulVideo;
    private int playCount;


    public SayaTubeVideo(string judulVideo)
    {
        if (judulVideo == null)
        {
            throw new ArgumentNullException("judulVideo", "Judul video tidak boleh null.");
        }
        if (judulVideo.Length > 100)
        {
            throw new ArgumentException("Judul video tidak boleh lebih dari 100 karakter.");
        }

        Random rand = new Random();
        this.id = rand.Next(10000, 99999); 
        this.judulVideo = judulVideo;
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
        Console.WriteLine($"judulVideo: {this.judulVideo}");
        Console.WriteLine($"PlayCount: {this.playCount}");
    }
}

 }
}
