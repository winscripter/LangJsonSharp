# LangJsonSharp
An incredibly small multilingual resource builder using JSON files on disk.

App.en-US.json:
```json
{
  "Greeting": "Hello!",
  "Yes": "Yes"
}
```

App.de-DE.json:
```json
{
  "Greeting": "Guten tag!",
  "Yes": "Ja"
}
```

App.es-ES.json:
```json
{
  "Greeting": "Hola!",
  "Yes": "Si"
}
```

Code:
```cs
using LangJsonSharp;

var mlm = new MultipleLanguageManager("App"); // prefix all *language*.json files with App -> App.*language*.json
Console.WriteLine(mlm["Greeting"]);
// The program produces following outputs depending on the system language or UI culture of the current thread:
//     - Hello! - if installed language is English (US)
//     - Guten tag! - if installed language is German
//     - Hola! - if installed language is Spanish
```

# Update note
This library is used specifically by [DbgSharp](https://github.com/winscripter/DbgSharp). This library is open-source because DbgSharp uses
it, and this library is open-source in order to provide security. That being said, you **can** use this library for your projects if you want,
but it will only be updated if DbgSharp needs to be updated or a bug is known. Suggestions are acceptable.
