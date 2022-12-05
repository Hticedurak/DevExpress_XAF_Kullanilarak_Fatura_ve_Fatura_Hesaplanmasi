using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace Customer.Module.BusinessObjects
{
    [DefaultClassOptions]
      public class Number : BaseObject
    {
        public Number(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private TypeEnum _Type;
        public TypeEnum Type
        {
            get { return _Type; }
            set { SetPropertyValue(nameof(Type), ref _Type, value); }
        }
      
        public enum TypeEnum { Bill, Customer, Product }
     


        private int _Beginning;
       
        public int Beginning
        {
            get { return _Beginning; }
            set
            {
                if (SetPropertyValue<int>("Beginning", ref _Beginning, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private int _Finish;
        
        public int Finish
        {
            get { return _Finish; }
            set
            {
                if (SetPropertyValue<int>("Finish", ref _Finish, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private int _LastNumber;
      
        public int LastNumber
        {
            get { return _LastNumber; }
            set
            {
                if (SetPropertyValue<int>("LastNumber", ref _LastNumber, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private int _Length;
        
        public int Length
        {
            get { return _Length; }
            set
            {
                if (SetPropertyValue<int>("Length", ref _Length, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }



    }
}