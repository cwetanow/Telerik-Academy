## XML Basics
### _Homework_

1.  What does the XML language represent? What is it used for? 
* `XML` (eXtensible Markup Language)
  * Universal language (notation) for describing structured data using **text with tags**
  * The data is stored together with the meta-data about it
  * Used to describe other languages (formats) for data representation
  * XML looks like HTML
  * Text based language, uses tags and attributes
  * Worldwide standard - supported by the W3C - [www.w3c.org](http://www.w3.org/)
* Independent of
  * Hardware platform
  * Operating system
  * Programming languages

* Advantages of XML:
  * XML is human readable (unlike binary formats)
  * Any kind of structured data can be stored
  * Data comes with self-describing meta-data
  * Custom XML-based languages can be developed for certain applications
  * Information can be exchanged between different systems with ease
  * Unicode is fully supported

* Disadvantages of XML:
  * XML data is bigger (takes more space) than in binary formats
    * More memory consumption, more network traffic, more hard-disk space
  * Decreased performance
    * Need of parsing / constructing the XML tags
* XML is not suitable for all kinds of data
  * E.g. graphics, images and video clips

1.  Create XML document `students.xml`, which contains structured description of students.
  * For each student you should enter information for his name, sex, birth date, phone, email, course, specialty, faculty number and a list of taken exams (exam name, tutor, score).
1.  What do namespaces represent in an XML document? What are they used for? 
* Namespaces in XML documents allow using different tags with the same name:
```xml
<?xml version="1.0" encoding="UTF-8"?>
<country:towns
    xmlns:country="urn:academy-com:country"
    xmlns:town="http://www.academy.com/towns/1.0">
  <town:town>
    <town:name>Plovdiv</town:name>
    <town:population>700 000</town:population>
    <country:name>Bulgaria</country:name>
  </town:town>
</country:towns>
```

```xml
<?xml version="1.0" encoding="windows-1251"?>
<order xmlns="http://www.supermarket.com/orders/1.1">
  <item>
    <name>Beer "Zagorka"</name>
    <ammount>8</ammount>
    <measure>bottle</measure>
    <price>5.60</price>
  </item>
  <item>
    <name>Meat balls</name>
    <ammount>12</ammount>
    <measure>amount</measure>
    <price>5.40</price>
  </item>
</order>
```
Default namespace – applied for the entire XML document

XSLT is a language that can be used to transform XML documents into other formats. The namespace identifies XSLT elements inside an HTML document.

1.  Explore http://en.wikipedia.org/wiki/Uniform_Resource_Identifier to learn more about URI, URN and URL definitions.
1.  Add default namespace for students "`urn:students`".
1.  Create XSD Schema for `students.xml` document.
  * Add new elements in the schema: information for enrollment (date and exam score) and teacher's endorsements.
1.  Write an XSL stylesheet to visualize the students as HTML.
  * Test it in your favourite browser.
