﻿using System.Globalization;

namespace Lab5;

public abstract class SomeEvent<T> : IEvent, IEquatable<SomeEvent<T>>
{
    public string Title { get; protected set; }
    public string Organisation { get; protected set; }
    public int MaxTickets { get; protected set; }

    public T Date { get; protected set; }
    
    protected SomeEvent()
    {
        Title = "unset";
        Console.WriteLine($"{Title} constructor was called of {GetType().Name}");
    }

    protected SomeEvent(SomeEvent<T> someEvent)
    {
        Title = someEvent.Title;
        Date = someEvent.Date;
        Console.WriteLine($"{Title} constructor was called of {GetType().Name}");
    }


    public SomeEvent(string title, T date)
    {
        Title = title;
        Date = date;
        Console.WriteLine($"{Title} constructor was called of {GetType().Name}");
    }

    ~SomeEvent()
    {
        Console.WriteLine($"{Title} destructor was called of {GetType().Name}");
        Title = "";
    }

    public virtual string Print()
    {
        return $"Title: {Title} Date: {Date} Organosator: {Organisation}, MaxTicket: {MaxTickets}";
    }

    public abstract IEvent Copy(IEvent source);

    public static SomeEvent<T> CreateFromKeyboard<T1>() where T1 : SomeEvent<T>, new()
    {
        Console.WriteLine($"Create from keyboard {typeof(T).Name} object.");
        Console.Write("Input Event title: ");
        var title = Console.ReadLine();
        while (title == string.Empty)
            title = Console.ReadLine();

        Console.Write("Input Event organisator tickets: ");
        var org = Console.ReadLine();
        while (org is null)
            org = Console.ReadLine();
        
        Console.Write("Input Event max tickets: ");
        var item = new T1()
        {
            Title = title!,
            Organisation = org,
            MaxTickets = Program.ParseNumber("Input max tickets")
        };
        
        item.EditUniqueFields();
        return item;
    }
    
    public IEvent EditFromKeyboard()
    {
        Console.Write("Input Event title: ");
        var title = Console.ReadLine();
        while (title is null)
            title = Console.ReadLine();

        Console.Write("Input Event organisator: ");
        var org = Console.ReadLine();
        while (org is null)
            org = Console.ReadLine();
        
        
        Title = title;
        Organisation = org;
        Console.Write("Input Event max tickets: ");
        MaxTickets = Program.ParseNumber("Input max tickets");
        EditUniqueFields();
        return this;
    }

    protected abstract void EditUniqueFields();

    public static DateTime ParseData()
    {
        Console.Write("Input Date title in style mm/dd/yy hh:mm:ss: ");
        var date = DateTime.MinValue;
        
        while (date.CompareTo(DateTime.Now) != 1)
        {
            var input = Console.ReadLine();
            while (!DateTime.TryParseExact(input, "G",CultureInfo.InvariantCulture, DateTimeStyles.None,out date))
                input = Console.ReadLine();
        }

        return date;
    }

    public bool Equals(SomeEvent<T>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Title == other.Title && Organisation == other.Organisation && MaxTickets == other.MaxTickets && EqualityComparer<T>.Default.Equals(Date, other.Date);
    }
    
    public static bool operator ==(SomeEvent<T> obj1, SomeEvent<T> obj2)
    {
        if (ReferenceEquals(obj1, obj2)) 
            return true;
        if (ReferenceEquals(obj1, null)) 
            return false;
        if (ReferenceEquals(obj2, null))
            return false;
        return obj1.Equals(obj2);
    }
    
    public static bool operator !=(SomeEvent<T> obj1, SomeEvent<T> obj2) => !(obj1 == obj2);
    
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SomeEvent<T>)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Organisation, MaxTickets, Date);
    }
}