using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.DAL.Import;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.MediaContentScheduler.Tester
{
    class Program
    {

        public delegate void CmdHandler(string[] args);
        private static readonly Dictionary<string, CmdHandler> _cmdHandlers;


        static Program()
        {
            _cmdHandlers = new Dictionary<string, CmdHandler>();
            _cmdHandlers.Add("testxmlimporter", TestXmlImporter);
            _cmdHandlers.Add("testxmlimporterex", TestXmlImporterEx);
            _cmdHandlers.Add("testxmlimporterexcut", TestXmlImporterExCut);
        }

        static void Main(string[] args)
        {
            Console.Read();
            string cmdHandlerKey = string.Empty;
            if(args.Length > 0)
                cmdHandlerKey = args[0].ToLower();
            if (string.IsNullOrEmpty(cmdHandlerKey) || !_cmdHandlers.ContainsKey(cmdHandlerKey))
                TestXmlImporter(args);
            else
                _cmdHandlers[cmdHandlerKey](args);
       }

        private static void TestXmlImporter(string[] args)
        {
            XmlImporter importer = new XmlImporter();
            importer.Import(@"D:\home\vmdrot\DEV\Evolvex.RadioVolya.MediaContentScheduler\Testing\Data\all_edited.xml");
            PrintRslts(importer.Tracks);
        }


        private static void TestXmlImporterEx(string[] args)
        {
            XmlImporterEx importer = new XmlImporterEx();
            //importer.Import(@"D:\home\vmdrot\DEV\Evolvex.RadioVolya.MediaContentScheduler\Testing\Data\all_edited.xml");
            importer.Import(@"D:\home\vmdrot\DEV\Evolvex.RadioVolya.MediaContentScheduler\Testing\Data\all.xml");
            PrintRslts(importer.Tracks);
        }

        private static void TestXmlImporterExCut(string[] args)
        {
            XmlImporterEx importer = new XmlImporterEx();
            importer.Import(@"D:\home\vmdrot\DEV\Evolvex.RadioVolya.MediaContentScheduler\Testing\Data\test_cut.xml");
            PrintRslts(importer.Tracks);
        }

        private static void PrintRslts(List<ITrackInfo> list)
        {
            foreach (ITrackInfo ti in list)
            {
                Console.WriteLine(ti);
            }
        }
    }
}
