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

    class WordDocument : Document {
        public int WordCount { get; set; }

        public WordDocument(string name, string author, string filePath, int wordCount)
            : base(name, author, filePath) {
            WordCount = wordCount;
        }

        public override void DisplayInfo() {
            Console.WriteLine($"Word: {Name}, Автор: {Author}, Слов: {WordCount}, Путь: {FilePath}");
        } 
    }

    class PdfDocument : Document {
        public int PageCount { get; set; }

        public PdfDocument(string name, string author, string filePath, int pageCount)
            : base(name, author, filePath) {
            PageCount = pageCount;
        }

        public override void DisplayInfo() {
            Console.WriteLine($"PDF: {Name}, Автор: {Author}, Страниц: {PageCount}, Путь: {FilePath}");
        } 
    }

    class ExcelDocument : Document {
        public int SheetCount { get; set; }

        public ExcelDocument(string name, string author, string filePath, int sheetCount)
            : base(name, author, filePath) {
            SheetCount = sheetCount;
        }

        public override void DisplayInfo() {
            Console.WriteLine($"Excel: {Name}, Автор: {Author}, Листов: {SheetCount}, Путь: {FilePath}");
        } 
    }

    class TxtDocument : Document {
        public long FileSize { get; set; }

        public TxtDocument(string name, string author, string filePath, long fileSize)
            : base(name, author, filePath) {
            FileSize = fileSize;
        }

        public override void DisplayInfo() {
            Console.WriteLine($"TXT: {Name}, Автор: {Author}, Размер: {FileSize} байт, Путь: {FilePath}");
        } 
    }

    class HtmlDocument : Document {
        public string Encoding { get; set; }

        public HtmlDocument(string name, string author, string filePath, string encoding)
            : base(name, author, filePath) {
            Encoding = encoding;
        }

        public override void DisplayInfo() {
            Console.WriteLine($"HTML: {Name}, Автор: {Author}, Кодировка: {Encoding}, Путь: {FilePath}");
        }
    }


    class Program {

        static void Main() {
            
        }

    }

}