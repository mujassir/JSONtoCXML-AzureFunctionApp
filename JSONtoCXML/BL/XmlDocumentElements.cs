using System.Xml.Serialization;

namespace JsonToXMLParser.BL.Xml
{

    /* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */



    [XmlRoot(ElementName = "Credential")]
    public class Credential
    {
        [XmlElement(ElementName = "Identity")]
        public string Identity { get; set; }
        [XmlElement(ElementName = "SharedSecret")]
        public string SharedSecret { get; set; }
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "Name")]
    public class Name
    {
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "City")]
    public class City
    {
        [XmlAttribute(AttributeName = "cityCode")]
        public string CityCode { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Municipality")]
    public class Municipality
    {
        [XmlAttribute(AttributeName = "municipalityCode")]
        public string MunicipalityCode { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "State")]
    public class State
    {
        [XmlAttribute(AttributeName = "isoStateCode")]
        public string IsoStateCode { get; set; }
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

    [XmlRoot(ElementName = "Extrinsic")]
    public class Extrinsic
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "PostalAddress")]
    public class PostalAddress
    {
        public PostalAddress()
        {
            City = new City();
            Municipality = new Municipality();
            Country = new Country();
            Extrinsic = new Extrinsic();
        }
        [XmlElement(ElementName = "DeliverTo")]
        public string DeliverTo { get; set; }
        [XmlElement(ElementName = "Street")]
        public string Street { get; set; }
        [XmlElement(ElementName = "City")]
        public City City { get; set; }
        [XmlElement(ElementName = "Municipality")]
        public Municipality Municipality { get; set; }
        [XmlElement(ElementName = "State")]
        public State State { get; set; }
        [XmlElement(ElementName = "PostalCode")]
        public string PostalCode { get; set; }
        [XmlElement(ElementName = "Country")]
        public Country Country { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "Email")]
    public class Email
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "preferredLang")]
        public string PreferredLang { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "CountryCode")]
    public class CountryCode
    {
        [XmlAttribute(AttributeName = "isoCountryCode")]
        public string IsoCountryCode { get; set; }
        [XmlText]
        public string Text { get; set; }
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
        [XmlElement(ElementName = "Extension")]
        public string Extension { get; set; }
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
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "Fax")]
    public class Fax
    {
        public Fax()
        {
            TelephoneNumber = new TelephoneNumber();

        }
        [XmlElement(ElementName = "TelephoneNumber")]
        public TelephoneNumber TelephoneNumber { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "URL")]
    public class URL
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Creator")]
    public class Creator
    {
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Description")]
    public class Description
    {
        [XmlElement(ElementName = "ShortName")]
        public string ShortName { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
    }

    [XmlRoot(ElementName = "IdReference")]
    public class IdReference
    {
        public IdReference()
        {
            Creator = new Creator();
            Description = new Description();

        }
        [XmlElement(ElementName = "Creator")]
        public Creator Creator { get; set; }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }
        [XmlAttribute(AttributeName = "identifier")]
        public string Identifier { get; set; }
    }

    [XmlRoot(ElementName = "Contact")]
    public class Contact
    {
        public Contact()
        {
            Name = new Name();
            PostalAddress = new PostalAddress();
            Email = new Email();
            Phone = new Phone();
            Fax = new Fax();
            URL = new URL();
            IdReference = new IdReference();
            Extrinsic = new Extrinsic();
            Fax = new Fax();

        }
        [XmlElement(ElementName = "Name")]
        public Name Name { get; set; }
        [XmlElement(ElementName = "PostalAddress")]
        public PostalAddress PostalAddress { get; set; }
        [XmlElement(ElementName = "Email")]
        public Email Email { get; set; }
        [XmlElement(ElementName = "Phone")]
        public Phone Phone { get; set; }
        [XmlElement(ElementName = "Fax")]
        public Fax Fax { get; set; }
        [XmlElement(ElementName = "URL")]
        public URL URL { get; set; }
        [XmlElement(ElementName = "IdReference")]
        public IdReference IdReference { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
        [XmlAttribute(AttributeName = "addressID")]
        public string AddressID { get; set; }
        [XmlAttribute(AttributeName = "addressIDDomain")]
        public string AddressIDDomain { get; set; }
        [XmlAttribute(AttributeName = "role")]
        public string Role { get; set; }
    }

    [XmlRoot(ElementName = "Correspondent")]
    public class Correspondent
    {
        public Correspondent()
        {
            Contact = new Contact();
            Extrinsic = new Extrinsic();


        }
        [XmlElement(ElementName = "Contact")]
        public Contact Contact { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
        [XmlAttribute(AttributeName = "preferredLanguage")]
        public string PreferredLanguage { get; set; }
    }

    [XmlRoot(ElementName = "From")]
    public class From
    {
        public From()
        {
            Credential = new Credential();
            Correspondent = new Correspondent();
        }
        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }
        [XmlElement(ElementName = "Correspondent")]
        public Correspondent Correspondent { get; set; }
    }

    [XmlRoot(ElementName = "To")]
    public class To
    {
        public To()
        {
            Credential = new Credential();
            Correspondent = new Correspondent();
        }
        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }
        [XmlElement(ElementName = "Correspondent")]
        public Correspondent Correspondent { get; set; }
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

    [XmlRoot(ElementName = "Node")]
    public class Node
    {
        public Node()
        {
            Credential = new Credential();
        }
        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }
        [XmlAttribute(AttributeName = "itemDetailsRequired")]
        public string ItemDetailsRequired { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "Path")]
    public class Path
    {
        public Path()
        {
            Node = new Node();
        }
        [XmlElement(ElementName = "Node")]
        public Node Node { get; set; }
    }

    [XmlRoot(ElementName = "OriginalDocument")]
    public class OriginalDocument
    {
        [XmlAttribute(AttributeName = "payloadID")]
        public string PayloadID { get; set; }
    }

    [XmlRoot(ElementName = "Header")]
    public class Header
    {
        public Header()
        {
            From = new From();
            To = new To();
            Sender = new Sender();
            Path = new Path();
            OriginalDocument = new OriginalDocument();
        }
        [XmlElement(ElementName = "From")]
        public From From { get; set; }
        [XmlElement(ElementName = "To")]
        public To To { get; set; }
        [XmlElement(ElementName = "Sender")]
        public Sender Sender { get; set; }
        [XmlElement(ElementName = "Path")]
        public Path Path { get; set; }
        [XmlElement(ElementName = "OriginalDocument")]
        public OriginalDocument OriginalDocument { get; set; }
    }

    [XmlRoot(ElementName = "Money")]
    public class Money
    {
        [XmlAttribute(AttributeName = "alternateAmount")]
        public string AlternateAmount { get; set; }
        [XmlAttribute(AttributeName = "alternateCurrency")]
        public string AlternateCurrency { get; set; }
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "OriginalPrice")]
    public class OriginalPrice
    {
        public OriginalPrice()
        {
            Money = new Money();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "DeductionAmount")]
    public class DeductionAmount
    {
        public DeductionAmount()
        {
            Money = new Money();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
    }

    [XmlRoot(ElementName = "AdditionalDeduction")]
    public class AdditionalDeduction
    {
        public AdditionalDeduction()
        {
            DeductionAmount = new DeductionAmount();
        }
        [XmlElement(ElementName = "DeductionAmount")]
        public DeductionAmount DeductionAmount { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "TaxAdjustmentAmount")]
    public class TaxAdjustmentAmount
    {
        public TaxAdjustmentAmount()
        {
            Money = new Money();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
    }

    [XmlRoot(ElementName = "TaxableAmount")]
    public class TaxableAmount
    {
        public TaxableAmount()
        {
            Money = new Money();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
    }

    [XmlRoot(ElementName = "TaxAmount")]
    public class TaxAmount
    {
        public TaxAmount()
        {
            Money = new Money();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
    }

    [XmlRoot(ElementName = "TaxLocation")]
    public class TaxLocation
    {
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TriangularTransactionLawReference")]
    public class TriangularTransactionLawReference
    {
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ExemptReason")]
    public class ExemptReason
    {
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TaxExemption")]
    public class TaxExemption
    {
        public TaxExemption()
        {
            ExemptReason = new ExemptReason();
        }
        [XmlElement(ElementName = "ExemptReason")]
        public ExemptReason ExemptReason { get; set; }
        [XmlAttribute(AttributeName = "exemptCode")]
        public string ExemptCode { get; set; }
    }

    [XmlRoot(ElementName = "TaxDetail")]
    public class TaxDetail
    {
        public TaxDetail()
        {
            TaxableAmount = new TaxableAmount();
            TaxAmount = new TaxAmount();
            TaxLocation = new TaxLocation();
            TaxAdjustmentAmount = new TaxAdjustmentAmount();
            Description = new Description();
            TriangularTransactionLawReference = new TriangularTransactionLawReference();
            TaxExemption = new TaxExemption();
            Extrinsic = new Extrinsic();

        }
        [XmlElement(ElementName = "TaxableAmount")]
        public TaxableAmount TaxableAmount { get; set; }
        [XmlElement(ElementName = "TaxAmount")]
        public TaxAmount TaxAmount { get; set; }
        [XmlElement(ElementName = "TaxLocation")]
        public TaxLocation TaxLocation { get; set; }
        [XmlElement(ElementName = "TaxAdjustmentAmount")]
        public TaxAdjustmentAmount TaxAdjustmentAmount { get; set; }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
        [XmlElement(ElementName = "TriangularTransactionLawReference")]
        public TriangularTransactionLawReference TriangularTransactionLawReference { get; set; }
        [XmlElement(ElementName = "TaxRegime")]
        public string TaxRegime { get; set; }
        [XmlElement(ElementName = "TaxExemption")]
        public TaxExemption TaxExemption { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
        [XmlAttribute(AttributeName = "basePercentageRate")]
        public string BasePercentageRate { get; set; }
        [XmlAttribute(AttributeName = "category")]
        public string Category { get; set; }
        [XmlAttribute(AttributeName = "exemptDetail")]
        public string ExemptDetail { get; set; }
        [XmlAttribute(AttributeName = "isIncludedInPrice")]
        public string IsIncludedInPrice { get; set; }
        [XmlAttribute(AttributeName = "isTriangularTransaction")]
        public string IsTriangularTransaction { get; set; }
        [XmlAttribute(AttributeName = "isVatRecoverable")]
        public string IsVatRecoverable { get; set; }
        [XmlAttribute(AttributeName = "isWithholdingTax")]
        public string IsWithholdingTax { get; set; }
        [XmlAttribute(AttributeName = "paymentDate")]
        public string PaymentDate { get; set; }
        [XmlAttribute(AttributeName = "percentageRate")]
        public string PercentageRate { get; set; }
        [XmlAttribute(AttributeName = "purpose")]
        public string Purpose { get; set; }
        [XmlAttribute(AttributeName = "taxPointDate")]
        public string TaxPointDate { get; set; }
        [XmlAttribute(AttributeName = "taxRateType")]
        public string TaxRateType { get; set; }
        [XmlAttribute(AttributeName = "taxedElement")]
        public string TaxedElement { get; set; }
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

    [XmlRoot(ElementName = "Tax")]
    public class Tax
    {
        public Tax()
        {
            Money = new Money();
            TaxAdjustmentAmount = new TaxAdjustmentAmount();
            Description = new Description();
            TaxDetail = new TaxDetail();
            Distribution = new Distribution();
            Extrinsic = new Extrinsic();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
        [XmlElement(ElementName = "TaxAdjustmentAmount")]
        public TaxAdjustmentAmount TaxAdjustmentAmount { get; set; }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
        [XmlElement(ElementName = "TaxDetail")]
        public TaxDetail TaxDetail { get; set; }
        [XmlElement(ElementName = "Distribution")]
        public Distribution Distribution { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
    }

    [XmlRoot(ElementName = "ModificationDetail")]
    public class ModificationDetail
    {
        public ModificationDetail()
        {

            Description = new Description();
            Extrinsic = new Extrinsic();
        }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "endDate")]
        public string EndDate { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "startDate")]
        public string StartDate { get; set; }
    }

    [XmlRoot(ElementName = "Modification")]
    public class Modification
    {
        public Modification()
        {

            OriginalPrice = new OriginalPrice();
            AdditionalDeduction = new AdditionalDeduction();
            Tax = new Tax();
            ModificationDetail = new ModificationDetail();
        }
        [XmlElement(ElementName = "OriginalPrice")]
        public OriginalPrice OriginalPrice { get; set; }
        [XmlElement(ElementName = "AdditionalDeduction")]
        public AdditionalDeduction AdditionalDeduction { get; set; }
        [XmlElement(ElementName = "Tax")]
        public Tax Tax { get; set; }
        [XmlElement(ElementName = "ModificationDetail")]
        public ModificationDetail ModificationDetail { get; set; }
        [XmlAttribute(AttributeName = "level")]
        public string Level { get; set; }
    }

    [XmlRoot(ElementName = "Modifications")]
    public class Modifications
    {
        public Modifications()
        {
            Modification = new Modification();
        }
        [XmlElement(ElementName = "Modification")]
        public Modification Modification { get; set; }
    }

    [XmlRoot(ElementName = "Total")]
    public class Total
    {
        public Total()
        {
            Money = new Money();
            Modifications = new Modifications();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
        [XmlElement(ElementName = "Modifications")]
        public Modifications Modifications { get; set; }
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
            Fax = new Fax();
            URL = new URL();
        }
        [XmlElement(ElementName = "Name")]
        public Name Name { get; set; }
        [XmlElement(ElementName = "PostalAddress")]
        public PostalAddress PostalAddress { get; set; }
        [XmlElement(ElementName = "Email")]
        public Email Email { get; set; }
        [XmlElement(ElementName = "Phone")]
        public Phone Phone { get; set; }
        [XmlElement(ElementName = "Fax")]
        public Fax Fax { get; set; }
        [XmlElement(ElementName = "URL")]
        public URL URL { get; set; }
        [XmlAttribute(AttributeName = "addressID")]
        public string AddressID { get; set; }
        [XmlAttribute(AttributeName = "addressIDDomain")]
        public string AddressIDDomain { get; set; }
        [XmlAttribute(AttributeName = "isoCountryCode")]
        public string IsoCountryCode { get; set; }
    }

    [XmlRoot(ElementName = "CarrierIdentifier")]
    public class CarrierIdentifier
    {
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Route")]
    public class Route
    {
        public Route()
        {
            Contact = new Contact();
        }
        [XmlElement(ElementName = "Contact")]
        public Contact Contact { get; set; }
        [XmlAttribute(AttributeName = "endDate")]
        public string EndDate { get; set; }
        [XmlAttribute(AttributeName = "means")]
        public string Means { get; set; }
        [XmlAttribute(AttributeName = "method")]
        public string Method { get; set; }
        [XmlAttribute(AttributeName = "startDate")]
        public string StartDate { get; set; }
    }

    [XmlRoot(ElementName = "ShippingInstructions")]
    public class ShippingInstructions
    {
        public ShippingInstructions()
        {
            Description = new Description();
        }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
    }

    [XmlRoot(ElementName = "TransportInformation")]
    public class TransportInformation
    {
        public TransportInformation()
        {
            Route = new Route();
            ShippingInstructions = new ShippingInstructions();
        }
        [XmlElement(ElementName = "Route")]
        public Route Route { get; set; }
        [XmlElement(ElementName = "ShippingContractNumber")]
        public string ShippingContractNumber { get; set; }
        [XmlElement(ElementName = "ShippingInstructions")]
        public ShippingInstructions ShippingInstructions { get; set; }
    }

    [XmlRoot(ElementName = "ShipTo")]
    public class ShipTo
    {
        public ShipTo()
        {
            Address = new Address();
            CarrierIdentifier = new CarrierIdentifier();
            TransportInformation = new TransportInformation();
            IdReference = new IdReference();
        }
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
        [XmlElement(ElementName = "CarrierIdentifier")]
        public CarrierIdentifier CarrierIdentifier { get; set; }
        [XmlElement(ElementName = "TransportInformation")]
        public TransportInformation TransportInformation { get; set; }
        [XmlElement(ElementName = "IdReference")]
        public IdReference IdReference { get; set; }
    }

    [XmlRoot(ElementName = "BillTo")]
    public class BillTo
    {
        public BillTo()
        {
            Address = new Address();
            IdReference = new IdReference();
        }
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
        [XmlElement(ElementName = "IdReference")]
        public IdReference IdReference { get; set; }
    }

    [XmlRoot(ElementName = "LegalEntity")]
    public class LegalEntity
    {
        public LegalEntity()
        {
            IdReference = new IdReference();
        }
        [XmlElement(ElementName = "IdReference")]
        public IdReference IdReference { get; set; }
    }

    [XmlRoot(ElementName = "OrganizationalUnit")]
    public class OrganizationalUnit
    {
        public OrganizationalUnit()
        {
            IdReference = new IdReference();
        }
        [XmlElement(ElementName = "IdReference")]
        public IdReference IdReference { get; set; }
    }

    [XmlRoot(ElementName = "Shipping")]
    public class Shipping
    {
        public Shipping()
        {
            Money = new Money();
            Description = new Description();
            Modifications = new Modifications();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
        [XmlElement(ElementName = "Modifications")]
        public Modifications Modifications { get; set; }
        [XmlAttribute(AttributeName = "tracking")]
        public string Tracking { get; set; }
        [XmlAttribute(AttributeName = "trackingDomain")]
        public string TrackingDomain { get; set; }
        [XmlAttribute(AttributeName = "trackingId")]
        public string TrackingId { get; set; }
    }

    [XmlRoot(ElementName = "PCard")]
    public class PCard
    {
        public PCard()
        {
            PostalAddress = new PostalAddress();
        }
        [XmlElement(ElementName = "PostalAddress")]
        public PostalAddress PostalAddress { get; set; }
        [XmlAttribute(AttributeName = "expiration")]
        public string Expiration { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
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

    [XmlRoot(ElementName = "DiscountPercent")]
    public class DiscountPercent
    {
        [XmlAttribute(AttributeName = "percent")]
        public string Percent { get; set; }
    }

    [XmlRoot(ElementName = "Discount")]
    public class Discount
    {
        public Discount()
        {
            DiscountPercent = new DiscountPercent();

        }
        [XmlElement(ElementName = "DiscountPercent")]
        public DiscountPercent DiscountPercent { get; set; }
    }

    [XmlRoot(ElementName = "PaymentTerm")]
    public class PaymentTerm
    {
        public PaymentTerm()
        {
            Discount = new Discount();
            Extrinsic = new Extrinsic();

        }
        [XmlElement(ElementName = "Discount")]
        public Discount Discount { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
        [XmlAttribute(AttributeName = "payInNumberOfDays")]
        public string PayInNumberOfDays { get; set; }
    }

    [XmlRoot(ElementName = "Attachment")]
    public class Attachment
    {
        public Attachment()
        {
            URL = new URL();

        }
        [XmlElement(ElementName = "URL")]
        public URL URL { get; set; }
        [XmlAttribute(AttributeName = "visibility")]
        public string Visibility { get; set; }
    }

    [XmlRoot(ElementName = "Comments")]
    public class Comments
    {
        public Comments()
        {
            Attachment = new Attachment();

        }
        [XmlElement(ElementName = "Attachment")]
        public Attachment Attachment { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
    }

    [XmlRoot(ElementName = "Followup")]
    public class Followup
    {
        public Followup()
        {
            URL = new URL();

        }
        [XmlElement(ElementName = "URL")]
        public URL URL { get; set; }
    }

    [XmlRoot(ElementName = "Percentage")]
    public class Percentage
    {
        [XmlAttribute(AttributeName = "percent")]
        public string Percent { get; set; }
    }

    [XmlRoot(ElementName = "QuantityTolerance")]
    public class QuantityTolerance
    {
        public QuantityTolerance()
        {
            Percentage = new Percentage();

        }
        [XmlElement(ElementName = "Percentage")]
        public Percentage Percentage { get; set; }
    }

    [XmlRoot(ElementName = "PriceTolerance")]
    public class PriceTolerance
    {
        public PriceTolerance()
        {
            Percentage = new Percentage();

        }
        [XmlElement(ElementName = "Percentage")]
        public Percentage Percentage { get; set; }
    }

    [XmlRoot(ElementName = "TimeTolerance")]
    public class TimeTolerance
    {

        [XmlAttribute(AttributeName = "limit")]
        public string Limit { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "Tolerances")]
    public class Tolerances
    {
        public Tolerances()
        {
            QuantityTolerance = new QuantityTolerance();
            PriceTolerance = new PriceTolerance();
            TimeTolerance = new TimeTolerance();

        }
        [XmlElement(ElementName = "QuantityTolerance")]
        public QuantityTolerance QuantityTolerance { get; set; }
        [XmlElement(ElementName = "PriceTolerance")]
        public PriceTolerance PriceTolerance { get; set; }
        [XmlElement(ElementName = "TimeTolerance")]
        public TimeTolerance TimeTolerance { get; set; }
    }

    [XmlRoot(ElementName = "Lower")]
    public class Lower
    {
        public Lower()
        {
            Tolerances = new Tolerances();

        }
        [XmlElement(ElementName = "Tolerances")]
        public Tolerances Tolerances { get; set; }
    }

    [XmlRoot(ElementName = "Upper")]
    public class Upper
    {
        public Upper()
        {
            Tolerances = new Tolerances();

        }
        [XmlElement(ElementName = "Tolerances")]
        public Tolerances Tolerances { get; set; }
    }

    [XmlRoot(ElementName = "OCInstruction")]
    public class OCInstruction
    {
        public OCInstruction()
        {
            Lower = new Lower();
            Upper = new Upper();

        }
        [XmlElement(ElementName = "Lower")]
        public Lower Lower { get; set; }
        [XmlElement(ElementName = "Upper")]
        public Upper Upper { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "ASNInstruction")]
    public class ASNInstruction
    {
        public ASNInstruction()
        {
            Lower = new Lower();
            Upper = new Upper();

        }
        [XmlElement(ElementName = "Lower")]
        public Lower Lower { get; set; }
        [XmlElement(ElementName = "Upper")]
        public Upper Upper { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "TemporaryPrice")]
    public class TemporaryPrice
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "InvoiceInstruction")]
    public class InvoiceInstruction
    {
        public InvoiceInstruction()
        {
            TemporaryPrice = new TemporaryPrice();
            Lower = new Lower();
            Upper = new Upper();

        }
        [XmlElement(ElementName = "TemporaryPrice")]
        public TemporaryPrice TemporaryPrice { get; set; }
        [XmlElement(ElementName = "Lower")]
        public Lower Lower { get; set; }
        [XmlElement(ElementName = "Upper")]
        public Upper Upper { get; set; }
        [XmlAttribute(AttributeName = "unitPriceEditable")]
        public string UnitPriceEditable { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "verificationType")]
        public string VerificationType { get; set; }
    }

    [XmlRoot(ElementName = "SESInstruction")]
    public class SESInstruction
    {
        public SESInstruction()
        {
            Lower = new Lower();
            Upper = new Upper();

        }
        [XmlElement(ElementName = "Lower")]
        public Lower Lower { get; set; }
        [XmlElement(ElementName = "Upper")]
        public Upper Upper { get; set; }
        [XmlAttribute(AttributeName = "unitPriceEditable")]
        public string UnitPriceEditable { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "ControlKeys")]
    public class ControlKeys
    {
        public ControlKeys()
        {
            OCInstruction = new OCInstruction();
            ASNInstruction = new ASNInstruction();
            InvoiceInstruction = new InvoiceInstruction();
            SESInstruction = new SESInstruction();

        }
        [XmlElement(ElementName = "OCInstruction")]
        public OCInstruction OCInstruction { get; set; }
        [XmlElement(ElementName = "ASNInstruction")]
        public ASNInstruction ASNInstruction { get; set; }
        [XmlElement(ElementName = "InvoiceInstruction")]
        public InvoiceInstruction InvoiceInstruction { get; set; }
        [XmlElement(ElementName = "SESInstruction")]
        public SESInstruction SESInstruction { get; set; }
    }

    [XmlRoot(ElementName = "DocumentReference")]
    public class DocumentReference
    {
        [XmlAttribute(AttributeName = "payloadID")]
        public string PayloadID { get; set; }
    }

    [XmlRoot(ElementName = "SupplierOrderInfo")]
    public class SupplierOrderInfo
    {
        [XmlAttribute(AttributeName = "orderDate")]
        public string OrderDate { get; set; }
        [XmlAttribute(AttributeName = "orderID")]
        public string OrderID { get; set; }
    }

    [XmlRoot(ElementName = "TermsOfDeliveryCode")]
    public class TermsOfDeliveryCode
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ShippingPaymentMethod")]
    public class ShippingPaymentMethod
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TransportTerms")]
    public class TransportTerms
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TermsOfDelivery")]
    public class TermsOfDelivery
    {
        public TermsOfDelivery()
        {
            TermsOfDeliveryCode = new TermsOfDeliveryCode();
            ShippingPaymentMethod = new ShippingPaymentMethod();
            TransportTerms = new TransportTerms();
            Comments = new Comments();

        }
        [XmlElement(ElementName = "TermsOfDeliveryCode")]
        public TermsOfDeliveryCode TermsOfDeliveryCode { get; set; }
        [XmlElement(ElementName = "ShippingPaymentMethod")]
        public ShippingPaymentMethod ShippingPaymentMethod { get; set; }
        [XmlElement(ElementName = "TransportTerms")]
        public TransportTerms TransportTerms { get; set; }
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
        [XmlElement(ElementName = "Comments")]
        public Comments Comments { get; set; }
    }

    [XmlRoot(ElementName = "Period")]
    public class Period
    {
        [XmlAttribute(AttributeName = "endDate")]
        public string EndDate { get; set; }
        [XmlAttribute(AttributeName = "startDate")]
        public string StartDate { get; set; }
    }

    [XmlRoot(ElementName = "DeliveryPeriod")]
    public class DeliveryPeriod
    {
        public DeliveryPeriod()
        {
            Period = new Period();

        }
        [XmlElement(ElementName = "Period")]
        public Period Period { get; set; }
    }

    [XmlRoot(ElementName = "DocumentInfo")]
    public class DocumentInfo
    {
        [XmlAttribute(AttributeName = "documentDate")]
        public string DocumentDate { get; set; }
        [XmlAttribute(AttributeName = "documentID")]
        public string DocumentID { get; set; }
        [XmlAttribute(AttributeName = "documentType")]
        public string DocumentType { get; set; }
    }

    [XmlRoot(ElementName = "DateInfo")]
    public class DateInfo
    {
        public DateInfo()
        {
            Extrinsic = new Extrinsic();

        }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "ReferenceDocumentInfo")]
    public class ReferenceDocumentInfo
    {
        public ReferenceDocumentInfo()
        {
            DocumentInfo = new DocumentInfo();
            DocumentInfo = new DocumentInfo();
            Contact = new Contact();
            Extrinsic = new Extrinsic();
        }
        [XmlElement(ElementName = "DocumentInfo")]
        public DocumentInfo DocumentInfo { get; set; }
        [XmlElement(ElementName = "DateInfo")]
        public DateInfo DateInfo { get; set; }
        [XmlElement(ElementName = "Contact")]
        public Contact Contact { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
        [XmlAttribute(AttributeName = "lineNumber")]
        public string LineNumber { get; set; }
        [XmlAttribute(AttributeName = "scheduleLineNumber")]
        public string ScheduleLineNumber { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }
    }

    [XmlRoot(ElementName = "Priority")]
    public class Priority
    {
        public Priority()
        {
            Description = new Description();
        }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
        [XmlAttribute(AttributeName = "inventory_level")]
        public string Inventory_level { get; set; }
        [XmlAttribute(AttributeName = "level")]
        public string Level { get; set; }
        [XmlAttribute(AttributeName = "sequence")]
        public string Sequence { get; set; }
    }

    [XmlRoot(ElementName = "ExternalDocumentType")]
    public class ExternalDocumentType
    {
        public ExternalDocumentType()
        {
            Description = new Description();
        }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
        [XmlAttribute(AttributeName = "documentType")]
        public string DocumentType { get; set; }
    }

    [XmlRoot(ElementName = "QualityInfo")]
    public class QualityInfo
    {
        public QualityInfo()
        {
            IdReference = new IdReference();
        }
        [XmlElement(ElementName = "IdReference")]
        public IdReference IdReference { get; set; }
        [XmlAttribute(AttributeName = "requiresQualityProcess")]
        public string RequiresQualityProcess { get; set; }
    }

    [XmlRoot(ElementName = "AssetInfo")]
    public class AssetInfo
    {
        public AssetInfo()
        {
            Extrinsic = new Extrinsic();
        }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
        [XmlAttribute(AttributeName = "equipmentId")]
        public string EquipmentId { get; set; }
        [XmlAttribute(AttributeName = "isReferencedAsset")]
        public string IsReferencedAsset { get; set; }
        [XmlAttribute(AttributeName = "location")]
        public string Location { get; set; }
        [XmlAttribute(AttributeName = "serialNumber")]
        public string SerialNumber { get; set; }
        [XmlAttribute(AttributeName = "tagNumber")]
        public string TagNumber { get; set; }
    }

    [XmlRoot(ElementName = "OrderRequestHeaderIndustry")]
    public class OrderRequestHeaderIndustry
    {
        public OrderRequestHeaderIndustry()
        {
            ReferenceDocumentInfo = new ReferenceDocumentInfo();
            Priority = new Priority();
            ExternalDocumentType = new ExternalDocumentType();
            QualityInfo = new QualityInfo();
            AssetInfo = new AssetInfo();
        }
        [XmlElement(ElementName = "ReferenceDocumentInfo")]
        public ReferenceDocumentInfo ReferenceDocumentInfo { get; set; }
        [XmlElement(ElementName = "Priority")]
        public Priority Priority { get; set; }
        [XmlElement(ElementName = "ExternalDocumentType")]
        public ExternalDocumentType ExternalDocumentType { get; set; }
        [XmlElement(ElementName = "QualityInfo")]
        public QualityInfo QualityInfo { get; set; }
        [XmlElement(ElementName = "AssetInfo")]
        public AssetInfo AssetInfo { get; set; }
    }

    [XmlRoot(ElementName = "OrderRequestHeader")]
    public class OrderRequestHeader
    {
        public OrderRequestHeader()
        {
            Total = new Total();
            IdReference = new IdReference();
            ShipTo = new ShipTo();
            BillTo = new BillTo();
            LegalEntity = new LegalEntity();
            IdReference = new IdReference();
            OrganizationalUnit = new OrganizationalUnit();
            IdReference = new IdReference();
            Shipping = new Shipping();
            IdReference = new IdReference();
            Tax = new Tax();
            IdReference = new IdReference();
            Payment = new Payment();
            PaymentTerm = new PaymentTerm();

            Contact = new Contact();
            Comments = new Comments();
            Followup = new Followup();
            ControlKeys = new ControlKeys();
            DocumentReference = new DocumentReference();
            SupplierOrderInfo = new SupplierOrderInfo();
            SupplierOrderInfo = new SupplierOrderInfo();
            TermsOfDelivery = new TermsOfDelivery();
            DeliveryPeriod = new DeliveryPeriod();
            IdReference = new IdReference();
            OrderRequestHeaderIndustry = new OrderRequestHeaderIndustry();
            Extrinsic = new Extrinsic();
        }
        [XmlElement(ElementName = "Total")]
        public Total Total { get; set; }
        [XmlElement(ElementName = "ShipTo")]
        public ShipTo ShipTo { get; set; }
        [XmlElement(ElementName = "BillTo")]
        public BillTo BillTo { get; set; }
        [XmlElement(ElementName = "LegalEntity")]
        public LegalEntity LegalEntity { get; set; }
        [XmlElement(ElementName = "OrganizationalUnit")]
        public OrganizationalUnit OrganizationalUnit { get; set; }
        [XmlElement(ElementName = "Shipping")]
        public Shipping Shipping { get; set; }
        [XmlElement(ElementName = "Tax")]
        public Tax Tax { get; set; }
        [XmlElement(ElementName = "Payment")]
        public Payment Payment { get; set; }
        [XmlElement(ElementName = "PaymentTerm")]
        public PaymentTerm PaymentTerm { get; set; }
        [XmlElement(ElementName = "Contact")]
        public Contact Contact { get; set; }
        [XmlElement(ElementName = "Comments")]
        public Comments Comments { get; set; }
        [XmlElement(ElementName = "Followup")]
        public Followup Followup { get; set; }
        [XmlElement(ElementName = "ControlKeys")]
        public ControlKeys ControlKeys { get; set; }
        [XmlElement(ElementName = "DocumentReference")]
        public DocumentReference DocumentReference { get; set; }
        [XmlElement(ElementName = "SupplierOrderInfo")]
        public SupplierOrderInfo SupplierOrderInfo { get; set; }
        [XmlElement(ElementName = "TermsOfDelivery")]
        public TermsOfDelivery TermsOfDelivery { get; set; }
        [XmlElement(ElementName = "DeliveryPeriod")]
        public DeliveryPeriod DeliveryPeriod { get; set; }
        [XmlElement(ElementName = "IdReference")]
        public IdReference IdReference { get; set; }
        [XmlElement(ElementName = "OrderRequestHeaderIndustry")]
        public OrderRequestHeaderIndustry OrderRequestHeaderIndustry { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
        [XmlAttribute(AttributeName = "agreementID")]
        public string AgreementID { get; set; }
        [XmlAttribute(AttributeName = "agreementPayloadID")]
        public string AgreementPayloadID { get; set; }
        [XmlAttribute(AttributeName = "effectiveDate")]
        public string EffectiveDate { get; set; }
        [XmlAttribute(AttributeName = "expirationDate")]
        public string ExpirationDate { get; set; }
        [XmlAttribute(AttributeName = "isInternalVersion")]
        public string IsInternalVersion { get; set; }
        [XmlAttribute(AttributeName = "orderDate")]
        public string OrderDate { get; set; }
        [XmlAttribute(AttributeName = "orderID")]
        public string OrderID { get; set; }
        [XmlAttribute(AttributeName = "orderType")]
        public string OrderType { get; set; }
        [XmlAttribute(AttributeName = "orderVersion")]
        public string OrderVersion { get; set; }
        [XmlAttribute(AttributeName = "parentAgreementID")]
        public string ParentAgreementID { get; set; }
        [XmlAttribute(AttributeName = "parentAgreementPayloadID")]
        public string ParentAgreementPayloadID { get; set; }
        [XmlAttribute(AttributeName = "pickUpDate")]
        public string PickUpDate { get; set; }
        [XmlAttribute(AttributeName = "releaseRequired")]
        public string ReleaseRequired { get; set; }
        [XmlAttribute(AttributeName = "requestedDeliveryDate")]
        public string RequestedDeliveryDate { get; set; }
        [XmlAttribute(AttributeName = "requisitionID")]
        public string RequisitionID { get; set; }
        [XmlAttribute(AttributeName = "shipComplete")]
        public string ShipComplete { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "SupplierPartID")]
    public class SupplierPartID
    {
        [XmlAttribute(AttributeName = "revisionID")]
        public string RevisionID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ItemID")]
    public class ItemID
    {
        public ItemID()
        {
            //SupplierPartID = new SupplierPartID();
            IdReference = new IdReference();
        }
        [XmlElement(ElementName = "SupplierPartID")]
        public string SupplierPartID { get; set; }
        [XmlElement(ElementName = "SupplierPartAuxiliaryID")]
        public string SupplierPartAuxiliaryID { get; set; }
        [XmlElement(ElementName = "BuyerPartID")]
        public string BuyerPartID { get; set; }
        [XmlElement(ElementName = "IdReference")]
        public IdReference IdReference { get; set; }
    }

    [XmlRoot(ElementName = "CostTermValue")]
    public class CostTermValue
    {
        public CostTermValue()
        {
            Money = new Money();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
    }

    [XmlRoot(ElementName = "Scale")]
    public class Scale
    {
        public Scale()
        {
            CostTermValue = new CostTermValue();
        }

        [XmlElement(ElementName = "CostTermValue")]
        public CostTermValue CostTermValue { get; set; }
        [XmlAttribute(AttributeName = "from")]
        public string From { get; set; }
        [XmlAttribute(AttributeName = "to")]
        public string To { get; set; }
    }

    [XmlRoot(ElementName = "Scales")]
    public class Scales
    {
        public Scales()
        {
            Scale = new Scale();
        }
        [XmlElement(ElementName = "Scale")]
        public Scale Scale { get; set; }
        [XmlAttribute(AttributeName = "scaleBasis")]
        public string ScaleBasis { get; set; }
        [XmlAttribute(AttributeName = "scaleType")]
        public string ScaleType { get; set; }
    }

    [XmlRoot(ElementName = "ConditionType")]
    public class ConditionType
    {
        public ConditionType()
        {
            CostTermValue = new CostTermValue();
            Scales = new Scales();

        }
        [XmlElement(ElementName = "CostTermValue")]
        public CostTermValue CostTermValue { get; set; }
        [XmlElement(ElementName = "Scales")]
        public Scales Scales { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "ConditionTypes")]
    public class ConditionTypes
    {
        public ConditionTypes()
        {
            ConditionType = new ConditionType();

        }
        [XmlElement(ElementName = "ConditionType")]
        public ConditionType ConditionType { get; set; }
    }

    [XmlRoot(ElementName = "ValidityPeriod")]
    public class ValidityPeriod
    {
        public ValidityPeriod()
        {
            ConditionTypes = new ConditionTypes();

        }
        [XmlElement(ElementName = "ConditionTypes")]
        public ConditionTypes ConditionTypes { get; set; }
        [XmlAttribute(AttributeName = "from")]
        public string From { get; set; }
        [XmlAttribute(AttributeName = "to")]
        public string To { get; set; }
    }

    [XmlRoot(ElementName = "ValidityPeriods")]
    public class ValidityPeriods
    {
        public ValidityPeriods()
        {
            ValidityPeriod = new ValidityPeriod();

        }
        [XmlElement(ElementName = "ValidityPeriod")]
        public ValidityPeriod ValidityPeriod { get; set; }
    }

    [XmlRoot(ElementName = "PricingConditions")]
    public class PricingConditions
    {
        [XmlElement(ElementName = "ValidityPeriods")]
        public ValidityPeriods ValidityPeriods { get; set; }
    }

    [XmlRoot(ElementName = "UnitPrice")]
    public class UnitPrice
    {
        public UnitPrice()
        {
            Money = new Money();
            Modifications = new Modifications();
            PricingConditions = new PricingConditions();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
        [XmlElement(ElementName = "Modifications")]
        public Modifications Modifications { get; set; }
        [XmlElement(ElementName = "PricingConditions")]
        public PricingConditions PricingConditions { get; set; }
    }

    [XmlRoot(ElementName = "OverallLimit")]
    public class OverallLimit
    {
        public OverallLimit()
        {
            Money = new Money();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
    }

    [XmlRoot(ElementName = "ExpectedLimit")]
    public class ExpectedLimit
    {
        public ExpectedLimit()
        {
            Money = new Money();
        }
        [XmlElement(ElementName = "Money")]
        public Money Money { get; set; }
    }

    [XmlRoot(ElementName = "PriceBasisQuantity")]
    public class PriceBasisQuantity
    {
        public PriceBasisQuantity()
        {
            Description = new Description();
        }
        [XmlElement(ElementName = "UnitOfMeasure")]
        public string UnitOfMeasure { get; set; }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
        [XmlAttribute(AttributeName = "conversionFactor")]
        public string ConversionFactor { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
    }

    [XmlRoot(ElementName = "Classification")]
    public class Classification
    {
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ManufacturerName")]
    public class ManufacturerName
    {
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Dimension")]
    public class Dimension
    {
        [XmlElement(ElementName = "UnitOfMeasure")]
        public string UnitOfMeasure { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "Characteristic")]
    public class Characteristic
    {
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "ItemDetailRetail")]
    public class ItemDetailRetail
    {
        public ItemDetailRetail()
        {
            Characteristic = new Characteristic();
        }
        [XmlElement(ElementName = "EANID")]
        public string EANID { get; set; }
        [XmlElement(ElementName = "EuropeanWasteCatalogID")]
        public string EuropeanWasteCatalogID { get; set; }
        [XmlElement(ElementName = "Characteristic")]
        public Characteristic Characteristic { get; set; }
    }

    [XmlRoot(ElementName = "ItemDetailIndustry")]
    public class ItemDetailIndustry
    {
        public ItemDetailIndustry()
        {
            ItemDetailRetail = new ItemDetailRetail();
        }
        [XmlElement(ElementName = "ItemDetailRetail")]
        public ItemDetailRetail ItemDetailRetail { get; set; }
        [XmlAttribute(AttributeName = "isConfigurableMaterial")]
        public string IsConfigurableMaterial { get; set; }
    }

    [XmlRoot(ElementName = "InternalID")]
    public class InternalID
    {
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "AttachmentReference")]
    public class AttachmentReference
    {
        public AttachmentReference()
        {
            Name = new Name();
            Description = new Description();
            InternalID = new InternalID();
            URL = new URL();
        }

        [XmlElement(ElementName = "Name")]
        public Name Name { get; set; }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
        [XmlElement(ElementName = "InternalID")]
        public InternalID InternalID { get; set; }
        [XmlElement(ElementName = "URL")]
        public URL URL { get; set; }
        [XmlAttribute(AttributeName = "length")]
        public string Length { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }

    [XmlRoot(ElementName = "ItemDetail")]
    public class ItemDetail
    {
        public ItemDetail()
        {
            UnitPrice = new UnitPrice();
            Description = new Description();
            OverallLimit = new OverallLimit();
            ExpectedLimit = new ExpectedLimit();
            PriceBasisQuantity = new PriceBasisQuantity();
            Classification = new Classification();
            URL = new URL();
            Dimension = new Dimension();
            ItemDetailIndustry = new ItemDetailIndustry();
            AttachmentReference = new AttachmentReference();
            Extrinsic = new Extrinsic();
        }

        [XmlElement(ElementName = "UnitPrice")]
        public UnitPrice UnitPrice { get; set; }
        [XmlElement(ElementName = "Description")]
        public Description Description { get; set; }
        [XmlElement(ElementName = "OverallLimit")]
        public OverallLimit OverallLimit { get; set; }
        [XmlElement(ElementName = "ExpectedLimit")]
        public ExpectedLimit ExpectedLimit { get; set; }
        [XmlElement(ElementName = "UnitOfMeasure")]
        public string UnitOfMeasure { get; set; }
        [XmlElement(ElementName = "PriceBasisQuantity")]
        public PriceBasisQuantity PriceBasisQuantity { get; set; }
        [XmlElement(ElementName = "Classification")]
        public Classification Classification { get; set; }
        [XmlElement(ElementName = "ManufacturerPartID")]
        public string ManufacturerPartID { get; set; }
        [XmlElement(ElementName = "ManufacturerName")]
        public ManufacturerName ManufacturerName { get; set; }
        [XmlElement(ElementName = "URL")]
        public URL URL { get; set; }
        [XmlElement(ElementName = "LeadTime")]
        public string LeadTime { get; set; }
        [XmlElement(ElementName = "Dimension")]
        public Dimension Dimension { get; set; }
        [XmlElement(ElementName = "ItemDetailIndustry")]
        public ItemDetailIndustry ItemDetailIndustry { get; set; }
        [XmlElement(ElementName = "AttachmentReference")]
        public AttachmentReference AttachmentReference { get; set; }
        [XmlElement(ElementName = "PlannedAcceptanceDays")]
        public string PlannedAcceptanceDays { get; set; }
        [XmlElement(ElementName = "Extrinsic")]
        public Extrinsic Extrinsic { get; set; }
    }

    [XmlRoot(ElementName = "SupplierID")]
    public class SupplierID
    {
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ItemOut")]
    public class ItemOut
    {
        public ItemOut()
        {
            ItemID = new ItemID();
            ItemDetail = new ItemDetail();
            SupplierID = new SupplierID();
            ShipTo = new ShipTo();
            Tax = new Tax();
            Distribution = new Distribution();
            ItemDetail = new ItemDetail();
        }

        [XmlElement(ElementName = "ItemID")]
        public ItemID ItemID { get; set; }
        [XmlElement(ElementName = "ItemDetail")]
        public ItemDetail ItemDetail { get; set; }
        [XmlElement(ElementName = "SupplierID")]
        public SupplierID SupplierID { get; set; }
        [XmlElement(ElementName = "ShipTo")]
        public ShipTo ShipTo { get; set; }
        [XmlElement(ElementName = "Shipping")]
        public Shipping Shipping { get; set; }
        [XmlElement(ElementName = "Tax")]
        public Tax Tax { get; set; }
        [XmlElement(ElementName = "Distribution")]
        public Distribution Distribution { get; set; }
        [XmlAttribute(AttributeName = "agreementItemNumber")]
        public string AgreementItemNumber { get; set; }
        [XmlAttribute(AttributeName = "compositeItemType")]
        public string CompositeItemType { get; set; }
        [XmlAttribute(AttributeName = "confirmationDueDate")]
        public string ConfirmationDueDate { get; set; }
        [XmlAttribute(AttributeName = "isAdHoc")]
        public string IsAdHoc { get; set; }
        [XmlAttribute(AttributeName = "isDeliveryCompleted")]
        public string IsDeliveryCompleted { get; set; }
        [XmlAttribute(AttributeName = "isItemChanged")]
        public string IsItemChanged { get; set; }
        [XmlAttribute(AttributeName = "isKanban")]
        public string IsKanban { get; set; }
        [XmlAttribute(AttributeName = "isReturn")]
        public string IsReturn { get; set; }
        [XmlAttribute(AttributeName = "itemCategory")]
        public string ItemCategory { get; set; }
        [XmlAttribute(AttributeName = "itemClassification")]
        public string ItemClassification { get; set; }
        [XmlAttribute(AttributeName = "itemType")]
        public string ItemType { get; set; }
        [XmlAttribute(AttributeName = "lineNumber")]
        public string LineNumber { get; set; }
        [XmlAttribute(AttributeName = "parentLineNumber")]
        public string ParentLineNumber { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
        [XmlAttribute(AttributeName = "requestedDeliveryDate")]
        public string RequestedDeliveryDate { get; set; }
        [XmlAttribute(AttributeName = "requestedShipmentDate")]
        public string RequestedShipmentDate { get; set; }
        [XmlAttribute(AttributeName = "requiresServiceEntry")]
        public string RequiresServiceEntry { get; set; }
        [XmlAttribute(AttributeName = "requisitionID")]
        public string RequisitionID { get; set; }
        [XmlAttribute(AttributeName = "returnAuthorizationNumber")]
        public string ReturnAuthorizationNumber { get; set; }
        [XmlAttribute(AttributeName = "stockTransferType")]
        public string StockTransferType { get; set; }
        [XmlAttribute(AttributeName = "subcontractingType")]
        public string SubcontractingType { get; set; }
        [XmlAttribute(AttributeName = "unlimitedDelivery")]
        public string UnlimitedDelivery { get; set; }
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
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "deploymentMode")]
        public string DeploymentMode { get; set; }
    }

    [XmlRoot(ElementName = "cXML")]
    public class CXML
    {
        [XmlElement(ElementName = "Header")]
        public Header Header { get; set; }
        [XmlElement(ElementName = "Request")]
        public Request Request { get; set; }
        [XmlAttribute(AttributeName = "payloadID")]
        public string PayloadID { get; set; }
        [XmlAttribute(AttributeName = "signatureVersion")]
        public string SignatureVersion { get; set; }
        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }

        public CXML()
        {
            Header = new Header();
            Request = new Request();
        }

    }


}
