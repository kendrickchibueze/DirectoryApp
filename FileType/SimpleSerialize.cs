using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace FileType
{
    internal class SimpleSerialize
    {

        public static void RunSimpleSerialize()
        {

            Console.WriteLine("***** Fun with Object Serialization *****\n");

            var theRadio = new Radio
            {
                StationPresets = new() { 89.3, 105.1, 97.1 },
                HasTweeters = true
            };
            // Make a JamesBondCar and set state.
            JamesBondCar jbc = new()
            {
                CanFly = true,
                CanSubmerge = false,
                TheRadio = new()
                {
                    StationPresets = new() { 89.3, 105.1, 97.1 },
                    HasTweeters = true
                }
            };
            List<JamesBondCar> myCars = new()
            {
             new JamesBondCar { CanFly = true, CanSubmerge = true, TheRadio = theRadio },
             new JamesBondCar { CanFly = true, CanSubmerge = false, TheRadio = theRadio },
             new JamesBondCar { CanFly = false, CanSubmerge = true, TheRadio = theRadio },
             new JamesBondCar { CanFly = false, CanSubmerge = false, TheRadio = theRadio },
            };
            Person p = new Person
            {
                FirstName = "James",
                IsAlive = true
            };

            //ready for serialization output 
            SaveAsXmlFormat(jbc, "CarData.xml");
            Console.WriteLine("=> Saved car in XML format!");
            SaveAsXmlFormat(p, "PersonData.xml");
            Console.WriteLine("=> Saved person in XML format!");


            //serializing a collection

            SaveAsXmlFormat(myCars, "CarCollection.xml");
            Console.WriteLine("=> Saved list of cars!");




            // reconstitute your XML back into objects (or list of  objects):

            JamesBondCar savedCar = ReadAsXmlFormat<JamesBondCar>("CarData.xml");
            Console.WriteLine("Original Car:\t {0}", jbc.ToString());
            Console.WriteLine("Read Car:\t {0}", savedCar.ToString());


            List<JamesBondCar> savedCars = ReadAsXmlFormat<List<JamesBondCar>>("CarCollection.xml");




            //JSON Serialization
            SaveAsJsonFormat(jbc, "CarData.json");
            Console.WriteLine("=> Saved car in JSON format!");
            SaveAsJsonFormat(p, "PersonData.json");
            Console.WriteLine("=> Saved person in JSON format!");



            JsonSerializerOptions options = new(JsonSerializerDefaults.General)
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                PropertyNameCaseInsensitive = true
            };

            //seializing  a collection of object into JSON
            //SaveAsJsonFormat(options, myCars, "CarCollection.json");


            //reconstitute your XML back into objects (or list of objects):
            JamesBondCar savedJsonCar = ReadAsJsonFormat<JamesBondCar>(options, "CarData.json");
            Console.WriteLine("Read Car: {0}", savedJsonCar.ToString());
            List<JamesBondCar> savedJsonCars = ReadAsJsonFormat<List<JamesBondCar>>(options,
            "CarCollection.json");
            Console.WriteLine("Read Car: {0}", savedJsonCar.ToString());


            //Note that the type being created during the deserializing process can be a single object or a generic collection


        }


        //The XmlSerializer demands that all serialized types in the object graph support a default 
        //constructor(so be sure to add it back if you define custom constructors).


        static void SaveAsXmlFormat<T>(T objGraph, string fileName)
        {
            //Must declare type in the constructor of the XmlSerializer
            XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
            using (Stream fStream = new FileStream(fileName,
            FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
        }




        //Consider the
        //following local function to deserialize XML back into an object graph.Notice that, once again, the type to be
        //deserialized must be passed into the constructor for the XmlSerializer:
        static T ReadAsXmlFormat<T>(string fileName)
        {
            // Create a typed instance of the XmlSerializer
            XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
            using (Stream fStream = new FileStream(fileName, FileMode.Open))
            {
                T obj = default;


                obj = (T)xmlFormat.Deserialize(fStream);

                return obj;
            }
        }


        public static void SaveAsJsonFormat<T>(T objGraph, string fileName)
        {

            var options = new JsonSerializerOptions
            {
                //PropertyNamingPolicy = null,
                //IncludeFields = true,
                //WriteIndented = true,



                PropertyNameCaseInsensitive = true,
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = null, //Pascal casing
                IncludeFields = true,
                WriteIndented = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
            };

            File.WriteAllText(fileName, System.Text.Json.JsonSerializer.Serialize(objGraph, options));



        }


        //Instead of using the JsonSerializerOptions, you can achieve the same result by updating all public 
        //fields in the sample classes to use [JSONInclude]






        //When reading JSON, C# is (by default) case sensitive. The casing setting of the PropertyNamingPolicy
        //is used during Deserialization.If the property is not set, the default (camel casing) is used.By setting the
        //PropertyNamingPolicy to Pascal case, then all incoming JSON is expected to be in Pascal case. If the casing
        //does not match, the deserialization process(covered soon) fails.



        // The following function will deserialize JSON into the 
        //type specified using the generic version of the method:
      public  static T ReadAsJsonFormat<T>(JsonSerializerOptions options, string fileName) =>System.Text.Json.JsonSerializer.Deserialize<T>(File.ReadAllText(fileName), options);






    }











    public class Radio
    {
        public bool HasTweeters;
        public bool HasSubWoofers;
        public List<double> StationPresets;
        public string RadioId = "XF-552RR6";
        public override string ToString()
        {
            var presets = string.Join(",", StationPresets.Select(i => i.ToString()).ToList());
            return $"HasTweeters:{HasTweeters} HasSubWoofers:{HasSubWoofers} Station Presets:{presets}";
        }
    }


    public class Car
    {
        public Radio TheRadio = new Radio();
        public bool IsHatchBack;
        public override string ToString()
        => $"IsHatchback:{IsHatchBack} Radio:{TheRadio.ToString()}";
    }



    //    If you want to specify a custom XML namespace that qualifies the JamesBondCar and encodes the
    //canFly and canSubmerge values as XML attributes instead of elements, you can do so by modifying the C# 
    //definition of JamesBondCar like this:




    [Serializable, XmlRoot(Namespace = "http://www.MyCompany.com")]
    public class JamesBondCar : Car
    {

        [XmlAttribute]
        public bool CanFly;

        [XmlAttribute]
        public bool CanSubmerge;
        public override string ToString()
        => $"CanFly:{CanFly}, CanSubmerge:{CanSubmerge} {base.ToString()}";
    }

    public class Person
    {
        // A public field.
        public bool IsAlive = true;
        // A private field.
        private int PersonAge = 21;
        // Public property/private data.
        private string _fName = string.Empty;

        public string FirstName
        {
            get { return _fName; }
            set { _fName = value; }
        }
        public override string ToString() =>
        $"IsAlive:{IsAlive} FirstName:{FirstName} Age:{PersonAge} ";
    }

    //    Notice how the PersonAge property is not serialized into the XML.This confirms that XML serialization
    //serializes only public properties and fields


    //public class Person
    //{
    //    [JsonPropertyOrder(1)]
    //    public bool IsAlive = true;
    //    private int PersonAge = 21;
    //    private string _fName = string.Empty;
    //    [JsonPropertyOrder(-1)]
    //    public string FirstName
    //    {
    //        get { return _fName; }
    //        set { _fName = value; }
    //    }
    //    public override string ToString() => $"IsAlive:{IsAlive} FirstName:{FirstName} Age:{PersonAge }";
    //}

}
