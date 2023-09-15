using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

//Doc: https://firebase.google.com/docs/cloud-messaging/send-message

// Firebase -> Project Settings -> Service Accounts -> Generate new private key
var token = "YOUR_TOKEN";
var topic = "YOUR-TOPIC";
var jsonFilePath = "YOUR-JSON-FILE-PATH";

FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile(jsonFilePath),
});

var messages = new List<Message>()
{
    new Message()
    {
        Notification = new Notification()
        {
             Body = "BODY MESSAGE TOPIC",
             Title = "TITLE TOPIC",
             ImageUrl = ""
        },
        Data = new Dictionary<string, string>()
        {
            { "Data1Key", "Data1Value" },
            { "Data2Key", "Data2Value" },
        },
        Token = token,
    },
    new Message()
    {
        Notification = new Notification()
        {
            Body = "BODY MESSAGE TOPIC",
            Title = "TITLE TOPIC",
            ImageUrl = ""
        },
        Data = new Dictionary<string, string>()
        {
            { "Data1Key", "Data1Value" },
            { "Data2Key", "Data2Value" },
        },
        Topic = topic,
    },
};

var response = await FirebaseMessaging.DefaultInstance.SendEachAsync(messages);
Console.WriteLine($"{response.SuccessCount} messages were sent successfully");


//Single Message:
/*
 string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
*/


//Multiple Topic:
/*
    var condition = "'stock-GOOG' in topics || 'industry-tech' in topics";
    new Message()
    {
        Notification = new Notification()
        {
            Body = "BODY MESSAGE TOPIC",
            Title = "TITLE TOPIC",
            ImageUrl = ""
        },
        Data = new Dictionary<string, string>()
            {
                { "Data1Key", "Data1Value" },
                { "Data2Key", "Data2Value" },
            },
        Condition = condition
    }
*/