
using System.Xml.Serialization;
using System.Collections.Generic;

namespace JsonToXMLParser.BL.Xml
{
    [XmlRoot(ElementName = "Credential")]
    public class Credential
    {
        [XmlElement(ElementName = "Identity")]
        public string Identity { get; set; }
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }
        [XmlElement(ElementName = "SharedSecret")]
        public string SharedSecret { get; set; }
    }

    [XmlRoot(ElementName = "From")]
    public class From
    {
        public From()
        {
            Credential = new Credential();
        }
        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }
    }

    [XmlRoot(ElementName = "To")]
    public class To
    {
        public To()
        {
            Credential = new Credential();
        }
        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }
    }

    [XmlRoot(ElementName = "Sender")]
    public class Sender
    {
        public Sender()
        {
            Credential = new Credential();
        }
        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }
        [XmlElement(ElementName = "UserAgent")]
        public string UserAgent { get; set; }
    }

    [XmlRoot(ElementName = "Header")]
    public class Header
    {
        public Header()
        {
            From = new From();
            To = new To();
            Sender = new Sender();
        }
        [XmlElement(ElementName = "From")]
        public From From { get; set; }
        [XmlElement(ElementName = "To")]
        public To To { get; set; }
        [XmlElement(ElementName = "Sender")]
        public Sender Sender { get; set; }
    }

    [XmlRoot(ElementName = "Money")]
    public class Money
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Total")]
    public class Total
    {
        public Total()
        {
            Money = new Money();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
    }

    [XmlRoot(ElementName = "Name")]
    public class Name
    {
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Country")]
    public class Country
    {
        [XmlAttribute(AttributeName = "isoCountryCode")]
        public string IsoCountryCode { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PostalAddress")]
    public class PostalAddress
    {
        public PostalAddress()
        {
            Street = new List<string>();
            Country = new Country();
        }
        [XmlElement(ElementName = "DeliverTo")]
        public string DeliverTo { get; set; }
        [XmlElement(ElementName = "Street")]
        public List<string> Street { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "State")]
        public string State { get; set; }
        [XmlElement(ElementName = "PostalCode")]
        public string PostalCode { get; set; }
        [XmlElement(ElementName = "Country")]
        public Country Country { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "Email")]
    public class Email
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "CountryCode")]
    public class CountryCode
    {
        [XmlAttribute(AttributeName = "isoCountryCode")]
        public string IsoCountryCode { get; set; }
    }

    [XmlRoot(ElementName = "TelephoneNumber")]
    public class TelephoneNumber
    {
        public TelephoneNumber()
        {
            CountryCode = new CountryCode();
        }
        [XmlElement(ElementName = "CountryCode")]
        public CountryCode CountryCode { get; set; }
        [XmlElement(ElementName = "AreaOrCityCode")]
        public string AreaOrCityCode { get; set; }
        [XmlElement(ElementName = "Number")]
        public string Number { get; set; }
    }

    [XmlRoot(ElementName = "Phone")]
    public class Phone
    {
        public Phone()
        {
            TelephoneNumber = new TelephoneNumber();
        }
        [XmlElement(ElementName = "TelephoneNumber")]
        public TelephoneNumber TelephoneNumber { get; set; }
    }

    [XmlRoot(ElementName = "Address")]
    public class Address
    {
        public Address()
        {
            Name = new Name();
            PostalAddress = new PostalAddress();
            Email = new Email();
            Phone = new Phone();
        }
        [XmlElement(ElementName = "Name")]
        public Name Name { get; set; }
        [XmlElement(ElementName = "PostalAddress")]
        public PostalAddress PostalAddress { get; set; }
        [XmlElement(ElementName = "Email")]
        public Email Email { get; set; }
        [XmlElement(ElementName = "Phone")]
        public Phone Phone { get; set; }
        [XmlAttribute(AttributeName = "addressID")]
        public string AddressID { get; set; }
    }

    [XmlRoot(ElementName = "ShipTo")]
    public class ShipTo
    {
        public ShipTo()
        {
            Address = new Address();
        }
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
    }

    [XmlRoot(ElementName = "BillTo")]
    public class BillTo
    {
        public BillTo()
        {
            Address = new Address();
        }
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
    }

    [XmlRoot(ElementName = "Description")]
    public class Description
    {
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Shipping")]
    public class Shipping
    {
        public Shipping()
        {
            Description = new Description();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
    }

    [XmlRoot(ElementName = "Tax")]
    public class Tax
    {
        public Tax()
        {
            Money = new Money();
            Description = new Description();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
    }

    [XmlRoot(ElementName = "PCard")]
    public class PCard
    {
        [XmlAttribute(AttributeName = "expiration")]
        public string Expiration { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
    }

    [XmlRoot(ElementName = "Payment")]
    public class Payment
    {
        public Payment()
        {
            PCard = new PCard();
        }
        [XmlElement(ElementName = "PCard")]
        public PCard PCard { get; set; }
    }

    [XmlRoot(ElementName = "Extrinsic")]
    public class Extrinsic
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "OrderRequestHeader")]
    public class OrderRequestHeader
    {
        public OrderRequestHeader()
        {
            Total = new Total();
            ShipTo = new ShipTo();
            BillTo = new BillTo();
            Shipping = new Shipping();
            Tax = new Tax();
            Payment = new Payment();
            Extrinsic = new Extrinsic();
        }
        [XmlElement(ElementName = "Total")]
        public Total Total { get; set; }
        [XmlElement(ElementName = "ShipTo")]
        public ShipTo ShipTo { get; set; }
        [XmlElement(ElementName = "BillTo")]
        public BillTo BillTo { get; set; }
        [XmlElement(ElementName = "Shipping")]
        public Shipping Shipping { get; set; }
        [XmlElement(ElementName = "Tax")]
        public Tax Tax { get; set; }
        [XmlElement(ElementName = "Payment")]
        public Payment Payment { get; set; }
        [XmlElement(ElementName = "Comments")]
        public string Comments { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
        [XmlAttribute(AttributeName = "orderDate")]
        public string OrderDate { get; set; }
        [XmlAttribute(AttributeName = "orderID")]
        public string OrderID { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "ItemID")]
    public class ItemID
    {
        [XmlElement(ElementName = "SupplierPartID")]
        public string SupplierPartID { get; set; }
        [XmlElement(ElementName = "SupplierPartAuxiliaryID")]
        public string SupplierPartAuxiliaryID { get; set; }
    }

    [XmlRoot(ElementName = "UnitPrice")]
    public class UnitPrice
    {
        public UnitPrice()
        {
            Money = new Money();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
    }

    [XmlRoot(ElementName = "Classification")]
    public class Classification
    {
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ItemDetail")]
    public class ItemDetail
    {
        public ItemDetail()
        {
            UnitPrice = new UnitPrice();
            Description = new Description();
            Classification = new Classification();
        }
        [XmlElement(ElementName = "UnitPrice")]
        public UnitPrice UnitPrice { get; set; }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
        [XmlElement(ElementName = "UnitOfMeasure")]
        public string UnitOfMeasure { get; set; }
        [XmlElement(ElementName = "Classification")]
        public Classification Classification { get; set; }
        [XmlElement(ElementName = "ManufacturerPartID")]
        public string ManufacturerPartID { get; set; }
        [XmlElement(ElementName = "ManufacturerName")]
        public string ManufacturerName { get; set; }
        [XmlElement(ElementName = "URL")]
        public string URL { get; set; }


    }

    [XmlRoot(ElementName = "Segment")]
    public class Segment
    {
        [XmlAttribute(AttributeName = "description")]
        public string Description { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "Accounting")]
    public class Accounting
    {
        public Accounting()
        {
            Segment = new Segment();
        }
        [XmlElement(ElementName = "Segment")]
        public Segment Segment { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "PROJ")]
        public string Project { get; set; }
        [XmlAttribute(AttributeName = "DEPT")]
        public string Department { get; set; }
        [XmlAttribute(AttributeName = "ORG")]
        public string Organization { get; set; }
    }

    [XmlRoot(ElementName = "Charge")]
    public class Charge
    {
        public Charge()
        {
            Money = new Money();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
    }

    [XmlRoot(ElementName = "Distribution")]
    public class Distribution
    {
        public Distribution()
        {
            Accounting = new Accounting();
            Charge = new Charge();
        }
        [XmlElement(ElementName = "Accounting")]
        public Accounting Accounting { get; set; }
        [XmlElement(ElementName = "Charge")]
        public Charge Charge { get; set; }
    }

    [XmlRoot(ElementName = "ItemOut")]
    public class ItemOut
    {
        public ItemOut()
        {
            ItemID = new ItemID();
            ItemDetail = new ItemDetail();
            ShipTo = new ShipTo();
            Tax = new Tax();
            Distribution = new Distribution();
        }
        [XmlElement(ElementName = "ItemID")]
        public ItemID ItemID { get; set; }
        [XmlElement(ElementName = "ItemDetail")]
        public ItemDetail ItemDetail { get; set; }
        [XmlElement(ElementName = "ShipTo")]
        public ShipTo ShipTo { get; set; }
        [XmlElement(ElementName = "Shipping")]
        public Shipping Shipping { get; set; }
        [XmlElement(ElementName = "Tax")]
        public Tax Tax { get; set; }
        [XmlElement(ElementName = "Distribution")]
        public Distribution Distribution { get; set; }
        [XmlElement(ElementName = "Comments")]
        public string Comments { get; set; }
        [XmlAttribute(AttributeName = "lineNumber")]
        public string LineNumber { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
        [XmlAttribute(AttributeName = "requestedDeliveryDate")]
        public string RequestedDeliveryDate { get; set; }
        [XmlAttribute(AttributeName = "requisitionID")]
        public string RequisitionID { get; set; }
    }

    [XmlRoot(ElementName = "OrderRequest")]
    public class OrderRequest
    {
        public OrderRequest()
        {
            OrderRequestHeader = new OrderRequestHeader();
            ItemOut = new ItemOut();
        }
        [XmlElement(ElementName = "OrderRequestHeader")]
        public OrderRequestHeader OrderRequestHeader { get; set; }
        [XmlElement(ElementName = "ItemOut")]
        public ItemOut ItemOut { get; set; }
    }

    [XmlRoot(ElementName = "Request")]
    public class Request
    {
        public Request()
        {
            OrderRequest = new OrderRequest();
        }
        [XmlElement(ElementName = "OrderRequest")]
        public OrderRequest OrderRequest { get; set; }
        [XmlAttribute(AttributeName = "deploymentMode")]
        public string DeploymentMode { get; set; }
    }

    [XmlRoot(ElementName = "cXML")]
    public class CXML
    {
        public CXML()
        {
            Header = new Header();
            Request = new Request();
        }

        [XmlElement(ElementName = "Header")]
        public Header Header { get; set; }
        [XmlElement(ElementName = "Request")]
        public Request Request { get; set; }
        [XmlAttribute(AttributeName = "payloadID")]
        public string PayloadID { get; set; }
        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
    }

}
