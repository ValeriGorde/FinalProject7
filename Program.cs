using System;

namespace FinalProject7
{
    /// <summary>
    /// Доставка (адрес, дата доставки)
    /// </summary>
    abstract class Delivery
    {

        public string adress;
        public string date;

        public Delivery(string adress, string date)
        {
            this.adress = adress;
            this.date = date;
        }

        public abstract void DeliveryInfo();
    }

    class Customer
    {
        public string email;

        public string Name { get; set; }
        public string Email 
        {
            set 
            {
                if (!value.Contains('@'))
                {
                    Console.WriteLine("Ваша почта должна начинаться со знака '@'.");
                }
                else { email = value; }
            }
            get { return email; }
        }

        public void PrintInfoToCustomer()
        {
            Console.WriteLine("{0}, на данную почту - {1} придёт сообщение о точном времени прибытия товара.", Name, email);
        }
    }

    /// <summary>
    /// Товар (наименование, тип товара)
    /// </summary>
    class Product
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    /// <summary>
    /// Доставка на дом (адрес дома, удобное время и дата)
    /// </summary>
    class HomeDelivery : Delivery
    {
        public HomeDelivery(string adress, string date) : base(adress, date)
        {
        }

        public override void DeliveryInfo()
        {
            Console.WriteLine("Доставка ожидается 15 числа в {0}, курьер будет по адресу {1}!", date, adress);
        }

    }
    /// <summary>
    /// Пункт самовывоза (адрес пункта, выбор адреса мб)
    /// </summary>

    class PickPointDelivery : Delivery
    {
        public int timeStorage = 31;
        public PickPointDelivery(string adress, string date) : base(adress, date) { }

        public int ChoosePoint(int num)
        {

            switch (num)
            {
                case 1:
                    Console.WriteLine("Ваша посылка будет ожидать вас по адресу: ул. Парк Победы д. 14");
                    break;
                case 2:
                    Console.WriteLine("Ваша посылка будет ожидать вас по адресу: ул. Лёни Голикова д. 30");
                    break;
                case 3:
                    Console.WriteLine("Ваша посылка будет ожидать вас по адресу: ул. Советская д. 2");
                    break;
            }
            return num;
        }
        public override void DeliveryInfo()
        {
            Console.WriteLine("Вы сможете забрать свой заказ 15 числа в {0}, товар хранится на скаде в течении {1} дня.", date, timeStorage);
        }
    }

    class ShopDelivery : Delivery
    {
        public int timeStorage = 5;
        public ShopDelivery(string adress, string date) : base(adress, date) { }
        public override void DeliveryInfo()
        {
            Console.WriteLine("Наш магазин находится по адресу: ул. Матросова д. 15, мф ждём вас 15 числа в {0}. Ваш товар будет хранится в магазине {1} дней.", date, timeStorage);
        }
    }

    class Order<TDelivery, TProduct> where TDelivery : Delivery where TProduct : Product
    {
        //public int correctNum = 0;
        //public static bool InputCheck(string num, out int correctNum)
        //{

        //    if (int.TryParse(num, out int intnum))
        //    {
        //        if (intnum > 0)
        //        {
        //            correctNum = intnum;
        //            return false;
        //        }
        //        else
        //        {
        //            correctNum = 0;
        //            Console.WriteLine("Вы ввели неверное значение! Попробуйте ещё раз.");
        //            return true;
        //        }
        //    }
        //}

        public void MakeOrder()
        {
            Customer customer = new Customer();
            Console.WriteLine("Вас приветсвует интернет-магазин 'Стилёво'!");
            Console.WriteLine("Для начала мы бы хотели узнать вас поближе.\nВведите ваше имя: ");
            customer.Name = Console.ReadLine();
            Console.WriteLine("Теперь нам нужна ваша почта, чтобы нужная информация о заказе доходила до вас. Введите почту: ");
            customer.Email = Console.ReadLine();

            Console.WriteLine("Выберите тип одежды, которую вы хотите преобрести: \n1. Вверх \n2. Низ \n3. Обувь");
            int type = int.Parse(Console.ReadLine());

            switch (type)
            {
                case 1:
                    Console.WriteLine("1. Футболка\n2. Лонгслив\n3. Свитшот");
                    int topType = int.Parse(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("1. Джинсы\n2. Брюки\n3. Шорты");
                    int bottomType = int.Parse(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("1. Кроссовки\n2. Сапоги\n3. Туфли");
                    int shoesType = int.Parse(Console.ReadLine());
                    break;
            }

            Console.WriteLine("Теперь нам нужно узнать ваш адресс. Введите адресс: ");
            string adress = Console.ReadLine();
            Console.WriteLine("Доставка ожидается 15 числа, введите желаемое время для доставки: ");
            string time = Console.ReadLine();
            Console.WriteLine("Отлично, теперь давайте решим, как вам удобнее будет получить товар: \n1. Курьером \n2. В магазине \n3. В любом удобном пункте самовывоза");
            int typeDelivery = int.Parse(Console.ReadLine());

            if (typeDelivery == 1)
            {
                HomeDelivery homeDelivery = new HomeDelivery(adress, time);
                homeDelivery.DeliveryInfo();
            }
            else if (typeDelivery == 2)
            {
                ShopDelivery shopDelivery = new ShopDelivery(adress, time);
                shopDelivery.DeliveryInfo();
            }
            else if (typeDelivery == 3)
            {
                Console.WriteLine("Вы должны выбрать удобный для вас пункт выдачи: \n1. ул. Советская д. 15 \n2. ул. Партизана Германа д. 4 \n3. ул. Парк Победы д.1");
                int choseStreet = int.Parse(Console.ReadLine());
                PickPointDelivery pickPointDelivery = new PickPointDelivery(adress, time);
                pickPointDelivery.ChoosePoint(choseStreet);
                pickPointDelivery.DeliveryInfo();
            }
            customer.PrintInfoToCustomer();
        }
    }

    class Shop
    {
        public void ShopInfo()
        {
            Console.WriteLine("Наш магазин находится в г. Санкт-Петербург, по адресу: ул. Морская д.3. " +
                "\nМы работаем без выходных и всегда ждём вас!" +
                "\nНаш телефон для связи - 89990991919.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
            bool check = false;
            do
            {
                Console.WriteLine("------Меню------");
                Console.WriteLine("1. Купить товар \n2. Узнать информацию о магазине \n3. Выйти");
                int numMenu = int.Parse(Console.ReadLine());
                switch (numMenu)
                {
                    case 1:
                        Order<Delivery, Product> order = new Order<Delivery, Product>();
                        order.MakeOrder();
                        check = true;
                        break;
                    case 2:
                        Shop shop = new Shop();
                        shop.ShopInfo();
                        check = true;
                        break;
                    case 3:
                        check = false;
                        break;
                }
            }
            while (check);

            Console.ReadKey();
        }
    }
}
