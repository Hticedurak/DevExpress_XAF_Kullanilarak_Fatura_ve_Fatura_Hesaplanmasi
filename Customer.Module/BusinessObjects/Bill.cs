using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace Customer.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Bill : BaseObject
    {
        public Bill(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            XPCollection<Bill> collection = new XPCollection<Bill>(Session);
            Number = $"{collection.Count + 1}";
        }

        private DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set
            {
                if (SetPropertyValue<DateTime>("Date", ref _Date, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private string _CustomerNo;

        public string Number
        {
            get { return _CustomerNo; }
            set
            {
                if (SetPropertyValue<string>("CustomerNo", ref _CustomerNo, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private Customer _Customer;

        public Customer Customer
        {
            get { return _Customer; }
            set
            {
                if (SetPropertyValue<Customer>("Customer", ref _Customer, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        this.City = Customer.City;
                        this.District = Customer.District;
                    }
                }
            }
        }

        private City _City;

        public City City
        {
            get { return _City; }
            set
            {
                if (SetPropertyValue<City>("City", ref _City, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private District _District;
        [DataSourceProperty("City.Districts")]
        public District District
        {
            get { return _District; }
            set
            {
                if (SetPropertyValue<District>("District", ref _District, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set
            {
                if (SetPropertyValue<string>("Description", ref _Description, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private decimal _NetAmount;
       
        public decimal NetAmount
        {
            get { return _NetAmount; }
            set
            {
                if (SetPropertyValue<decimal>("NetAmount", ref _NetAmount, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private decimal _KDVAmount;
      
        public decimal KDVAmount
        {
            get { return _KDVAmount; }
            set
            {
                if (SetPropertyValue<decimal>("KDVAmount", ref _KDVAmount, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private decimal _TotalAmount;
 
        public decimal TotalAmount
        {
            get { return _TotalAmount; }
            set
            {
                if (SetPropertyValue<decimal>("TotalAmount", ref _TotalAmount, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        [PersistentAlias("InvoiceTransactions.Sum(NetAmount)")]
        [VisibleInListView(false)]
      
        public decimal CalculatorNetAmount
        {
            get
            {
                return Convert.ToDecimal(EvaluateAlias("CalculatorNetAmount"));
            }

        }

        [PersistentAlias("InvoiceTransactions.Sum(KDVAmount)")]
        [VisibleInListView(false)]
      
        public decimal CalculatorKDVAmount
        {
            get
            {
                return Convert.ToDecimal(EvaluateAlias("CalculatorKDVAmount"));
            }

        }

        [PersistentAlias("InvoiceTransactions.Sum(TotalAmount)")]
        [VisibleInListView(false)]
   
        public decimal CalculatorTotalAmount
        {
            get
            {
                return Convert.ToDecimal(EvaluateAlias("CalculatorTotalAmount"));
            }

        }

        [Association("Bill-InvoiceTransactions"), Aggregated]
        public XPCollection<InvoiceTransaction> InvoiceTransactions
        {
            get { return GetCollection<InvoiceTransaction>(nameof(InvoiceTransactions)); }
        }

        protected override void OnSaving()
        {
            this.NetAmount = CalculatorNetAmount;
            this.TotalAmount = CalculatorTotalAmount;
            this.KDVAmount = CalculatorKDVAmount;
            base.OnSaving();

            /* if (!(Session is NestedUnitOfWork) // Nesnenin üst oturuma değil de veritabanına kaydedilip kaydedilmediğini kontrol eder.
                 && (Session.DataLayer != null)
                     && Session.IsNewObject(this) // Nesnenin yeni olup olmadığını kontrol eder.
                         && (Session.ObjectLayer is SimpleObjectLayer)
                            && string.IsNullOrEmpty(Number) // Çift atamalardan kaçınır.)
             {
                 int nextSequence = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "MyServerPrefix");
                 Number = string.Format("N{0:D6}", nextSequence);
             }
             base.OnSaving();*/

        }
    }
}
