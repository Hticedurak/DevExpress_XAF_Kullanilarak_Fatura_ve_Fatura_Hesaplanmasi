using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;


namespace Customer.Module.BusinessObjects
{
    [DefaultClassOptions]

    public class District : BaseObject
    {
        public District(Session session)
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

        private City _City;
        [Association("City-Districts")]
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

    }
}