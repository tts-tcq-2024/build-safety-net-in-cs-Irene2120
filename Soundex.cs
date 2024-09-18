using System;
using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        StringBuilder soundex = InitializeSoundex(name);
        char prevCode = GetSoundexCode(name[0]);

        AppendingSoundexCharacters(name,soundex,ref prevCode);
        SoundexCode(ref soundex);
        return soundex.ToString();
    }
    private static StringBuilder InitializeSoundex(string name)
    {
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        return soundex;
    }
    private static void AppendingSoundexCharacters(string name , StringBuilder soundex,ref char prevCode)
    {
        foreach(char currentchar in name.Substring(1)) 
        {   
        if(soundex.Length >= 4)       //if length of soundex is 4 or more then break
        {
            break;
        }
        Characters(currentchar,soundex,ref prevCode);
    }
        
    }
    private static void Characters(char character,StringBuilder soundex,ref char prevCode)
    {
        if(char.IsLetter(character))
        {
            char code =GetSoundexCode(character);
            if(AppendCode(code,prevCode))
            {
                soundex.Append(code);
                prevCode=code;
            }
        }
    }
    private static bool AppendCode(char code ,char prevCode) =>code !='0' && code != prevCode;
    private static void SoundexCode(ref StringBuilder soundex)
    {
        while(soundex.Length<4)
        {
            soundex.Append('0');
        }
    }
    private static readonly Dictionary<char,char> SoundexMap = new Dictionary<char,char>
    {
        {'B','1'},{'F','1'},{'P','1'},{'V','1'},
        {'C','2'},{'G','2'},{'J','2'},{'K','2'},{'Q','2'},{'S','2'},{'X','2'},{'Z','2'},
        {'D','3'},{'T','3'},
        {'L','4'},
        {'M','5'},{'N','5'},
        {'R','6'}
    };
private static char GetSoundexCode(char character)     //attempts to find the character in the dictionary,if found returns Soundex code else returns 0
{
    character = char.ToUpper(character);
    return SoundexMap.TryGetValue(character,out char code)?code:'0';
}
}

    

       
