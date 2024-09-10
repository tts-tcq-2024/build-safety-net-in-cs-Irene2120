using Xunit;
using System;
using System.Text;

public class SoundexTests
{
    [Fact]
    public void GenerateSoundex_EmptyString_ReturnsEmptyString()
    {
        string input=""; //arrange

        string result = Soundex.GenerateSoundex(input);   //Act

        Assert.Equal(string.Empty,result);      //assert
    }
    [Fact]
    public void GenerateSoundex_SingleCharacter_ReturnsPaddedCode()
    {
        string input ="A"; //arrange
        string result =Soundex.GenerateSoundex(input);   //act
        Assert.Equal("A000",result);         //assert
    }
    [Fact]
    public void GenerateSoundex_ValidName_ReturnsCorrectSoundex()
    {
        string input="Abcd";    //arrange
        string result = Soundex.GenerateSoundex(input); //act
        Assert.Equal("A123",result);   //assert
    }
    [Fact]
    public void GenerateSoundex_LongString_ReturnsTruncated()
    {
        string input="JackandJill"; //arrange
        string result = Soundex.GenerateSoundex(input); //act
        Assert.Equal("J020",result);    //only first4 ->assert
    }

    [Fact]
    public void GenerateSoundex_NumbersInString_ReturnsCorrectSoundex()
    {
        string input="Abcd456"; //arrange
        string result = Soundex.GenerateSoundex(input);          //act
        Assert.Equal("A123",result);    //numbers ignored ->assert
    }

    [Fact]
    public void InitializeSoundex_Validname_ReturnsInitializedSoundex()
    {
        string input="Jack"; //arrange
        var result = Soundex.InitializeSoundex(input);      //assert
        Assert.Equal("J",result.ToString());    //only first char -> result
    }
    [Fact]
    public void AppendingSoundexXharacters_ProcessCharCorrectly()
    {
        var soundexBuilder= new StringBuilder("J"); //arrange
        char prevCode ='J';
        
      Soundex.AppendingSoundexCharacters("Jack",soundexBuilder,ref prevCode);   //act
        
        Assert.Equal("J02",soundexBuilder.ToString());  //assert
    }
    [Fact]
    public void Characters_AppendCorrectCode()
    {
        var soundexBuilder= new StringBuilder("J"); //arrange
        char prevCode ='J';
        
      Soundex.Characters('a',soundexBuilder,ref prevCode);   //act
        
        Assert.Equal("J0",soundexBuilder.ToString());  //append 0 for a  ->assert   
    }
    [Fact]
    public void GetSoundexCode_ValidCharacter_ReturnsCorrectCode()
    {
        char character='B';     //arrange
        
        char result = Soundex.GetSoundexCode(character); //act
        
        Assert.Equal('1',result);    //assert
    }
    [Fact]
    public void GetSoundexCode_UnknownCharacter_ReturnsZero()
    {
        char character ='X';   //Arrange
        
       char result=Soundex.GetSoundexCode(character);  //act
        
        Assert.Equal('2',result);  //assert
    }
            
    [Fact]
    public void HandlesEmptyString()
    {
        Assert.Equal(string.Empty, Soundex.GenerateSoundex(""));
    }

    [Fact]
    public void HandlesSingleCharacter()
    {
        Assert.Equal("A000", Soundex.GenerateSoundex("A"));
    }

   
}
