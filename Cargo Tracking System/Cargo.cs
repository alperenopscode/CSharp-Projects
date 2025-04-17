using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CargoTrackingSystem
{
    public abstract class Cargo
    {
        public string SenderName { get; protected set; }
        public string ReceiverName { get; protected set; }
        public string SenderCity { get; protected set; }
        public string DeliveryCity { get; protected set; }
        public double CargoWeight { get; protected set; }
        public string CargoType { get; protected set; }
        public double CargoPrice { get; protected set; }

        public Cargo(string senderName, string receiverName, string senderCity, string deliveryCity, double cargoWeight, string cargoType)
        {
            SenderName = senderName;
            ReceiverName = receiverName;
            SenderCity = senderCity;
            DeliveryCity = deliveryCity;
            CargoWeight = cargoWeight;
            CargoType = cargoType;
        }

        public void BusinessConnection() // Cargo Business Connection Method
        {
            Business.CargoConnection(this);
        }

        public abstract void CargoPriceCalculator(); // Cargo Price Calculator Method
    }

    // CARGO TYPE CLASSES
    public class FragileCargo : Cargo // Fragile Cargo Class
    {
        public FragileCargo(string senderName, string receiverName, string senderCity, string deliveryCity, double cargoWeight, string cargoType)
            : base(senderName, receiverName, senderCity, deliveryCity, cargoWeight, cargoType)
        {
            CargoPriceCalculator();
            BusinessConnection();
        }

        public override void CargoPriceCalculator()
        {
            base.CargoPrice += CargoWeight * 2.0;
        }
    }

    public class PerishableCargo : Cargo // Perishable Cargo Class
    {
        public PerishableCargo(string senderName, string receiverName, string senderCity, string deliveryCity, double cargoWeight, string cargoType)
            : base(senderName, receiverName, senderCity, deliveryCity, cargoWeight, cargoType)
        {
            CargoPriceCalculator();
            BusinessConnection();
        }

        public override void CargoPriceCalculator()
        {
            base.CargoPrice += CargoWeight * 1.8;
        }
    }

    public class HazardousCargo : Cargo // Hazardous Cargo Class
    {
        public HazardousCargo(string senderName, string receiverName, string senderCity, string deliveryCity, double cargoWeight, string cargoType)
            : base(senderName, receiverName, senderCity, deliveryCity, cargoWeight, cargoType)
        {
            CargoPriceCalculator();
            BusinessConnection();
        }

        public override void CargoPriceCalculator()
        {
            base.CargoPrice += CargoWeight * 2.5;
        }
    }

    public class ValuableCargo : Cargo // Valuable Cargo Class
    {
        public ValuableCargo(string senderName, string receiverName, string senderCity, string deliveryCity, double cargoWeight, string cargoType)
            : base(senderName, receiverName, senderCity, deliveryCity, cargoWeight, cargoType)
        {
            CargoPriceCalculator();
            BusinessConnection();
        }

        public override void CargoPriceCalculator()
        {
            base.CargoPrice += CargoWeight * 3.0;
        }
    }

    public class ExpressCargo : Cargo // Express Cargo Class
    {
        public ExpressCargo(string senderName, string receiverName, string senderCity, string deliveryCity, double cargoWeight, string cargoType)
            : base(senderName, receiverName, senderCity, deliveryCity, cargoWeight, cargoType)
        {
            CargoPriceCalculator();
            BusinessConnection();
        }

        public override void CargoPriceCalculator()
        {
            base.CargoPrice += CargoWeight * 2.2;
        }
    }

    public class UnknownCargo : Cargo // Unknown Cargo Class
    {
        public UnknownCargo(string senderName, string receiverName, string senderCity, string deliveryCity, double cargoWeight, string cargoType)
            : base(senderName, receiverName, senderCity, deliveryCity, cargoWeight, cargoType)
        {
            CargoPriceCalculator();
            BusinessConnection();
        }

        public override void CargoPriceCalculator()
        {
            base.CargoPrice += CargoWeight * 3.0;
        }
    }
}
