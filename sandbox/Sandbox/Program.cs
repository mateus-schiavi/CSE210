using System;

class Program
{
    static string _decision;
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Encapsulation");
            Console.WriteLine("a. Principles");
            Console.WriteLine("b. Benefits");
            Console.WriteLine("c. Application");
            Console.WriteLine("d. Example of Encapsulation");
            _decision = Console.ReadLine();

            if(_decision == "a")
            {
                Console.WriteLine("The principles of Encapsulation are 4: Data Abstraction¹, Data Encapsulation², Data Hiding³, and Information Hiding¹¹");
                Console.WriteLine("¹Helps to hide internal details of an object and only exposing the necessary information. This helps to keep the code more robust and an easier maintenance");
                Console.WriteLine("²This means that the data which is being protected cannot be accessed through external sources, and its manipulation can only be done through methods and properties defined in the respective class");
                Console.WriteLine("³This allows developers to keep hide the implementation details of a class from other parts of the code, making the project more secure and less prone to errors and bugs");
                Console.WriteLine("¹¹This makes easier the implementation without affecting the rest of the code, in other words, when you hide an information through encapsulation and access it through methods, you are not affecting the code, only manipulating the data stored in the encapsulation");

            }
            else if(_decision == "b")
            {
                Console.WriteLine("Two benefits of encapsulation is: Enhanced code security¹ and Improve code maintainability².");
                Console.WriteLine("¹This helps to protect the data or values stored from unauthorized access or modification by external sources. This tool helps in reducing the risk of bugs and vulnerabilities in the code");
                Console.WriteLine("²This helps to organize the code into modular components that can be easily understood and managed, making it easier to work with large codebases");
            }
            else if (_decision == "c")
            {
                Console.WriteLine("Encapsulation can be applied when you want to hide values and keep it far from errors or bugs");
                Console.WriteLine("One example of encapsulation is the using of getters and setters");
                Console.WriteLine("Getters has the responsability of returning an speficic value according to the code");
                Console.WriteLine("And setters has the responsability of defining an specific value according to the code");
            }
            else if(_decision == "d")
            {
                Console.WriteLine("One application of encapsulation in C# can be:");
                Console.WriteLine("I will give an example from a code I wrote");
                Console.WriteLine("Class Scripture");
                Console.WriteLine("private string _quotation, _reference");
                Console.WriteLine("Public Scripture{}");
                Console.WriteLine("Public Scripture(string strquotation, string strreference)");
                Console.WriteLine("{");
                Console.WriteLine("setQuotation(strquotation)");
                Console.WriteLine("setReference(strreference)");
                Console.WriteLine("}");
                Console.WriteLine("public string getQuotation()");
                Console.WriteLine("{");
                Console.WriteLine("return this._quotation");
                Console.WriteLine("}");
                Console.WriteLine("public string getReference()");
                Console.WriteLine("{");
                Console.WriteLine("return this._reference");
                Console.WriteLine("}");
                Console.WriteLine("public string setQuotation(string strquotation)");
                Console.WriteLine("{");
                Console.WriteLine("this._quotation = strquotation");
                Console.WriteLine("}");
                Console.WriteLine("public string setReference(strreference)");
                Console.WriteLine("{");
                Console.WriteLine("this._reference = strreference");
                Console.WriteLine("}");
                Console.WriteLine("public string Quotation");
                Console.WriteLine("{");
                Console.WriteLine("get {return this._quotation;}");
                Console.WriteLine("set{this._quotation = value;}");
                Console.WriteLine("}");
                Console.WriteLine("public string Reference");
                Console.WriteLine("{");
                Console.WriteLine("get{return this._reference;}");
                Console.WriteLine("set{this._reference = value;}");
                Console.WriteLine("}");   

                Console.WriteLine("In the example above, the values will be stored in two variables: quotation and reference, as it is not possible to access it directly, it's possible to access their values through the Scripture method");
            }
            else
            {
                Console.WriteLine("Option not available");
            }

        }
        catch (Exception ex)
        {
            
            throw new Exception("An Error Has Occurred =>" + ex.Message);
        }

    }
}