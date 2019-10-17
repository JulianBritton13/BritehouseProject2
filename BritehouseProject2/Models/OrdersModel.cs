using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BritehouseProject2.Models
{
    public class OrdersModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Row ID")]
        public Int32 Row_ID { get; set; }
        [BsonElement("Order ID")]
        public string OrderID { get; set; }
        [BsonElement("Order Date")]
        public string Order_Date { get; set; }
        [BsonElement("Ship Date")]
        public string Ship_Date { get; set; }
        [BsonElement("Ship Mode")]
        public string Ship_Mode { get; set; }
        [BsonElement("Customer ID")]
        public string Customer_ID { get; set; }
        [BsonElement("Segment")]
        public string Segment { get; set; }
        [BsonElement("City")]
        public string City { get; set; }
        [BsonElement("State")]
        public string State { get; set; }
        [BsonElement("Country")]
        public string Country { get; set; }
        [BsonElement("Region")]
        public string Region { get; set; }
        [BsonElement("Market")]
        public string Market { get; set; }
        [BsonElement("Product ID")]
        public string Product_ID { get; set; }
        [BsonElement("Category")]
        public string Category { get; set; }
        [BsonElement("Sub-Category")]
        public string Sub_Category { get; set; }
        [BsonElement("Product Name")]
        public string Product_Name { get; set; }
        [BsonElement("Sales")]
        public string Sales { get; set; }
        [BsonElement("Quantity")]
        public Int32 Quantity { get; set; }
        
        [BsonElement("Profit")]
        public string Profit { get; set; }
        [BsonElement("Shipping Cost")]
        public double Shipping_Cost { get; set; }
        [BsonElement("Order Priority")]
        public string Order_Priority { get; set; }
    }
}