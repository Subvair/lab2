using System;
using System.Collections.Generic;

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

    class DocumentManager {
        private static DocumentManager _instance;
        private List<Document> _documents = new List<Document>();

        private DocumentManager() { }

        public static DocumentManager Instance {
            get {
                if (_instance == null) {
                    _instance = new DocumentManager();
                }
                return _instance;
            }
        }

        public void AddDocument(Document document) {
            _documents.Add(document);
        }

        public void ShowDocuments() {
            foreach (var document in _documents) {
                document.DisplayInfo();
            }
        }
    }


    class Program {

        static void Main() {
            DocumentManager manager = DocumentManager.Instance;
        
            manager.AddDocument(new WordDocument("Отчет", "Иванов", "C:/docs/report.docx", 1200));
            manager.AddDocument(new PdfDocument("Презентация", "Петров", "C:/docs/presentation.pdf", 15));
            manager.AddDocument(new ExcelDocument("Финансы", "Сидоров", "C:/docs/finance.xlsx", 3));
            manager.AddDocument(new TxtDocument("Заметки", "Кузнецов", "C:/docs/notes.txt", 2048));
            manager.AddDocument(new HtmlDocument("Главная", "Андреев", "C:/docs/index.html", "UTF-8"));
            
            Console.WriteLine("--- Список документов ---");
            manager.ShowDocuments();
        }

    }

}