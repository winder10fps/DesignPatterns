namespace MDK_DesignPatternsPractice.StructuralPatterns
{
    public abstract class FileSystemItem(string name)
    {
        public string Name { get; private set; } = name;
        public abstract void Print(string indent = "");
        public abstract int GetSize();

        public void Rename (string newName) => Name = newName;
    }


    public class File(string name, int size) : FileSystemItem(name)
    {
        private readonly int _size = size;

        public override void Print(string indent = "")
        {
            Console.WriteLine($"{indent}| {Name}");
        }

        public override int GetSize() => _size;
    }


    public class Folder(string name) : FileSystemItem(name)
    {
        private readonly List<FileSystemItem> _items = [];

        public void Add(FileSystemItem item) => _items.Add(item);

        public void Remove(FileSystemItem item) => _items.Remove(item);

        public override void Print(string indent = "")
        {
            Console.WriteLine($"{indent}| {Name}");
            foreach (var item in _items)
            {
                item.Print(indent + "  ");
            }
        }

        public override int GetSize() => _items.Sum(item => item.GetSize());
    }
}
