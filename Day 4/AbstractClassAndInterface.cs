using System;

public abstract class DeliveryPlatform
{
    public string PartnerName { get; set; }

    public void TrackOrder()
    {
        Console.WriteLine("Order is being tracked : " + PartnerName);
    }

    public abstract void DeliveryOrder();
}

public interface IpaymentGateway
{
    void ProcessPayment();
}

class ZomatoPartner : DeliveryPlatform, IpaymentGateway
{
    public override void DeliveryOrder()
    {
        Console.WriteLine("Delivered in 20 mins");
    }

    public void ProcessPayment()
    {
        Console.WriteLine("Payment Gateway (Paytm) transaction started...");
    }
}

class DeliveryApp
{
    static void Main(string[] args)
    {
        DeliveryPlatform partner = new ZomatoPartner();
        partner.PartnerName = "Zomato";
        partner.TrackOrder();
        partner.DeliveryOrder();

        IpaymentGateway payment = (IpaymentGateway)partner;
        payment.ProcessPayment();
    }
}
