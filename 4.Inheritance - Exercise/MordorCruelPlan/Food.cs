using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordorCruelPlan
{
    public abstract class Food
    {
        
        public abstract int FoodValue { get; }

    }

    public class Cram : Food
    {
       
        private int _foodValue = 2;
        public override int FoodValue
        {
            get { return _foodValue; }
        }
    }
    public class Lembas : Food
    {

        private int _foodValue = 3;
        public override int FoodValue
        {
            get { return _foodValue; }
        }
    }
    public class Apple : Food
    {

        private int _foodValue = 1;
        public override int FoodValue
        {
            get { return _foodValue; }
        }
    }
    public class Melon : Food
    {

        private int _foodValue = 1;
        public override int FoodValue
        {
            get { return _foodValue; }
        }
    }
    public class HoneyCake : Food
    {

        private int _foodValue = 5;
        public override int FoodValue
        {
            get { return _foodValue; }
        }
    }
    public class Mushrooms : Food
    {

        private int _foodValue = -10;
        public override int FoodValue
        {
            get { return _foodValue; }
        }
    }
    public class AllOtherFood : Food
    {

        private int _foodValue = -1;
        public override int FoodValue
        {
            get { return _foodValue; }
        }
    }

    public static class Factory
    {
        public static Food GetInputFood(string food)
        {
            switch (food.ToLower())
            {
                case "cram":
                    return new Cram();
                case "apple":
                    return new Apple();
                case "lembas":
                    return new Lembas();
                case "honeycake":
                    return new HoneyCake();
                case "melon":
                    return new Melon();
                case "mushrooms":
                    return  new Mushrooms();
                default:
                    return new AllOtherFood();
            }
        }
    }
}
