//using System;
using System.Drawing;

namespace FilePersistence{

    public class Program{

        public static string Filepath="./cat_base64.txt";
        public static void Main(string[]args){

            //Write Data
            /*Console.WriteLine("Hello What is your Name");
            string name=Console.ReadLine();

            Console.WriteLine("Hello, "+ name);

            //Save Data
            using (StreamWriter writer = new StreamWriter(Filepath)){

            
                writer.WriteLine(name);
            }*/

            string base64Txt = "";
           //Read Data
            if(File.Exists(Filepath)){
                using(StreamReader reader = new StreamReader(Filepath)){
                    
                    string line;

                    while((line = reader.ReadLine())!= null){

                        string[] parts = line.Split(',');
                        base64Txt=parts[1];
                    }
                }
            }
        

        byte[] imageBytes = Convert.FromBase64String(base64Txt);

        using(MemoryStream ms = new MemoryStream(imageBytes) ){

            //create img from memmory stream
            Image image = Image.FromStream(ms);

            //Output the img
            image.Save("output_image.png");
        }

    }
}
}