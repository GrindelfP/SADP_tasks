namespace taskSix
{
    public class Movie
    {
        public string Name { get; }
        public int Duration { get; }
        public bool HasOscars { get; }

        public Movie(string name, int duration, bool hasOscars)
        {
            Name = name;
            Duration = duration;
            HasOscars = hasOscars;
        }

        public bool HasEqualKeyTo(string name) => Name == name;

        public override string ToString()
        {
            string oscars = HasOscars ? "есть 'Оскары'" : "нет 'Оскаров'";
            return $"Название: '{Name}', Длится {Duration} минут, {oscars}";
        }

        public override bool Equals(object obj)
        {
            bool equals = false;
            if (obj.GetType() == typeof(Movie))
            {
                var comparable = obj as Movie;
                if (comparable.Name == this.Name
                    && comparable.Duration == this.Duration
                    && comparable.HasOscars == this.HasOscars) equals = true;
            }
            
            return equals;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Duration.GetHashCode() + this.HasOscars.GetHashCode();
        }

        public static bool operator >(Movie a, Movie b)
        {
            bool isGreater = false;
            if (a.Duration > b.Duration) isGreater = true;
            if (a.Duration == b.Duration && a.Name != b.Name) 
            {
                if (a.Name.Length >= b.Name.Length)
                {
                    for (int i = 0; i < a.Name.Length; i++)
                    {
                        if (a.Name[i] > b.Name[i]) isGreater = true;
                    }
                }
                if (a.Name.Length < b.Name.Length)
                {
                    for (int i = 0; i < b.Name.Length; i++)
                    {
                        if (a.Name[i] > b.Name[i]) isGreater = true;
                    }
                }
            }
            
            return isGreater;
        }
        public static bool operator <(Movie a, Movie b)
        {
            bool isSmaller = false;
            if (a.Duration < b.Duration) isSmaller = true;
            else
            {
                if (a.Name != b.Name && a.Name.Length >= b.Name.Length)
                {
                    for (int i = 0; i < a.Name.Length; i++)
                    {
                        if (a.Name[i] < b.Name[i]) isSmaller = true;
                    }
                }
                if (a.Name != b.Name && a.Name.Length < b.Name.Length)
                {
                    for (int i = 0; i < b.Name.Length; i++)
                    {
                        if (a.Name[i] < b.Name[i]) isSmaller = true;
                    }
                }
            }

            return isSmaller;
        }
        public static bool operator ==(Movie a, Movie b) => a.Equals(b);
        public static bool operator !=(Movie a, Movie b) => !a.Equals(b);
    }
}