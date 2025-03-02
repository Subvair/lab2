using System;
using System.Collections.Generic;

namespace project {

    //Базовый класс
    class Document {
        public string Name { get; set; }
        public string Author { get; set; }
        public string FilePath { get; set; }
        public string Topic { get; set; }
        public List<string> Keywords { get; set; }

        public Document(string name, string author, string filePath, string topic, List<string> keywords) {
            Name = name;
            Author = author;
            FilePath = filePath;
            Topic = topic;
            Keywords = keywords;
        }

        public virtual void DisplayInfo() {
        Console.WriteLine($"Документ: {Name}, Автор: {Author}, Тематика: {Topic}, Ключевые слова: {string.Join(", ", Keywords)}, Путь: {FilePath}");
        }
    }

    class WordDocument : Document {
        public int WordCount { get; set; }

        public WordDocument(string name, string author, string filePath, string topic, List<string> keywords, int wordCount)
            : base(name, author, filePath, topic, keywords) {
            WordCount = wordCount;
        }

        public override void DisplayInfo() {
            Console.WriteLine($"Word: {Name}, Автор: {Author}, Тематика: {Topic}, Слова: {WordCount}, Ключевые слова: {string.Join(", ", Keywords)}, Путь: {FilePath}");
        } 
    }

    class PdfDocument : Document {
        public int PageCount { get; set; }

        public PdfDocument(string name, string author, string filePath, string topic, List<string> keywords, int pageCount)
            : base(name, author, filePath, topic, keywords) {
            PageCount = pageCount;
        }

        public override void DisplayInfo() {
            Console.WriteLine($"PDF: {Name}, Автор: {Author}, Тематика: {Topic}, Страниц: {PageCount}, Ключевые слова: {string.Join(", ", Keywords)}, Путь: {FilePath}");
        } 
    }

    class ExcelDocument : Document {
        public int SheetCount { get; set; }

        public ExcelDocument(string name, string author, string filePath, string topic, List<string> keywords, int sheetCount)
            : base(name, author, filePath, topic, keywords) {
            SheetCount = sheetCount;
        }

        public override void DisplayInfo() {
        Console.WriteLine($"Excel: {Name}, Автор: {Author}, Тематика: {Topic}, Листов: {SheetCount}, Ключевые слова: {string.Join(", ", Keywords)}, Путь: {FilePath}");
        } 
    }

    class TxtDocument : Document {
        public long FileSize { get; set; }

        public TxtDocument(string name, string author, string filePath, string topic, List<string> keywords, long fileSize)
            : base(name, author, filePath, topic, keywords) {
            FileSize = fileSize;
        }

        public override void DisplayInfo() {
            Console.WriteLine($"TXT: {Name}, Автор: {Author}, Тематика: {Topic}, Размер: {FileSize} байт, Ключевые слова: {string.Join(", ", Keywords)}, Путь: {FilePath}");
        } 
    }

    class HtmlDocument : Document {
        public string Encoding { get; set; }

        public HtmlDocument(string name, string author, string filePath, string topic, List<string> keywords, string encoding)
            : base(name, author, filePath, topic, keywords) {
            Encoding = encoding;
        }

        public override void DisplayInfo() {
            Console.WriteLine($"HTML: {Name}, Автор: {Author}, Тематика: {Topic}, Кодировка: {Encoding}, Ключевые слова: {string.Join(", ", Keywords)}, Путь: {FilePath}");
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
        
        manager.AddDocument(new WordDocument("Отчет", "Иванов", "C:/docs/report.docx", "Финансы", new List<string>{"отчет", "доходы"}, 1200));
        manager.AddDocument(new PdfDocument("Презентация", "Петров", "C:/docs/presentation.pdf", "Маркетинг", new List<string>{"презентация", "стратегия"}, 15));
        manager.AddDocument(new ExcelDocument("Финансы", "Сидоров", "C:/docs/finance.xlsx", "Бухгалтерия", new List<string>{"бюджет", "расходы"}, 3));
        manager.AddDocument(new TxtDocument("Заметки", "Кузнецов", "C:/docs/notes.txt", "Личные", new List<string>{"заметки", "идеи"}, 2048));
        manager.AddDocument(new HtmlDocument("Главная", "Андреев", "C:/docs/index.html", "Разработка", new List<string>{"веб", "код"}, "UTF-8"));
            
            Console.WriteLine("--- Список документов ---");
            manager.ShowDocuments();
        }

    }

}