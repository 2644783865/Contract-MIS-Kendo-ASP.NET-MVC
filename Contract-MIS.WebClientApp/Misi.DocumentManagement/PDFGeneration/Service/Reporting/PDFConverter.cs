using System;
using System.Diagnostics;
using System.IO;
using Common.Logging;
using NLog.Internal;


namespace Misi.DocumentManagement.PDFGeneration.Service.Reporting
{
    public class PDFConverter : IPDFConverter    
    {

        private const string HtmlToPdfExePath = @"C:\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";


        //For Invoice Total
        public byte[] Convert(string source, string commandLocation)
        {
            Process p;
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Path.Combine(commandLocation, HtmlToPdfExePath);
            psi.WorkingDirectory = Path.GetDirectoryName(psi.FileName);

            // run the conversion utility
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // note: that we tell wkhtmltopdf to be quiet and not run scripts
            var args = "-q -n ";

            // Global configuration
            args += "--disable-smart-shrinking ";
            args += "--orientation Portrait ";
            args += "--outline-depth 0 ";
            args += "--page-size Letter ";
            args += "--margin-bottom 45mm ";
            args += "--margin-left 15mm ";
            args += "--margin-right 15mm ";
            args += "--margin-top 67mm ";
            args += "--title \"Billing Reporting\" ";
            //args += "--header-html " + hostName + "BillingReporting/" + headerInvoiceBilling + "?bilDoc=" + bilDoc + " ";
            //args += "--footer-right \"Page [Page] / [toPage]\" ";
            args += " - -";

            // Footer configuration
            //args += "--footer-spacing 12 ";
            //args += "--footer-right \"Page [Page] / [toPage]\" ";





            psi.Arguments = args;

            p = Process.Start(psi);

            try
            {
                using (StreamWriter stdin = p.StandardInput)
                {
                    stdin.AutoFlush = true;
                    stdin.Write(source);
                }

                //read output
                byte[] buffer = new byte[32768];
                byte[] file;
                using (var ms = new MemoryStream())
                {
                    while (true)
                    {
                        int read = p.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length);
                        if (read <= 0)
                            break;
                        ms.Write(buffer, 0, read);
                    }
                    file = ms.ToArray();
                }

                p.StandardOutput.Close();
                // wait or exit
                p.WaitForExit(60000);

                // read the exit code, close process
                int returnCode = p.ExitCode;
                p.Close();

                if (returnCode == 0)
                    return file;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                p.Close();
                p.Dispose();
            }
            return null;
        }


        public byte[] ConvertDetail(string source, string commandLocation)
        {
            Process p;
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Path.Combine(commandLocation, HtmlToPdfExePath);
            psi.WorkingDirectory = Path.GetDirectoryName(psi.FileName);

            // run the conversion utility
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // note: that we tell wkhtmltopdf to be quiet and not run scripts
            var args = "-q -n ";

            // Global configuration
            args += "--disable-smart-shrinking ";
            args += "--orientation Portrait ";
            args += "--outline-depth 0 ";
            args += "--page-size Letter ";
            args += "--margin-bottom 45mm ";
            args += "--margin-left 15mm ";
            args += "--margin-right 15mm ";
            args += "--margin-top 67mm ";
            args += "--title \"Billing Reporting\" ";
            //args += "--header-html " + hostName + "BillingReporting/" + headerInvoiceBilling + "?bilDoc=" + bilDoc + " ";
            args += "--footer-right \"Page [Page] / [toPage]\" ";
            args += " - -";

            // Footer configuration
            //args += "--footer-spacing 12 ";
            //args += "--footer-right \"Page [Page] / [toPage]\" ";

            psi.Arguments = args;

            p = Process.Start(psi);

            try
            {
                using (StreamWriter stdin = p.StandardInput)
                {
                    stdin.AutoFlush = true;
                    stdin.Write(source);
                }

                //read output
                byte[] buffer = new byte[32768];
                byte[] file;
                using (var ms = new MemoryStream())
                {
                    while (true)
                    {
                        int read = p.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length);
                        if (read <= 0)
                            break;
                        ms.Write(buffer, 0, read);
                    }
                    file = ms.ToArray();
                }

                p.StandardOutput.Close();
                // wait or exit
                p.WaitForExit(60000);

                // read the exit code, close process
                int returnCode = p.ExitCode;
                p.Close();

                if (returnCode == 0)
                    return file;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                p.Close();
                p.Dispose();
            }
            return null;
        }

       

    }
}