using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateRevit2025.Model.Test
{
    public class TestDynamic : DynamicObject
    {
        private Dictionary<string, object> _properties;
        public TestDynamic(Dictionary<string, object> properties)
        {
            _properties = properties;

        }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _properties.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                result = _properties[binder.Name];
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                _properties[binder.Name] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class ExcelImport
    {
        private Dictionary<string , object> dictProperties= new Dictionary<string , object>();

        public Dictionary<string,int> dictParaIndexCol= new Dictionary<string, int>(); 
        public void Add(int indexCol, string namePara)
        {
            dictParaIndexCol.Add(namePara,indexCol);
            dictProperties.Add(namePara, new object());
        }
        
        public void ImportExcel()
        {
            // workind
            List<TestDynamic> listDataFromExcel= new List<TestDynamic>();
            for(int row= 1; row< 10;row++)
            {

                dynamic testDynamic = new TestDynamic(dictProperties);
                foreach(var propertyName in testDynamic.GetDynamicMemberNames())
                {
                    int indeCol = dictParaIndexCol[propertyName];

                    string valueFromExcel = string.Empty; // gia tri tu excel trong 

                    testDynamic.propertyName = valueFromExcel;
                }
                
                listDataFromExcel.Add(testDynamic);
               
            }
        }
        

    }
}
