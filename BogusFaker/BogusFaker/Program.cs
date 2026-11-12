using Bogus;
using BogusFaker;

var customerFaker = new Faker<Customer>(locale: "fr")
            .RuleFor(c => c.Id, f => f.IndexFaker + 1)
            .RuleFor(c => c.Name, f => f.Name.FullName()) 
            .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber()) 
            .RuleFor(c => c.City, f => f.Address.City());


var singleCustomer = customerFaker.Generate();
Console.WriteLine($"Customer: {singleCustomer.Name}, City: {singleCustomer.City}");


var multipleCustomers = customerFaker.Generate(10);
foreach (var customer in multipleCustomers)
{
    Console.WriteLine($"Id: {customer.Id}, \t Customer: {customer.Name}, \t Phone: {customer.Phone}, \t City: {customer.City}");
}
