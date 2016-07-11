# basic-xml-parser
Basic C# .NET XML parser

## Description:

This is a basic XML parser that reads XML from a file and turns it into a C# object. It is not very extensible and I have just implemented it to try and learn about how dynamic objects work in C#.  

As of current it only supports a few features:
- Loading XML into a dynamic objects
- Querying the object by the . Member access operator
- Querying the object by the [int:index] operator

As of current there is no support for Attributes.

## Install

### Windows

```cmd
git clone https://github.com/Wamadahama/basic-xml-parser.git
```

Open the ```.sln``` in Visual Studio and select Build and Run

### Linux (.NET Core)
This needs testing
```sh
git clone https://github.com/Wamadahama/basic-xml-parser.git
dotnet restore
dotnet run
```

## Usage

### File sample

This sample XML document will be used to demonstrate the features of the parser

```xml
<?xml version="1.0" encoding="utf-8" ?>
<sample>
  <foo>2</foo>
  <bar>3</bar>

  <foobar>
    <foo>bar</foo>
    <bar>foo</bar>
  </foobar>

  <foobarbazz>
    <foo>1</foo>
    <bar>2</bar>
    <bazz>3</bazz>
  </foobarbazz>

</sample>
```

### Initialization
Add ```DynamicXmlObject.cs``` to your project (I have yet to make this into a class library because of the size)

and inlcude the Namespace with
```cs
using XmlParser;
```

### Loading an XML file
```cs
dynamic Test = new DynamicXmlObject(@"Path/To/File.xml");
```

### Using . Member Access

```cs
  Console.WriteLine(Test.bar.ToString()); // => 3
```

### Chained . Member Access
```cs
Console.WriteLine(Test.foobar.foo); // => bar
```

### Integer Index
```cs
Console.WriteLine(Test.foobar[0].ToString()); // => bar
```

### ToList<string>
```cs
List<string> Foobar = Test.foobar.ToList();
Foobar.ForEach((elem) => { Console.WriteLine(elem.ToString()); }); // => bar\nfoo\n
```
