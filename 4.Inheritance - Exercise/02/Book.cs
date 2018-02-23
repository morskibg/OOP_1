using System;
using System.Collections.Generic;
using System.Text;

//title, author and price
public class Book
{
    
    private string authorName;
    private string title;
    private decimal price;

    

    protected string AuthorName
    {
        get => authorName;
        set
        {
            int idx = value.IndexOf(' ') + 1;
            if (idx != 0 && char.IsDigit(value[idx]))
            {
                throw  new ArgumentException("Author not valid!");
            }
            authorName = value;
        }
    }

    protected string Title
    {
        get => title;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    protected virtual decimal Price
    {
        get => price;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public Book(string name, string title, decimal price)
    {
        this.AuthorName = name;
        this.Title = title;
        this.Price = price;
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.AuthorName}")
            .AppendLine($"Price: {this.Price:f2}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;

    }
}