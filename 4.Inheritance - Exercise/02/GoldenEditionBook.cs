using System;
using System.Collections.Generic;
using System.Text;


public class GoldenEditionBook : Book
{
    private decimal _price;

    protected override decimal Price
    {
        get { return base.Price * (decimal) 1.3; }
       // set { _price = value; }
    }

    public GoldenEditionBook(string name, string title, decimal price) : base(name, title, price)
    {
         
    }
}
