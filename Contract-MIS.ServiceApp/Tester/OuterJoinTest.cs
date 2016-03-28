using System;
using System.Collections.Generic;
using System.Linq;

namespace Tester
{
    public class OuterJoinTest
    {
        public static void Main2(string[] args)
        {
            var tblHeader = GetHeaders();
            var tblItem = GetItems();
            var tblBilling = GetBillings();

            var enumerable = tblHeader as IList<Header> ?? tblHeader.ToList();
            var header2ItemJoin = LeftJoin(enumerable, tblItem,
                h => h.ContractNo, i => i.ContractNo,
                (h, i) => new { Header = h, Item = i }).Select(i => new Header2ItemJoin
                {
                    HolderName = i.Header.HolderName,
                    ContractNo = i.Header.ContractNo,
                    ContractLineNo = i.Item.ContractLineNo,
                    Material = i.Item.Material
                });

            System.Diagnostics.Debug.WriteLine("==================================== JOIN 1");
            foreach (var o in header2ItemJoin)
            {
                System.Diagnostics.Debug.WriteLine(o.HolderName + "|" + o.ContractNo + "|" + o.ContractLineNo);
            }
            System.Diagnostics.Debug.WriteLine("====================================");

            var header2BillingJoin = LeftJoin(enumerable, tblBilling,
                h => h.ContractNo, b => b.ContractNo,
                (h, b) => new { Header = h, Billing = b }).Select(i => new Header2BillingJoin
                {
                    HolderName = i.Header.HolderName,
                    ContractNo = i.Header.ContractNo,
                    ContractLineNo = i.Billing.ContractLineNo,
                    Charges = i.Billing.Charges
                });
            System.Diagnostics.Debug.WriteLine("==================================== JOIN 2");
            foreach (var o in header2BillingJoin)
            {
                System.Diagnostics.Debug.WriteLine(o.HolderName + "|" + o.ContractNo + "|" + o.ContractLineNo + "|" + o.Charges);
            }
            System.Diagnostics.Debug.WriteLine("====================================");

            var tbl1 = header2ItemJoin as List<Header2ItemJoin>;
            var tbl2 = header2BillingJoin as List<Header2BillingJoin>;

            var newList = new List<object>();
            var fullOuterJoin = FullOuterJoinJoin(tbl1.AsEnumerable(), tbl2.AsEnumerable(),
                x => x.ContractLineNo, y => y.ContractLineNo, (x, y) => new {TableOne = x, TableTwo = y}).Select(o => new
                {
                    HolderName = o.TableOne.HolderName,
                    ContractNo = o.TableOne.ContractNo,
                    ContractLineNo = o.TableOne.ContractLineNo,
                    Material = o.TableOne.Material,
                    Charges = o.TableTwo.Charges
                });
            System.Diagnostics.Debug.WriteLine("==================================== JOIN 3");
            foreach (var o in fullOuterJoin)
            {
                System.Diagnostics.Debug.WriteLine(o.HolderName + "|" + o.ContractNo + "|" + o.ContractLineNo + "|" + o.Material + "|" + o.Charges);
            }
            System.Diagnostics.Debug.WriteLine("====================================");
        }

        public static IEnumerable<TResult> LeftJoin<TSource, TInner, TKey, TResult>(IEnumerable<TSource> source,
                                                 IEnumerable<TInner> inner,
                                                 Func<TSource, TKey> pk,
                                                 Func<TInner, TKey> fk,
                                                 Func<TSource, TInner, TResult> result)
        {
            IEnumerable<TResult> _result = Enumerable.Empty<TResult>();

            _result = from s in source
                      join i in inner
                      on pk(s) equals fk(i) into joinData
                      from left in joinData.DefaultIfEmpty()
                      select result(s, left);

            return _result;
        }

        public static IEnumerable<TResult> RightJoin<TSource, TInner, TKey, TResult>(IEnumerable<TSource> source,
                                                  IEnumerable<TInner> inner,
                                                  Func<TSource, TKey> pk,
                                                  Func<TInner, TKey> fk,
                                                  Func<TSource, TInner, TResult> result)
        {
            IEnumerable<TResult> _result = Enumerable.Empty<TResult>();

            _result = from i in inner
                      join s in source
                      on fk(i) equals pk(s) into joinData
                      from right in joinData.DefaultIfEmpty()
                      select result(right, i);

            return _result;
        }

        public static IEnumerable<TResult> FullOuterJoinJoin<TSource, TInner, TKey, TResult>(IEnumerable<TSource> source,
                                                          IEnumerable<TInner> inner,
                                                          Func<TSource, TKey> pk,
                                                          Func<TInner, TKey> fk,
                                                          Func<TSource, TInner, TResult> result)
        {
            var enumerable = source as IList<TSource> ?? source.ToList();
            var inners = inner as IList<TInner> ?? inner.ToList();
            var left = LeftJoin(enumerable, inners, pk, fk, result).ToList();
            var right = RightJoin(enumerable, inners, pk, fk, result).ToList();

            return left.Union(right);
        }

        private static IEnumerable<Header> GetHeaders()
        {
            var tblHeader = new List<Header>
            {
                new Header
                {
                    No = 1,
                    ContractNo = "1001",
                    HolderName = "John Doe",
                    SalaryNumber = "123456"
                },
                new Header
                {
                    No = 2,
                    ContractNo = "1002",
                    HolderName = "Mike Doe",
                    SalaryNumber = "234567"
                },
                new Header
                {
                    No = 3,
                    ContractNo = "1003",
                    HolderName = "Michele Doe",
                    SalaryNumber = "345678"
                },
                new Header
                {
                    No = 1,
                    ContractNo = "1004",
                    HolderName = "Wanna Doe",
                    SalaryNumber = "456789"
                },
            };
            return tblHeader;
        }

        private static IEnumerable<Item> GetItems()
        {
            var tblItem = new List<Item>
            {
                new Item
                {
                    No = 1,
                    ContractNo = "1001",
                    ContractLineNo = "10",
                    Material = "Laptop"
                },
                new Item
                {
                    No = 2,
                    ContractNo = "1001",
                    ContractLineNo = "20",
                    Material = "Smartphone"
                },
                new Item
                {
                    No = 3,
                    ContractNo = "1001",
                    ContractLineNo = "30",
                    Material = "Email"
                },
                new Item
                {
                    No = 4,
                    ContractNo = "1002",
                    ContractLineNo = "10",
                    Material = "Desktop PC"
                },
                new Item
                {
                    No = 5,
                    ContractNo = "1002",
                    ContractLineNo = "20",
                    Material = "Tablet"
                },
                new Item
                {
                    No = 6,
                    ContractNo = "1003",
                    ContractLineNo = "10",
                    Material = "Email"
                },
                new Item
                {
                    No = 7,
                    ContractNo = "1003",
                    ContractLineNo = "20",
                    Material = "Ext Line"
                },
                new Item
                {
                    No = 8,
                    ContractNo = "1004",
                    ContractLineNo = "10",
                    Material = "Company Car"
                },
            };
            return tblItem;
        }

        private static IEnumerable<Billing> GetBillings()
        {
            var tblBilling = new List<Billing>
            {
                new Billing
                {
                    No = 1,
                    ContractNo = "1001",
                    ContractLineNo = "10",
                    Charges = "1000"
                },
                new Billing
                {
                    No = 2,
                    ContractNo = "1001",
                    ContractLineNo = "30",
                    Charges = "500"
                },
                new Billing
                {
                    No = 3,
                    ContractNo = "1002",
                    ContractLineNo = "20",
                    Charges = "10000"
                },
                new Billing
                {
                    No = 4,
                    ContractNo = "1003",
                    ContractLineNo = "20",
                    Charges = "5000"
                },
                new Billing
                {
                    No = 5,
                    ContractNo = "1004",
                    ContractLineNo = "10",
                    Charges = "2000000"
                },
            };
            return tblBilling;
        }
    }

    public class Header
    {
        public int No { get; set; }
        public string ContractNo { get; set; }
        public string HolderName { get; set; }
        public string SalaryNumber { get; set; }
    }

    public class Item
    {
        public int No { get; set; }
        public string ContractNo { get; set; }
        public string ContractLineNo { get; set; }
        public string Material { get; set; }
    }

    public class Billing
    {
        public int No { get; set; }
        public string ContractNo { get; set; }
        public string ContractLineNo { get; set; }
        public string Charges { get; set; }
    }

    public class Header2ItemJoin
    {
        public string HolderName { get; set; }
        public string ContractNo { get; set; }
        public string ContractLineNo { get; set; }
        public string Material { get; set; }
    }

    public class Header2BillingJoin
    {
        public string HolderName { get; set; }
        public string ContractNo { get; set; }
        public string ContractLineNo { get; set; }
        public string Charges { get; set; }
    }
}
