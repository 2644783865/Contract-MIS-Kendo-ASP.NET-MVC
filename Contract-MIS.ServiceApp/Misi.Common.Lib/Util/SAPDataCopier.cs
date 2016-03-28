using System;
using System.Linq;
using SAP.Middleware.Connector;

namespace Misi.Common.Lib.Util
{
    public class SAPDataCopier
    {
        private static volatile SAPDataCopier _copier;
        private static readonly object _copierRoot = new object();

        public static SAPDataCopier Instance
        {
            get
            {
                if (_copier != null) return _copier;
                lock (_copierRoot)
                {
                    if (_copier == null)
                        _copier = new SAPDataCopier();
                }
                return _copier;
            }
        }

        public void CopyFromStruct(IRfcStructure data, object dest)
        {
            var dprops = dest.GetType().GetProperties();
            foreach (var prop in dprops)
            {
                var cprops = prop.GetCustomAttributes(true);
                if (cprops.Any(o => o.GetType() == typeof (Ignore)) == false)
                {
                    try
                    {
                        //System.Diagnostics.Debug.WriteLine("LOOK FOR = " + prop.Name + " - " + data.GetString(prop.Name));
                        prop.SetValue(dest, data.GetString(prop.Name));
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }
            }
        }

        public void CopyFromFunction(IRfcFunction func, object dest)
        {
            var dprops = dest.GetType().GetProperties();
            foreach (var prop in dprops)
            {
                var cprops = prop.GetCustomAttributes(true);
                if (cprops.Any(o => o.GetType() == typeof(Ignore)) == false)
                {
                    try
                    {
                        prop.SetValue(dest, func.GetString(prop.Name));
                    }
                    catch (Exception) { }
                }
            }
        }

    }
}