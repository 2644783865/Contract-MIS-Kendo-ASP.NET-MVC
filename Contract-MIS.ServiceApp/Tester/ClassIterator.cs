using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    public class ClassIterator
    {
        private static volatile ClassIterator _copier;
        private static readonly object _classIterator = new object();

        public static ClassIterator Instance
        {
            get
            {
                if (_copier != null) return _copier;
                lock (_classIterator)
                {
                    if (_copier == null)
                        _copier = new ClassIterator();
                }
                return _copier;
            }
        }

        public void Iterate(Object src)
        {
            var main = src.GetType();
            var count = 0;
            System.Diagnostics.Debug.WriteLine("BASE [" + count++ + "] = " + main);
            while (main.BaseType != null)
            {
                if (main.BaseType.Namespace != null && !main.BaseType.Namespace.StartsWith("System"))
                {
                    var bt = main.BaseType;
                    System.Diagnostics.Debug.WriteLine("BASE [" + count++ + "] = " + bt);
                    main = bt;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
