using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace Customer.Module.BusinessObjects
{
    [DefaultClassOptions]

    public class Customer : BaseObject
    {
        public Customer(Session session) : base(session){ }
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

        private DateTime _DealDate;

        public DateTime DealDate
        {
            get { return _DealDate; }
            set
            {
                if (SetPropertyValue<DateTime>("DealDate", ref _DealDate, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

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
    }
}