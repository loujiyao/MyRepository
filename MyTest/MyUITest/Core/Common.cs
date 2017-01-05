using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace MyUITest
{
    [Serializable]
    [XmlRoot("Parameters")]
    public class NameValues : List<NameValue>, IXmlSerializable
    {
        private const string XMLNS_XSI = "http://www.w3.org/2001/XMLSchema-instance";
        private const string XMLNS_XSD = "http://www.w3.org/2001/XMLSchema";

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            string xmlString = reader.ReadOuterXml();

            Type nameValueType = typeof(NameValue);
            //Assign default element name as class name
            string name = nameValueType.Name;

            //Read element name from XmlRootAttribute, if exists
            XmlRootAttribute xmlRootAttribute = typeof(NameValue).GetCustomAttributes(true).OfType<XmlRootAttribute>().FirstOrDefault();
            if (xmlRootAttribute != null && !string.IsNullOrEmpty(xmlRootAttribute.ElementName))
                name = xmlRootAttribute.ElementName;

            foreach (var element in XElement.Parse(xmlString).Elements(name))
            {
                //Serialize each node append to collection
                Add(ObjectSerializer.Deserialize<NameValue>(element.ToString()));
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            //Write defult namespace attributes
            writer.WriteAttributeString("xmlns", "xsi", null, XMLNS_XSI);
            writer.WriteAttributeString("xmlns", "xsd", null, XMLNS_XSD);

            //1. Read each item from collection
            //2. Serialize read item
            //3. Write onto stream
            ForEach(delegate(NameValue value)
            {
                XElement root = XDocument.Parse(ObjectSerializer.Serialize(value)).Root;

                //Remove the Root level namespaces
                var xsiAttribute = root.Attributes().FirstOrDefault(xAttr => xAttr.Name.LocalName == "xsi" && xAttr.Value == XMLNS_XSI);
                if (xsiAttribute != null) xsiAttribute.Remove();
                var xsdAttribute = root.Attributes().FirstOrDefault(xAttr => xAttr.Name.LocalName == "xsd" && xAttr.Value == XMLNS_XSD);
                if (xsdAttribute != null) xsdAttribute.Remove();

                //Write onto stream
                root.WriteTo(writer);
            });
        }

        #endregion
    }

    /// <summary>
    /// Represents Name and Value pair
    /// </summary>
    [Serializable]
    [XmlRoot("Parameter")]
    public class NameValue
    {
        /// <summary>
        /// Name of the property
        /// </summary>
        [XmlAttribute()]
        public string Name { get; set; }
        /// <summary>
        /// Value of the property
        /// </summary>
        [XmlAttribute()]
        public string Value { get; set; }

        /// <summary>
        /// List of NameValues collection
        /// </summary> 
        [XmlArray("ParameterItems")]
        [XmlArrayItem("ParameterItem", Type = typeof(NameValues))]
        public List<NameValues> NameValues { get; set; }
    }

    public class ExtendedProperty
    {
        [XmlAttribute]
        public String Name { get; set; }

        [XmlAttribute]
        public string Value { get; set; }
    }

    /// <summary>
    /// Helper class to serialize and deserialize object
    /// </summary>
    public static class ObjectSerializer
    {
        #region XmlSerializer

        /// <summary>
        /// Serialize Object using XmlSerializer
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Serialize(object value)
        {
            StringBuilder result = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(value.GetType());
            XmlWriterSettings xwSettings = new XmlWriterSettings();

            xwSettings.Indent = true;

            using (var sw = new StringWriter(result))
            using (var xw = XmlWriter.Create(sw, xwSettings))
            {
                serializer.Serialize(xw, value);
            }

            return result.ToString();
        }

        /// <summary>
        /// Deserialize serialized xml using XmlSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string data)
        {
            return (T)Deserialize(data, typeof(T));
        }

        /// <summary>
        /// Deserialize serialized xml using XmlSerializer
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(string data, Type type)
        {
            object result;

            XmlSerializer serializer = new XmlSerializer(type);

            using (var sr = new StringReader(data))
            {
                result = serializer.Deserialize(sr);
            }

            return result;
        }

        #endregion

        #region DataContractSerializer

        /// <summary>
        /// Serialize Object using DataContractSerializer
        /// </summary>
        /// <param name="value">Object graph to be serialized</param>        
        /// <param name="knownTypes">Additional types to be included during serialization</param>
        /// <returns></returns>
        public static string Serialize(object value, params Type[] knownTypes)
        {
            StringBuilder result = new StringBuilder();

            DataContractSerializer serializer = (knownTypes != null && knownTypes.Length > 0) ? new DataContractSerializer(value.GetType(), knownTypes) : new DataContractSerializer(value.GetType());

            using (var wr = XmlWriter.Create(result))
            {
                serializer.WriteObject(wr, value);
            }

            return result.ToString();
        }

        /// <summary>
        /// Deserialize xml string using DataContractSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="knownTypes"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string data, params Type[] knownTypes)
        {
            return (T)Deserialize(data, typeof(T), knownTypes);
        }

        /// <summary>
        /// Deserialize xml string using DataContractSerializer
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="knownTypes"></param>
        /// <returns></returns>
        public static object Deserialize(string data, Type type, params Type[] knownTypes)
        {
            object result;

            DataContractSerializer serializer = (knownTypes != null && knownTypes.Length > 0) ? new DataContractSerializer(type, knownTypes) : new DataContractSerializer(type);

            using (var sr = new StringReader(data))
            using (var reader = XmlReader.Create(sr))
            {
                result = serializer.ReadObject(reader);
            }

            return result;
        }

        #endregion
    }
}


