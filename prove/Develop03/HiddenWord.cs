using System.Collections.Generic;
using System.Text;
 
class HiddenWord
{
    private List<Word> words;

    public HiddenWord(string word, bool isHidden)
    {
        words = new List<Word>();
        foreach (char c in word)
        {
            words.Add(new Word(c, isHidden, isHidden));
        }
    }

    public HiddenWord(string word, bool isHidden, bool isWordHidden)
    {
        words = new List<Word>();
        foreach (char c in word)
        {
            words.Add(new Word(c, isHidden, isWordHidden));
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Word w in words)
        {
            sb.Append(w.ToString());
        }
        return sb.ToString();
    }
}
