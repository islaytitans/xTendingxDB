using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.Products.Enums;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace JonathanRobbins.xTendingxDB.Products.Entities
{
    [Serializable]
    public class Product
    {
        public Item Item { get; private set; }
        public string Title { get; set; }
        public string Sku { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Quote { get; set; }
        public ShipType Type { get; set; }
        public IEnumerable<Factions> Factions { get; set; }

        public Product()
        {

        }

        public Product(Item item)
        {
            if (item == null)
            {
                return;
            }

            Item = item;
            Title = item["Title"];
            Sku = item["Sku"];
            Summary = item["Summary"];
            Description = item["Description"];
            Image = item["Image"];
            double price;
            if (double.TryParse(item["Price"], out price))
            {
                Price = price;
            }
            Quote = item["Quote"];
            Type = DetermineShipType(item["Type"]);
            Factions = DetermineFactions(item.Fields["Factions"]);
        }

        public ShipType DetermineShipType(string shipItemId)
        { 
            if (string.IsNullOrWhiteSpace(shipItemId))
            {
                throw new ArgumentNullException("ShipItemId cannot be null");
            }

            ShipType shipType;
            switch (shipItemId.Trim().ToUpper())
            {
                case "{76757203-1447-44A7-AFBB-310B4C9FBC7A}":
                    shipType = ShipType.BattleStation; 
                    break;
                case "{1DCD94C0-76EF-42DC-A0BB-6A0E2B0ECD3E}":
                    shipType = ShipType.Fighter;
                    break;
                case "{5364FB43-29B2-46A7-86C5-703404240822}":
                    shipType = ShipType.Ship;
                    break;
                case "{57F7ED47-25F7-4332-A498-C577D670F6D0}":
                    shipType = ShipType.Transport;
                    break;
                default:
                    throw new Exception("Ship Type is not set on ship with id - " + shipItemId);
            }

            return shipType;
        }

        public IEnumerable<Enums.Factions> DetermineFactions(Field factionField)
        {
            if (factionField == null)
            {
                throw new ArgumentNullException("factionField");
            }

            var multilistField = (MultilistField) factionField;
            if (multilistField == null)
            {
                throw new Exception("Field is not a multilist field - " + factionField.ID);
            }

            var factionIds = multilistField.TargetIDs;

            if (factionIds == null || !factionIds.Any())
            {
                throw new Exception("No faction set in faction field - " + factionField.ID);
            }

            var factions = new List<Enums.Factions>();

            if (factionIds.Contains(new ID("{E5BF1E72-C4C9-4562-A457-4870299A4A08}")))
            {
                factions.Add(Enums.Factions.GalacticEmpire);
            }
            if (factionIds.Contains(new ID("{0FC33635-3AC2-45AC-942C-DF79C6DC1684}")))
            {
                factions.Add(Enums.Factions.RebelsAlliance);
            }

            if (!factions.Any())
            {
                throw new Exception("Failed to determine factions - " + factionField.ID);
            }

            return factions;
        }
    }
}
