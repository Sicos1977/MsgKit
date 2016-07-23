## What is MsgKit?

MsgKit is a C# library which may be used for the creation and parsing (in the near future) of messages that are created with outlook

## History

Started in 2015

## License Information

MimeKit is Copyright (C) 2015-2016 Magic-Sessions and is licensed under the MIT license:

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

## Installing via NuGet

At the moment there is no package on NuGet... there will be one when the code is stable

### Creating an Outlook Message file

```csharp
var email = new Email(
	new Sender("peterpan@neverland.com", "Peter Pan"),
	new Representing("tinkerbell@neverland.com", "Tinkerbell"), 
	"Hello Neverland subject");
					  
email.Recipients.AddRecipientTo("captainhook@neverland.com", "Captain Hook");
email.Recipients.AddRecipientCc("crocodile@neverland.com", "The evil ticking crocodile");
email.Subject = "This is the subject";
email.BodyText = "Hello Neverland text";
email.BodyHtml = "<html><head></head><body><b>Hello Neverland html</b></body></html>";
email.Importance = MessageImportance.IMPORTANCE_HIGH;
email.IconIndex = MessageIconIndex.ReadMail;
email.Attachments.AddAttachment(@"d:\crocodile.jpg");
email.Save(@"c:\test.msg");

// Show the message
System.Diagnostics.Process.Start(@"c:\test.msg");
```

## Reporting Bugs

Have a bug or a feature request? [Please open a new issue](https://github.com/Sicos1977/MsgKit/issues).

Before opening a new issue, please search for existing issues to avoid submitting duplicates.
