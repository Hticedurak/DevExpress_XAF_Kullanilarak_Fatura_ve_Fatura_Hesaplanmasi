﻿using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace Customer.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Product : BaseObject
    {
        public Product(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        private string _Code;
   
        public string Code
        {
            get { return _Code; }
            set
            {
                if (SetPropertyValue<string>("Code", ref _Code, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                if (SetPropertyValue<string>("Name", ref _Name, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private int _KDVRate;
    
        public int KDVRate
        {
            get { return _KDVRate; }
            set
            {
                if (SetPropertyValue<int>("KDVRate", ref _KDVRate, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private decimal _PurchasePrice;
       
        public decimal PurchasePrice
        {
            get { return _PurchasePrice; }
            set
            {
                if (SetPropertyValue<decimal>("PurchasePrice", ref _PurchasePrice, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private decimal _SalePrice;
        
        public decimal SalePrice
        {
            get { return _SalePrice; }
            set
            {
                if (SetPropertyValue<decimal>("SalePrice", ref _SalePrice, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

    }
}