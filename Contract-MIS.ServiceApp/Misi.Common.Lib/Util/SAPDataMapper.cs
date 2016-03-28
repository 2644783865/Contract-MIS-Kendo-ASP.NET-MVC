using System;
using System.Linq;

namespace Misi.Common.Lib.Util
{
    public class SAPDataMapper
    {
        private static volatile SAPDataMapper _mapper;
        private static readonly object _copierRoot = new object();

        public static SAPDataMapper Instance
        {
            get
            {
                if (_mapper != null) return _mapper;
                lock (_copierRoot)
                {
                    if (_mapper == null)
                        _mapper = new SAPDataMapper();
                }
                return _mapper;
            }
        }

        public void MapFields(object src, object des)
        {
            var stype = src.GetType();
            var dtype = des.GetType();
            var sprops = stype.GetProperties();
            var dprops = dtype.GetProperties();
            foreach (var dp in dprops)
            {
                var cprops = dp.GetCustomAttributes(true);
                if (cprops.Any(o => o.GetType() == typeof (SAPDataField)))
                {
                    var vo = dp.GetCustomAttributes(typeof (SAPDataField), true)[0] as SAPDataField;
                    if (vo == null) continue;
                    //System.Diagnostics.Debug.WriteLine("LOOK = " + dp.Name + " ==> SOURCE: " + vo.Field);
                    foreach (var sp in sprops.Where(sp => vo.Field == sp.Name))
                    {
                        try
                        {
                            if (dp.PropertyType == typeof (DateTime))
                            {
                                if (sp.GetValue(src) != null && sp.GetValue(src).ToString().Trim().Length > 0)
                                    dp.SetValue(des, DateTime.ParseExact(sp.GetValue(src) as string, "yyyy-MM-dd", 
                                        System.Globalization.CultureInfo.InvariantCulture));
                            }
                            else if (dp.PropertyType == typeof(Int32))
                            {
                                if (sp.GetValue(src) != null && sp.GetValue(src).ToString().Trim().Length > 0)
                                    dp.SetValue(des, int.Parse(sp.GetValue(src).ToString()));
                            }
                            else if (dp.PropertyType == typeof(Double))
                            {
                                if (sp.GetValue(src) != null && sp.GetValue(src).ToString().Trim().Length > 0)
                                    dp.SetValue(des, Double.Parse(sp.GetValue(src).ToString()));
                            }
                            else
                            {
                                if (sp.GetValue(src) != null)
                                    dp.SetValue(des, sp.GetValue(src));
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
    }
}