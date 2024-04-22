﻿using Pizza_Store_BL_Library;
using Pizza_Store_Exception_Library;
using Pizza_Store_Model_library;
using System.Linq.Expressions;

namespace Pizza_Selling_Store_Management_application
{
    internal class Store
    {
        public PizzaBL pizzaBL;
        public CustomerBL customerBL;
        public OrderBL orderBL;
        List<int> cart ;
        public Store() {
            pizzaBL = new PizzaBL();
            customerBL = new CustomerBL();
            orderBL = new OrderBL();
            cart = new List<int>();
        }
        void GetUserTypeMenu()
        {
            Console.WriteLine("--------USER TYPE-----------");
            Console.WriteLine(" 1. Admin\n 2. Customer \n 3.Exit");

        }

        int GetUserType()
        {
            Console.WriteLine("Enter the choice :");
            return Convert.ToInt32(Console.ReadLine());
        }

        void CustomerMenu()
        {
            Console.WriteLine("---------CUSTOMER ACTIONS---------");
            Console.WriteLine(" 1. Pizza Menu\n 2. Order Pizza\n 3. Exit");
        }

        void AdminMenu()
        {
            Console.WriteLine("-------------ADMIN ACTIONS----------");
            Console.WriteLine(" 1. Add Pizza\n 2. Get Report \n 3.Exit ");
        }

        int GetChoice()
        {
            Console.WriteLine("Enter the choice :");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice; 
        }

        void GetPizzaMenu()
        {
            try
            {
                List<Pizza> pizzaList = pizzaBL.GetAllPizzaList();
                Console.WriteLine("-----------Menu----------");
                Console.WriteLine("Pizza-Id   | Pizza-Name   |   Ingredients |  Size  | \t Price ");
                foreach (Pizza pizza in pizzaList)
                {
                    Console.WriteLine($"\t{pizza.Id}  | {pizza.Name}   | \t{pizza.Ingredients}   | \t {pizza.Size}  | \t{pizza.Price} ");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }   
        }

        int GetPizzaId()
        {
            Console.WriteLine("Enter the pizza id to add pizza to cart or Enter 0 to place the Order :");
            return Convert.ToInt32(Console.ReadLine());
        }

        bool IsValidcheckGivenPizzaId(int pizzaId)
        {
            try
            {
                Pizza result = pizzaBL.GetPizzaById(pizzaId);
                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            return false;
        }

        void AddToCart(int id)
        {
            cart.Add(id);
        }

        Customer GetCustomerDetails()
        {
            
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            string phNumber = Console.ReadLine();
            Customer customer = new Customer(name ,address , phNumber);
            return customer;
        }

        string GetDeliveryAddress()
        {
            Console.WriteLine("Enter delivery address :");
            return Console.ReadLine();
        }

        double CalculateTotalAmount()
        {
            double totalAmount = 0;
            foreach(int pizzaId in cart)
            {
                try
                {
                    Pizza pizza = pizzaBL.GetPizzaById(pizzaId);
                    totalAmount += pizza.Price;
                }
                catch(Exception ex) { 
                    Console.WriteLine(ex.Message); 
                }
            }
            return totalAmount;
        }

        void PrintOrderDetails(List<int> cart , string DeliveryPreference , double amount , string deliveryAddress)
        {
            Console.WriteLine("---------------Order details-----------");
            Console.WriteLine("Pizza-Id    | Pizza-Name   |   Ingredients |  Size  |  Price ");
            foreach (int pizzaId in cart)
            {
                try
                {
                    Pizza pizza = pizzaBL.GetPizzaById(pizzaId);
                    Console.WriteLine($"   {pizza.Id}      |    {pizza.Name}      |    {pizza.Ingredients}      |    {pizza.Size}     |    {pizza.Price} ");
                }
                catch(Exception ex)
                {
                    Console.WriteLine (ex.Message);
                }
            }
            Console.WriteLine($"Total price : {amount}");
            Console.WriteLine($"Delivery preference : {DeliveryPreference}");
            if(DeliveryPreference == "delivery")
            {
                Console.WriteLine($"Delivery Address : {deliveryAddress}");
            }
        }
        void PlaceOrder()
        {
            Customer customer = GetCustomerDetails();
            try
            {
                customerBL.AddCustomer(customer);
                Console.WriteLine(" 1. Delivery \n  2. Pickup");
                int deliveryChoice = Convert.ToInt32(Console.ReadLine());
                string deliveryPreference = String.Empty;
                string deliveryAddress = String.Empty;
                double totalAmount = CalculateTotalAmount();

                if (deliveryChoice == 1)
                {
                    deliveryPreference = "Delivery";
                    deliveryAddress = GetDeliveryAddress();
                    totalAmount += 50.0;       // deliverycharge
                }
                else if (deliveryChoice == 2)
                {
                    deliveryPreference = "Pick up";
                }

                Order order = new Order(customer, cart, deliveryPreference, totalAmount, deliveryAddress);
                PrintOrderDetails(cart, deliveryPreference, totalAmount, deliveryAddress);
            }
            catch( Exception ex )
            {
                Console.WriteLine (ex.Message);
            }
                  
        }

        void OrderPizza()
        {
            int pizzaId;
            do
            {
                pizzaId = GetPizzaId();

                if (pizzaId != 0 && IsValidcheckGivenPizzaId(pizzaId))
                {
                   AddToCart(pizzaId);
                  Console.WriteLine($"pizza id {pizzaId} added to cart ");
                }   

            } while( pizzaId != 0 );

            if(pizzaId == 0) {
                PlaceOrder();
                Console.WriteLine("Ordered Successfully");
                cart = [];
            }
           
        }

        void AddPizza()
        {
            Console.WriteLine("Pizza Name :");
            string name = Console.ReadLine();
            Console.WriteLine("Pizza Ingredient :");
            string ingredient = Console.ReadLine();
            Console.WriteLine("Pizza size : (Medium / Small / Large)");
            string size = Console.ReadLine();
            Console.WriteLine("Pizza price :");
            double price = Convert.ToDouble(Console.ReadLine());

            Pizza pizza = new Pizza(name , ingredient , size , price);
            try
            {
                pizzaBL.AddPizza(pizza);
                Console.WriteLine("Pizza added successfully in menu");
            }
            catch( Exception ex )
            {
                Console.WriteLine (ex.Message);
            }
           
        }

        void Report()
        {
            Console.WriteLine("---------sales report----------");
            try
            {
                List<Order> orders = orderBL.GetAllOrders();
                Console.WriteLine("Order id    |  customer id   |    ordered items id       |   delivery preference  |   delivery address  |  Total Amount ");
                foreach (Order order in orders)
                {
                    string ordered_items = String.Empty;
                    for(int i=0;i<order.orderedItems.Count;i++)
                    {
                        if(ordered_items == String.Empty)ordered_items = order.orderedItems[i].ToString();
                        else ordered_items = ordered_items + ", " + order.orderedItems[i].ToString();

                    }
                    Console.WriteLine($"{order.Id}   |  {order.customer.Name}    |   {ordered_items}   |  {order.DeliveryPreference}  |  {order.DeliveryAddress}  | {order.TotalAmount}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        void duplicatePizzaAdd()
        {
            Pizza pizza1 = new Pizza("Margherita", "Tomato", "Medium", 180.0);
            Pizza pizza2 = new Pizza("Pepperoni", "Cheese", "Large", 200.0);

            try{
                pizzaBL.AddPizza(pizza1);
                pizzaBL.AddPizza(pizza2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        void StartUser()
        {
            duplicatePizzaAdd();
            int ch;

            do
            {
                CustomerMenu();
                ch = GetChoice();
                switch (ch)
                {
                    case 1:
                        GetPizzaMenu();
                        break;
                    case 2:
                        OrderPizza();
                        break;
                    case 3:
                        Console.WriteLine("thank you visit again");
                        break;

                }
            } while (ch != 3);
        }

        void StartAdmin()
        {
            int ch;
            do
            {
                AdminMenu();
                ch = GetChoice();
                switch (ch)
                {
                    case 1:
                        AddPizza();
                        break;
                    case 2:
                        Report();
                        break;
                    case 3:
                        Console.WriteLine("thank you visit again");
                        break;

                }
            } while (ch != 3);
        }
        void Start()
        {
            int userType;
            do
            {
                GetUserTypeMenu();
                userType = GetUserType();
                switch (userType)
                {
                    case 1:
                        StartAdmin();
                        break;
                    case 2:
                        StartUser();
                        break;
                }       
            } while (userType != 0);     
        }


        static void Main(string[] args)
        {
            Store store = new Store();
            store.Start();
        }
    }
}