using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class BankAccount
    {

        private int id;
        private decimal balance;
        public BankAccount()
        {
            this.id = 0;
            this.balance = 0;
        }
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }
       public bool Withdraw(decimal amount)
       {
          if(this.Balance >= amount)
          {
            this.Balance -= amount;
            return true;
          }
          else
          {
            return false;
          }
       
       }
    public override string ToString()
    {

        return ($"Account ID{this.Id}, balance {this.Balance:f2}");
    }
    
}

