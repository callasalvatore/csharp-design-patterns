
using FactoryMethod.Sender;

NotificationSender emailSender = new EmailSender();
var emailNotification = emailSender.CreateNotification();
emailNotification.Send("Hello, this is an email notification!");

var smsSender = new SmsSender();
var smsNotification = smsSender.CreateNotification();
smsNotification.Send("This is an SMS notification.");

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
