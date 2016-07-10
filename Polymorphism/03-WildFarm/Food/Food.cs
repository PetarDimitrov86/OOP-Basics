using System.Runtime.InteropServices.WindowsRuntime;

namespace _03_WildFarm
{
    public abstract class Food
    {
        private int quantity;

        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}