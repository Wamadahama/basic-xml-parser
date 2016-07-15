dotnet new
mv basic-xml-parser/Program.cs basic-xml-parser/DynamicXmlObject.cs basic-xml-parser/Samples//sample.xml . 
rm -rf bin obj basic-xml-parser-tests basic-xml-parser
dotnet restore
dotnet run
