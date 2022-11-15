namespace taskFour
{
    public readonly struct Movie
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
    }
}
