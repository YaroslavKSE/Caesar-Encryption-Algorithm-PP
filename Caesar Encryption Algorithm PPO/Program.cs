char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

char[] Encrypt(char[] text, int key)
{
    var encryptedText = new char[text.Length];
    for (int i = 0; i < text.Length; i++)
    {
        var notCodedElement = char.Parse(text[i].ToString().ToUpper());
        var indexOfNotCodedElement = GetIndex(notCodedElement);
        
        if (IsPunctuation(text[i]))
        {
            encryptedText[i] = text[i];
        }
        else
        {
            if (indexOfNotCodedElement + key  <= 25)
            {
                encryptedText[i] = alphabet[key + indexOfNotCodedElement];
            }
            else
            {
                encryptedText[i] = _alphabet[(key + indexOfNotCodedElement) % 26];
            }
        }
    }
    encryptedText = CheckCases(text, encryptedText);
    return encryptedText;
}

char[] Decrypt(char[] encryptedText, int key)
{
    char[] decrypted = new char[encryptedText.Length];
    for (int i = 0; i < encryptedText.Length; i++)
    {
        var notDecodedElement = char.Parse(encryptedText[i].ToString().ToUpper());
        var indexOfCodedElement = GetIndex(notDecodedElement);
        if (IsPunctuation(notDecodedElement))
        {
            decrypted[i] = encryptedText[i];
        }

        else
        {
            if (indexOfCodedElement - key >= 0)
            {
                decrypted[i] = alphabet[indexOfCodedElement - key];
            }
            else
            {
                decrypted[i] = _alphabet[26 + (indexOfCodedElement - key) % 26];
            }
        }
    }
    decrypted = CheckCases(encryptedText, decrypted);
    return decrypted;
}

int GetIndex(char element)
{
    for (int i = 0; i < alphabet.Length; i++)
    {
        if (alphabet[i] == element)
        {
            return i;
        }
    }

    return 0;
}

bool IsPunctuation(char element)
{
    return element is ' ' or ',' or ';' or '-' or '.' or '!' or '?' or ':' or '"';
}

void Print(char[] array)
{
    foreach (var element in array)
    {
        Console.Write(element);
    }
    Console.WriteLine();
}

char[] CheckCases(char[] userInput, char[] encrypted)
{
    for (int i = 0; i < userInput.Length; i++)
    {
        if (char.IsLower(userInput[i]))
        {
            encrypted[i] = char.Parse(encrypted[i].ToString().ToLower());
        }
    }
    return encrypted;
}

while (true)
{
    Console.WriteLine("Enter text:");
    var userInput = Console.ReadLine()!.ToCharArray();
    Console.WriteLine("Enter key:");
    var key = Console.ReadLine();
    var encrypted = Encrypt(userInput, int.Parse(key!));
    var decrypted = Decrypt(encrypted, int.Parse(key!));
    Print(encrypted);
    Print(decrypted);
    Console.WriteLine("Continue? [yes/no]");
    var end = Console.ReadLine();
    if (end?.ToLower() == "no")
    {
        break;
    }
}
