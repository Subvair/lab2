using System;

namespace project {

    //Базовый класс
    class Document {
    public string Name { get; set; }
    public string Author { get; set; }
    public string FilePath { get; set; }

    public Document(string name, string author, string filePath) {
        Name = name;
        Author = author;
        FilePath = filePath;
    }

    public virtual void DisplayInfo() {
        Console.WriteLine($"Документ: {Name}, Автор: {Author}, Путь: {FilePath}");
    }
}

    class Program {

        static void Main() {
            
        }

    }

}