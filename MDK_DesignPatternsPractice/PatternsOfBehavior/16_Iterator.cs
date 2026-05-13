namespace MDK_DesignPatternsPractice.PatternsOfBehavior
{
    public interface IIterator<T>
    {
        bool HasNext();
        bool HasPrevious();
        T Next();
        T Previous();
        T Change(int number);
    }


    public class Playlist
    {
        private readonly List<string> _tracks = [];
        public void Add(string track) => _tracks.Add(track);
        public IIterator<string> CreateIterator() => new PlaylistIterator(this);

        public int Count => _tracks.Count;
        public string Get(int index) => _tracks[index];
    }


    public class PlaylistIterator(Playlist playlist) : IIterator<string>
    {
        private readonly Playlist _playlist = playlist;
        private int position = 0;

        public bool HasNext() => position < _playlist.Count - 1;

        public bool HasPrevious() => position > 0;

        public string Next()
        {
            if (HasNext())
            {
                return _playlist.Get(++position);
            }
            else
            {
                position = 0;
                return _playlist.Get(position);
            }
        }

        public string Previous()
        {
            if (HasPrevious())
            {
                return _playlist.Get(--position);
            }
            else
            {
                position = _playlist.Count - 1;
                return _playlist.Get(position);
            }
        }

        public string Change(int number)
        {
            if (number > _playlist.Count || number < 1)
            {
                Console.WriteLine("Номер трека не найден, включаю первый...");
            }
            else
            {
                position = number - 1;
            }
            return _playlist.Get(position);
        }
    }
}
