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
            bool running = true;
            
            while (running) {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Добавить документ");
                Console.WriteLine("2. Показать все документы");
                Console.WriteLine("3. Выйти");
                Console.Write("Выберите действие: ");
                
                string choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        Console.WriteLine("Выберите тип документа: 1 - Word, 2 - PDF, 3 - Excel, 4 - TXT, 5 - HTML");
                        string docType = Console.ReadLine();
                        Console.Write("Введите имя документа: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите автора: ");
                        string author = Console.ReadLine();
                        Console.Write("Введите путь к файлу: ");
                        string filePath = Console.ReadLine();
                        Console.Write("Введите тематику: ");
                        string topic = Console.ReadLine();
                        Console.Write("Введите ключевые слова (через запятую): ");
                        List<string> keywords = new List<string>(Console.ReadLine().Split(","));
                        
                        Document document = null;
                        switch (docType) {
                            case "1":
                                Console.Write("Введите количество слов: ");
                                int wordCount = int.Parse(Console.ReadLine());
                                document = new WordDocument(name, author, filePath, topic, keywords, wordCount);
                                break;
                            case "2":
                                Console.Write("Введите количество страниц: ");
                                int pageCount = int.Parse(Console.ReadLine());
                                document = new PdfDocument(name, author, filePath, topic, keywords, pageCount);
                                break;
                            case "3":
                                Console.Write("Введите количество листов: ");
                                int sheetCount = int.Parse(Console.ReadLine());
                                document = new ExcelDocument(name, author, filePath, topic, keywords, sheetCount);
                                break;
                            case "4":
                                Console.Write("Введите размер файла (в байтах): ");
                                long fileSize = long.Parse(Console.ReadLine());
                                document = new TxtDocument(name, author, filePath, topic, keywords, fileSize);
                                break;
                            case "5":
                                Console.Write("Введите кодировку файла: ");
                                string encoding = Console.ReadLine();
                                document = new HtmlDocument(name, author, filePath, topic, keywords, encoding);
                                break;
                            default:
                                Console.WriteLine("Выбранный тип документа не поддерживается.");
                                break;
                        }
                        
                        if (document != null) {
                            manager.AddDocument(document);
                            Console.WriteLine("Документ добавлен.");
                        }
                        break;
                    case "2":
                        manager.ShowDocuments();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }
            }
        }

    }

}