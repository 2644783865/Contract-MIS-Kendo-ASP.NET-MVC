using System;
using System.Linq;

namespace Misi.Common.Lib.Util
{
    public class ClassCopier
    {
        private static volatile ClassCopier _copier;
        private static readonly object _copierRoot = new object();

        public static ClassCopier Instance
        {
            get
            {

                if (_copier != null) return _copier;
                lock (_copierRoot)
                {
                    if (_copier == null)
                        _copier = new ClassCopier();
                }
                return _copier;
            }
        }

        public void Copy(Object src, Object des)
        {
            var stype = src.GetType();
            var dtype = des.GetType();
            var sprops = stype.GetProperties();
            var dprops = dtype.GetProperties();
            foreach (var sp in sprops)
            {

                foreach (var dp in dprops)
                {
                    var cprops = dp.GetCustomAttributes(true);
                    if (cprops.Any(o => o.GetType() == typeof(Ignore)) == false)
                    {
                        if (dp.Name == sp.Name)
                        {
                            try
                            {
                                dp.SetValue(des, sp.GetValue(src));
                            }
                            catch (Exception e) { }
                        }
                    }
                }
            }
        }
    }
}