namespace StructSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            // Struct'ı instance alarak veya direkt kullanabilirim
            // Instance alarak
            //MyStruct myStruct = new MyStruct();
            //Console.WriteLine($"{myStruct.x} - {myStruct.y} - {myStruct.z}"); // 0 - false -
            // Instance almadan
            //MyStruct myStruct2;
            //// initial değerler atamalıyım
            //myStruct2.x = 1;
            //myStruct2.y = true;
            //myStruct2.z = "Sample";
            //Console.WriteLine($"{myStruct2.x} - {myStruct2.y} - {myStruct2.z}"); // 0 - false -

            MyStruct myStruct = new MyStruct();
            myStruct.x = 2;
            myStruct.y = true;
            myStruct.Z = "4";
            Console.WriteLine($"{myStruct.x} - {myStruct.y} - {myStruct.Z}");
            Console.WriteLine(myStruct.Operation());
            Console.WriteLine(MyStruct.GetFullName());

            /////////////////////////////////////////////////////////////

            YourStruct.YourClass yourClass = new YourStruct.YourClass();
            yourClass.Y = 24;
            yourClass.Z = DateTime.Now.AddYears(-10);
            Console.WriteLine($"{yourClass.Y} - {yourClass.Z.ToLongDateString()}");

            TheClass.TheStruct theStruct = new TheClass.TheStruct();
            theStruct.Y = 25;
            Console.WriteLine($"{theStruct.Y}");

            /////////////////////////////////////////////////////////////            
            AStruct aStruct = new AStruct();
            aStruct.x = 18;
            aStruct.y = 8;

            AStruct aStruct2 = aStruct; // deep copy: value eşitler
            aStruct2.x = 3;
            aStruct2.y = 13;
            Console.WriteLine($"{aStruct.x} - {aStruct.y}"); // 18 - 8
            Console.WriteLine($"{aStruct2.x} - {aStruct2.y}"); // 3 - 13 
            // struct value type oldukları için böyle çıktı alırız. Class olsaydı ikisi için de 3 - 13 olurdu (shallow copy: adres kopyalar)

            ///////////////////////////////////////////////////////////////
            Book book = new Book();
            Console.WriteLine(book.ToString());

            Book book1 = new Book(1, "Fight Club", "Crime", "123456789", "Chuck Palahniuk");
            Console.WriteLine(book1.ToString());
        }
    }

    struct AStruct
    {
        public int x; 
        public int y;
    }

    // Struct içerisinde class tanımlayabilirim
    struct YourStruct
    {
        public int x;

        public class YourClass // Bu class başka bir class'tan inherit alabilir
        {
            public int Y { get; set; }
            public DateTime Z { get; set; }
        }
    }
    // Class içerisinde struct tanımlayabilirim
    class TheClass
    {
        public int x;

        public struct TheStruct
        {
            public int Y { get; set; }
        }
    }

    struct MyStruct
    {
        public int x;
        public bool y;
        public string Z { get; set; }

        public double Operation()
        {
            if (y)
            {
                return x * int.Parse(Z);
            }

            return -1;
        }

        // struct içerisinde static yapı da barındırabilirim
        public static string GetFullName()
        {
            return "Jax Teller";
        }
    }

    //struct MyStruct
    //{
    //    public int x;
    //    public bool y;
    //    public string z;
    //}

    interface IInterface
    {
        void X();
        void Y(bool x);
    }

    struct Struct1 : IInterface
    {
        public void X()
        {
            throw new NotImplementedException();
        }

        public void Y(bool x)
        {
            throw new NotImplementedException();
        }
    }

    //struct Struct1 : Struct2
    //struct Struct1 : Class1
    struct Struct2 // class veya struct'tan inheritance yapısını desteklemez, sadece Interface'ten inheritance'i destekler
    {
        // Method field property tanımlanabilir
        int x;
        bool y;
    }

    struct Struct3
    {
        int a;
        bool b;
    }

    class Class1
    {
        int i;
        bool j;
    }

    /////////////////////////////////////////////////////
     public struct Book
    {
        public Book ()
        {
            BookId = 1881;
            BookName = "Nutuk";
            BookType = "History";
            ISBN = "18811938";
            Author = "Mustafa Kemal Atatürk";
        }
        public Book(int bookId, string bookName, string bookType)
        {
            BookId = bookId;
            BookName = bookName;
            BookType = bookType;
            // Diğer property'lere değer atanmazsa veri tipinin initial değerleri geçerli olur. Atama yapman iyi olur.
        }
        public Book(int bookId, string bookName, string bookType, string isbn, string author)
        {
            BookId = bookId;
            BookName = bookName;
            BookType = bookType;
            ISBN = isbn;
            Author = author; 
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookType { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return
                $"Book ID: {BookId} \n" +
                $"Book Name: {BookName} \n" +
                $"Book Type: {BookType} \n" +
                $"ISBN: {ISBN} \n" +
                $"Author: {Author}";
        }

    }
}
