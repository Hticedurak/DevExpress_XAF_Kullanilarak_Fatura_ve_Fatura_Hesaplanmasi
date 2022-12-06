using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace Customer.Module.BusinessObjects
{
    [DefaultClassOptions]

    public class InvoiceTransaction : BaseObject
    {
        public InvoiceTransaction(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        private Product _Product;

        public Product Product
        {
            get { return _Product; }
            set
            {
                if (SetPropertyValue<Product>("Product", ref _Product, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        this.Price = Product.SalePrice;
                        this.KDVRate = Product.KDVRate;
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

        private int _Quantity;
        [ImmediatePostData]
        public int Quantity
        {
            get { return _Quantity; }
            set
            {
                if (SetPropertyValue<int>("Quantity", ref _Quantity, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        NetAmount = Quantity * Price;
                    }
                }
            }
        }

        private decimal _Price;
        [ImmediatePostData]
        public decimal Price
        {
            get { return _Price; }
            set
            {
                if (SetPropertyValue<decimal>("Price", ref _Price, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        NetAmount = Quantity * Price;
                    }
                }
            }
        }

        private double _KDVRate;
        [ImmediatePostData]
        public double KDVRate
        {
            get { return _KDVRate; }
            set
            {
                if (SetPropertyValue<double>("KDVRate", ref _KDVRate, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        KDVAmount = ((decimal)KDVRate * NetAmount) / 100;
                    }
                }
            }
        }

        private decimal _NetAmount;
     
        [ImmediatePostData]
        public decimal NetAmount
        {
            get { return _NetAmount; }
            set
            {
                if (SetPropertyValue<decimal>("NetAmount", ref _NetAmount, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        KDVAmount = ((decimal)KDVRate * NetAmount) / 100;
                        TotalAmount = NetAmount + KDVAmount;

                    }
                }
            }
        }

        private decimal _KDVAmount;
      
        [ImmediatePostData]
        public decimal KDVAmount
        {
            get { return _KDVAmount; }
            set
            {
                if (SetPropertyValue<decimal>("KDVAmount", ref _KDVAmount, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        TotalAmount = NetAmount + KDVAmount;

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
;
                    }
                }
            }
        }

        private Bill _Bill;
        [VisibleInListView(false)]
        [Association("Bill-InvoiceTransactions")]

        public Bill Bill
        {
            get { return _Bill; }
            set
            {
                if (SetPropertyValue<Bill>("Bill", ref _Bill, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }
    }
}