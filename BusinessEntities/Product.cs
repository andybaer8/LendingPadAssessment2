using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        private string _name;
        private string _description;
        private double _price;

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string Description
        {
            get => _description;
            private set => _description = value;
        }

        public double Price
        {
            get => _price;
            private set => _price = value;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            _name = name;
        }

        public void SetDescription(string description)
        {
            _description = description;
        }

        public void SetPrice(double price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }
            _price = price;
        }
    }
}
