namespace Interfaces
{
    public interface IPrintable
    {
        string Print();
    }

    public class Document : IPrintable
    {
        private readonly string _content;

        public Document(string content)
        {
            _content = content;
        }

        public string Print() => _content;
    }

    public class Photo : IPrintable
    {
        public string Print() => "[:D]";
    }

    public static class Printer
    {
        public static string PrintDocument(IPrintable printable) => printable.Print();
    }
}