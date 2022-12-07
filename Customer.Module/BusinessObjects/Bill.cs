using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using static Customer.Module.BusinessObjects.Number;

namespace Customer.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Bill : BaseObject
    {
        public Bill(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Date = DateTime.Now;
            int iLast = 0;
            int iLen = 0;
            XPCollection<Number> collection = new XPCollection<Number>(Session);
            collection.Criteria = CriteriaOperator.Parse("Type=?", TypeEnum.Bill);

            foreach (var item in collection)
            {
                iLast =   item.LastNumber;
                iLen = item.Length;
            }
              
            string sNumber = "";
            for (int i = 0; i < iLen- (iLen.ToString().Length); i++)
            {
                sNumber += "0";
            }
            sNumber += "" + iLast.ToString();
            Number = sNumber;

            foreach (var item in collection)
            {
                item.LastNumber = iLast + 1;
                item.Save();
            }
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
        [VisibleInDetailView(false)]

        public decimal CalculatorNetAmount
        {
            get
            {
                return Convert.ToDecimal(EvaluateAlias("CalculatorNetAmount"));
            }

        }

        [PersistentAlias("InvoiceTransactions.Sum(KDVAmount)")]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]

        public decimal CalculatorKDVAmount
        {
            get
            {
                return Convert.ToDecimal(EvaluateAlias("CalculatorKDVAmount"));
            }

        }

        [PersistentAlias("InvoiceTransactions.Sum(TotalAmount)")]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]

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
        }
    }
}
