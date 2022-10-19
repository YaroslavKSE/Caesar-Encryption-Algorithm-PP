char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

char[] Encrypt(char[] text, int key)
{
    var encryptedText = new char[text.Length];
    for (int i = 0; i < text.Length; i++)
    {
        var notCodedElement = char.Parse(text[i].ToString().ToUpper());
        var indexOfNotCodedElement = GetIndex(alphabet, notCodedElement);
        
        if (IsPunctuation(text[i]))
        {
            encryptedText[i] = text[i];
        }
        else
        {
            if (GetIndex(alphabet, notCodedElement) + key  <= 25)
            {
                encryptedText[i] = alphabet[key + indexOfNotCodedElement];
            }
            else
            {
                encryptedText[i] = alphabet[(key + indexOfNotCodedElement) % 25];
            }
        }
    }
    
    return encryptedText;
}

int GetIndex(char[] array, char element)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == element)
        {
            return i;
        }
    }

    return 0;
}

bool IsPunctuation(char element)
{
    return element is ' ' or ',' or ';' or '-' or '.';
}

void Print(char[] array)
{
    foreach (var element in array)
    {
        Console.Write(element);
    }
    Console.WriteLine();
}

while (true)
{
    Console.WriteLine("Enter text:");
    var userInput = Console.ReadLine()!.ToCharArray();
    Console.WriteLine("Enter key:");
    var key = Console.ReadLine();
    var encrypted = Encrypt(userInput, int.Parse(key));
    Print(encrypted);
}